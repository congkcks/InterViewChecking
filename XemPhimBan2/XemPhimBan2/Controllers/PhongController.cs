using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XemPhimBan2.Models;
using XemPhimBan2.DTO;
namespace XemPhimBan2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PhongController : ControllerBase
{
    private readonly RapchieuphimContext _context;

    public PhongController(RapchieuphimContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var dsPhong = await _context.Phongs.ToListAsync();
        return Ok(dsPhong);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var phong = await _context.Phongs.FindAsync(id);

        if (phong == null)
            return NotFound("Không tìm thấy phòng!");

        return Ok(phong);
    }


    [HttpPost]
    public async Task<IActionResult> TaoPhong([FromBody] TaoPhongRequest request)
    {
        if (request.SoHang <= 0 || request.SoCot <= 0)
            return BadRequest("Số hàng và số cột phải lớn hơn 0");

        // 1. Tạo phòng
        var phong = new Phong
        {
            TenPhong = request.TenPhong,
            TongSoGhe = request.SoHang * request.SoCot
        };

        _context.Phongs.Add(phong);
        await _context.SaveChangesAsync(); // lấy MaPhong
        var dsGhe = new List<Ghe>();

        for (int h = 1; h <= request.SoHang; h++)
        {
            string hangChu = ((char)('A' + h - 1)).ToString();

            for (int c = 1; c <= request.SoCot; c++)
            {
                dsGhe.Add(new Ghe
                {
                    MaPhong = phong.MaPhong,
                    HangGhe = hangChu,
                    CotGhe = c,
                    LoaiGhe = request.LoaiGheMacDinh ?? "Thuong",
                    GiaGhe = request.GiaMacDinh
                });
            }
        }

        _context.Ghes.AddRange(dsGhe);
        await _context.SaveChangesAsync();

        // 3. Trả DTO (không trả entity → tránh vòng lặp)
        return Ok(new
        {
            message = "Tạo phòng + sinh ghế thành công!",
            phong = new
            {
                maPhong = phong.MaPhong,
                tenPhong = phong.TenPhong,
                tongSoGhe = phong.TongSoGhe
            },
            dsGhe = dsGhe.Select(g => new {
                maGhe = g.MaGhe,
                hang = g.HangGhe,
                cot = g.CotGhe,
                loai = g.LoaiGhe,
                gia = g.GiaGhe
            })
        });
    }




    // PUT: api/phong/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Phong model)
    {
        var phong = await _context.Phongs.FindAsync(id);
        if (phong == null)
            return NotFound("Không tìm thấy phòng!");

        phong.TenPhong = model.TenPhong;
        phong.TongSoGhe = model.TongSoGhe;

        await _context.SaveChangesAsync();

        return Ok(new
        {
            message = "Cập nhật phòng chiếu thành công!",
            data = phong
        });
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var phong = await _context.Phongs.FindAsync(id);
        if (phong == null)
            return NotFound("Không tìm thấy phòng!");

        // Không cho xóa khi có ghế hoặc suất chiếu liên quan
        bool coGhe = await _context.Ghes.AnyAsync(g => g.MaPhong == id);
        bool coSuat = await _context.Suatchieus.AnyAsync(s => s.MaPhong == id);

        if (coGhe || coSuat)
            return BadRequest("Không thể xóa phòng vì đang có ghế hoặc suất chiếu!");

        _context.Phongs.Remove(phong);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Xóa phòng chiếu thành công!" });
    }
    [HttpGet("{maPhong}/ghe")]
    public async Task<IActionResult> GetGheTheoPhong(int maPhong)
    {
        var phong = await _context.Phongs.FindAsync(maPhong);
        if (phong == null)
            return NotFound("Không tìm thấy phòng!");

        var dsGhe = await _context.Ghes
            .Where(g => g.MaPhong == maPhong)
            .OrderBy(g => g.HangGhe)
            .ThenBy(g => g.CotGhe)
            .Select(g => new
            {
                maGhe = g.MaGhe,
                hang = g.HangGhe,
                cot = g.CotGhe,
                loai = g.LoaiGhe,
                gia = g.GiaGhe
            })
            .ToListAsync();

        return Ok(dsGhe);
    }

    [HttpPost("{maPhong}/ghe")]
    public async Task<IActionResult> AddGhe(int maPhong, [FromBody] GheRequest model)
    {
        var phong = await _context.Phongs.FindAsync(maPhong);
        if (phong == null)
            return NotFound("Không tìm thấy phòng!");

        bool trung = await _context.Ghes.AnyAsync(g =>
            g.MaPhong == maPhong &&
            g.HangGhe == model.HangGhe &&
            g.CotGhe == model.CotGhe
        );

        if (trung)
            return BadRequest("Ghế đã tồn tại trong phòng!");

        var ghe = new Ghe
        {
            MaPhong = maPhong,
            HangGhe = model.HangGhe,
            CotGhe = model.CotGhe,
            LoaiGhe = model.LoaiGhe,
            GiaGhe = model.GiaGhe
        };

        _context.Ghes.Add(ghe);
        await _context.SaveChangesAsync();

        var gheDto = new
        {
            maGhe = ghe.MaGhe,
            maPhong = ghe.MaPhong,
            hangGhe = ghe.HangGhe,
            cotGhe = ghe.CotGhe,
            loaiGhe = ghe.LoaiGhe,
            giaGhe = ghe.GiaGhe
        };

        return Ok(new
        {
            message = "Thêm ghế thành công!",
            ghe = gheDto
        });
    }


    [HttpPut("ghe/{maGhe}")]
    public async Task<IActionResult> UpdateGhe(int maGhe, [FromBody] GheRequest model)
    {
        var ghe = await _context.Ghes.FindAsync(maGhe);
        if (ghe == null)
            return NotFound("Không tìm thấy ghế!");

        bool trung = await _context.Ghes.AnyAsync(g =>
            g.MaPhong == ghe.MaPhong &&
            g.HangGhe == model.HangGhe &&
            g.CotGhe == model.CotGhe &&
            g.MaGhe != maGhe
        );

        if (trung)
            return BadRequest("Vị trí ghế đã tồn tại!");

        ghe.HangGhe = model.HangGhe;
        ghe.CotGhe = model.CotGhe;
        ghe.LoaiGhe = model.LoaiGhe;
        ghe.GiaGhe = model.GiaGhe;

        await _context.SaveChangesAsync();

        return Ok(new { message = "Cập nhật ghế thành công!", ghe });
    }

    // DELETE: api/phong/ghe/10 → xóa ghế
    [HttpDelete("ghe/{maGhe}")]
    public async Task<IActionResult> DeleteGhe(int maGhe)
    {
        var ghe = await _context.Ghes.FindAsync(maGhe);
        if (ghe == null)
            return NotFound("Không tìm thấy ghế!");

        bool daBan = await _context.Ves.AnyAsync(v => v.MaGhe == maGhe);
        if (daBan)
            return BadRequest("Không thể xóa ghế vì đã có vé được bán!");

        _context.Ghes.Remove(ghe);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Xóa ghế thành công!" });
    }
}




public class GheRequest
{
    public string HangGhe { get; set; }
    public int CotGhe { get; set; }
    public string LoaiGhe { get; set; }
    public decimal GiaGhe { get; set; }
}
