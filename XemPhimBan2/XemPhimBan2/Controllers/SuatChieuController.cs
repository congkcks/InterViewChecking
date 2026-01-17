using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XemPhimBan2.DTO;
using XemPhimBan2.Models;

[Route("api/[controller]")]
[ApiController]
public class SuatChieuController : ControllerBase
{
    private readonly RapchieuphimContext _context;

    public SuatChieuController(RapchieuphimContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllSuatChieu()
    {
        var dsSuat = await _context.Suatchieus
            .Include(s => s.MaPhimNavigation)
            .Include(s => s.MaPhongNavigation)
            .Include(s => s.MaCaNavigation)
            .Select(s => new
            {
                s.MaSuat,
                s.MaPhim,
                TenPhim = s.MaPhimNavigation != null ? s.MaPhimNavigation.TenPhim : null,
                s.MaPhong,
                TenPhong = s.MaPhongNavigation != null ? s.MaPhongNavigation.TenPhong : null,
                s.MaCa,
                GioChieu = s.MaCaNavigation != null ? s.MaCaNavigation.GioBatDau : null,
                s.NgayChieu,
                s.GiaSuat
            })
            .ToListAsync();

        return Ok(dsSuat);
    }

    [HttpPost("tao")]
    public async Task<IActionResult> TaoSuatChieu([FromBody] TaoSuatChieuRequest request)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            var suat = new Suatchieu
            {
                MaPhim = request.MaPhim,
                NgayChieu = request.NgayKhoiChieuMoi,
                MaPhong = request.MaPhong,
                MaCa = request.MaCa,
                GiaSuat=request.GiaVe
            };

            _context.Suatchieus.Add(suat);
            await _context.SaveChangesAsync();

            // Cập nhật ngày khởi chiếu của phim
            var phim = await _context.Phims.FindAsync(request.MaPhim);
            if (phim != null)
            {
                phim.NgayKhoiChieu = request.NgayKhoiChieuMoi;
                await _context.SaveChangesAsync();
            }

            await transaction.CommitAsync();

            return Ok(new
            {
                message = "Tạo suất chiếu thành công!",
                maSuat = suat.MaSuat,
                maPhim = suat.MaPhim,
                maPhong = suat.MaPhong,
                maCa = suat.MaCa,
                ngayChieu = suat.NgayChieu
            });
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            return BadRequest("Lỗi: " + ex.Message);
        }
    }

    [HttpGet("lichchieu-ui/{maPhim}")]
    public async Task<IActionResult> GetLichChieuUI(int maPhim)
    {
        var lichChieu = await _context.Suatchieus
            .Include(s => s.MaPhongNavigation)
            .Include(s => s.MaCaNavigation)
            .Where(s => s.MaPhim == maPhim)
            .Select(s => new
            {
                maSuat = s.MaSuat,

                gioChieu = s.MaCaNavigation.GioBatDau != null
    ? s.MaCaNavigation.GioBatDau.Value.ToString("HH:mm")
    : null,


                maPhong = s.MaPhong,
                tenPhong = s.MaPhongNavigation != null
                    ? s.MaPhongNavigation.TenPhong
                    : null,

                giaVe = s.GiaSuat
            })
            .ToListAsync();

        if (!lichChieu.Any())
            return NotFound("Không tìm thấy lịch chiếu của phim!");

        return Ok(lichChieu);
    }
    [HttpPut("capnhat")]
    public async Task<IActionResult> CapNhatSuatChieu([FromBody] CapNhatSuatChieuRequest request)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            var suat = await _context.Suatchieus
                .FirstOrDefaultAsync(s => s.MaSuat == request.MaSuat);

            if (suat == null)
                return NotFound("Không tìm thấy suất chiếu!");

            // Update theo field được truyền
            if (request.MaPhim.HasValue)
                suat.MaPhim = request.MaPhim;

            if (request.MaPhong.HasValue)
                suat.MaPhong = request.MaPhong;

            if (request.MaCa.HasValue)
                suat.MaCa = request.MaCa;

            if (request.NgayChieu.HasValue)
                suat.NgayChieu = request.NgayChieu;

            if (request.GiaSuat.HasValue)
                suat.GiaSuat = request.GiaSuat;

            await _context.SaveChangesAsync();

            if (request.MaPhim.HasValue && request.NgayChieu.HasValue)
            {
                var phim = await _context.Phims
                    .FirstOrDefaultAsync(p => p.MaPhim == request.MaPhim);

                if (phim != null)
                {
                    phim.NgayKhoiChieu = request.NgayChieu;
                    await _context.SaveChangesAsync();
                }
            }

            await transaction.CommitAsync();
            return Ok("Cập nhật suất chiếu thành công!");
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            return BadRequest("Lỗi khi cập nhật: " + ex.Message);
        }
    }
    [HttpGet("chi-tiet/{maSuat}")]
    public async Task<IActionResult> GetChiTietSuatChieu(int maSuat)
    {
        var suat = await _context.Suatchieus
            .Include(s => s.MaPhimNavigation)
            .Include(s => s.MaPhongNavigation)
            .Include(s => s.MaCaNavigation)
            .FirstOrDefaultAsync(s => s.MaSuat == maSuat);

        if (suat == null)
            return NotFound("Không tìm thấy suất chiếu");

        var danhSachGhe = await _context.Ghes
            .Where(g => g.MaPhong == suat.MaPhong)
            .Select(g => new
            {
                maGhe = g.MaGhe,
                hang = g.HangGhe,
                cot = g.CotGhe,
                loaiGhe = g.LoaiGhe,
                giaGhe = g.GiaGhe,

                daChon = _context.Ves.Any(v =>
                    v.MaSuat == maSuat &&
                    v.MaGhe == g.MaGhe &&
                    v.MaDon != null
                ),

                daBan = _context.Ves.Any(v =>
                    v.MaSuat == maSuat &&
                    v.MaGhe == g.MaGhe &&
                    v.MaDon != null
                )
            })
            .OrderBy(g => g.hang)
            .ThenBy(g => g.cot)
            .ToListAsync();
       
        var response = new
        {
            suatChieu = new
            {
                maSuat = suat.MaSuat,
                tenPhim = suat.MaPhimNavigation?.TenPhim,
                tenPhong = suat.MaPhongNavigation?.TenPhong,
                ngayChieu = suat.NgayChieu?.ToString("dd/MM/yyyy"),
                gioChieu = suat.MaCaNavigation?.GioBatDau?.ToString(@"hh\:mm"),
                giaSuat = suat.GiaSuat
            },
            ghe = danhSachGhe
        };

        return Ok(response);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSuatChieu(int id)
    {
        var suat = await _context.Suatchieus.FindAsync(id);

        if (suat == null)
            return NotFound(new { message = "Suất chiếu không tồn tại" });

        var ves = _context.Ves.Where(v => v.MaSuat == id);
        _context.Ves.RemoveRange(ves);

        _context.Suatchieus.Remove(suat);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Xóa suất chiếu thành công" });
    }



}
