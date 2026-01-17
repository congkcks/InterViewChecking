using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XemPhimBan2.Models;

[Route("api/[controller]")]
[ApiController]
public class PhimController : ControllerBase
{
    private readonly RapchieuphimContext _context;

    public PhimController(RapchieuphimContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var dsPhim = await _context.Phims
            .Include(p => p.Suatchieus)
                .ThenInclude(s => s.MaPhongNavigation)
            .Include(p => p.Suatchieus)
                .ThenInclude(s => s.MaCaNavigation)
            .Select(p => new
            {
                p.MaPhim,
                p.TenPhim,
                p.TheLoai,
                p.ThoiLuong,
                p.NgayKhoiChieu,
                p.QuocGia,
                p.NgonNgu,
                p.MoTa,

                SuatChieu = p.Suatchieus.Select(s => new
                {
                    s.MaSuat,
                    s.NgayChieu,
                    TenPhong = s.MaPhongNavigation != null
                        ? s.MaPhongNavigation.TenPhong
                        : null,

                    TenCa = s.MaCaNavigation != null
                        ? s.MaCaNavigation.TenCa
                        : null,

                    GioBatDau = s.MaCaNavigation != null
                        ? s.MaCaNavigation.GioBatDau.ToString()
                        : null,

                    GiaSuat = s.GiaSuat
                }).ToList()
            })
            .ToListAsync();

        return Ok(dsPhim);
    }


    [HttpPost]
    public async Task<IActionResult> CreatePhim([FromBody] Phim model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _context.Phims.Add(model);
        await _context.SaveChangesAsync();

        return Ok(new
        {
            message = "Thêm phim thành công!",
            data = model
        });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePhim(int id, [FromBody] Phim model)
    {
        var phim = await _context.Phims.FindAsync(id);

        if (phim == null)
            return NotFound("Không tìm thấy phim!");

        phim.TenPhim = model.TenPhim;
        phim.TheLoai = model.TheLoai;
        phim.ThoiLuong = model.ThoiLuong;
        phim.NgonNgu = model.NgonNgu;
        phim.QuocGia = model.QuocGia;
        phim.NgayKhoiChieu = model.NgayKhoiChieu;
        phim.MoTa = model.MoTa;

        await _context.SaveChangesAsync();

        return Ok(new
        {
            message = "Cập nhật phim thành công!",
            data = phim
        });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePhim(int id)
    {
        var phim = await _context.Phims.FindAsync(id);

        if (phim == null)
            return NotFound("Không tìm thấy phim!");

        _context.Phims.Remove(phim);
        await _context.SaveChangesAsync();

        return Ok(new
        {
            message = "Xoá phim thành công!"
        });
    }
}
