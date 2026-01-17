using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XemPhimBan2.DTO;
using XemPhimBan2.Models;

[ApiController]
[Route("api/[controller]")]
public class VeController : ControllerBase
{
    private readonly RapchieuphimContext _context;

    public VeController(RapchieuphimContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllVe()
    {
        var ves = await _context.Ves
            .Include(v => v.MaDonNavigation)
            .Include(v => v.MaSuatNavigation)
            .Include(v => v.MaGheNavigation)
            .Select(v => new
            {
                v.MaVe,
                v.MaDon,
                v.MaSuat,
                v.MaGhe,
                v.GiaVe,
                TenPhong = v.MaSuatNavigation.MaPhongNavigation.TenPhong,
                TenPhim = v.MaSuatNavigation.MaPhimNavigation.TenPhim,
                Ghe = v.MaGheNavigation.HangGhe + v.MaGheNavigation.CotGhe
            })
            .ToListAsync();

        return Ok(ves);
    }
    [HttpGet("ghe-da-chon/{maSuat}")]
    public async Task<IActionResult> LayGheDaChon(int maSuat)
    {
        var gheDaChon = await _context.Ves
            .Where(v => v.MaSuat == maSuat && v.MaDon != null)
            .ToListAsync();

        return Ok(gheDaChon);
    }
    [HttpPost]
    public async Task<IActionResult> TaoVe([FromBody] Ve model)
    {
        _context.Ves.Add(model);
        await _context.SaveChangesAsync();
        return Ok("Đã tạo vé thành công!");
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> XoaVe(int id)
    {
        var ve = await _context.Ves.FindAsync(id);
        if (ve == null)
            return NotFound("Không tìm thấy vé");

        _context.Ves.Remove(ve);
        await _context.SaveChangesAsync();

        return Ok("Đã xóa vé thành công!");
    }
    [HttpPost("chon-nhieu-ghe")]
    public async Task<IActionResult> ChonNhieuGhe([FromBody] ChonNhieuGheRequest request)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            var gheDaCoVe = await _context.Ves
                .Where(v => v.MaSuat == request.MaSuat
                         && request.DsMaGhe.Contains(v.MaGhe.Value))
                .Select(v => v.MaGhe)
                .ToListAsync();

            if (gheDaCoVe.Any())
            {
                return BadRequest(new
                {
                    message = "Có ghế đã bị người khác đặt!",
                    gheBiTrung = gheDaCoVe
                });
            }
            var suat = await _context.Suatchieus
                .FirstOrDefaultAsync(s => s.MaSuat == request.MaSuat);

            if (suat == null)
                return BadRequest("Suất chiếu không tồn tại!");

            decimal tongTien = (suat.GiaSuat ?? 0) * request.DsMaGhe.Count;
            var don = new Don
            {
                NgayDat = DateTime.Now,
                TongTien = tongTien,
                TrangThai = "CHO_THANH_TOAN",
                MaNguoiDung = request.MaNguoiDung

            };

            _context.Dons.Add(don);
            await _context.SaveChangesAsync();

            var danhSachVe = new List<Ve>();

            foreach (var maGhe in request.DsMaGhe)
            {
                var ve = new Ve
                {
                    MaSuat = request.MaSuat,
                    MaGhe = maGhe,
                    GiaVe = suat.GiaSuat,
                    MaDon = don.MaDon 
                };

                danhSachVe.Add(ve);
            }

            _context.Ves.AddRange(danhSachVe);
            await _context.SaveChangesAsync();

           
            await transaction.CommitAsync();

           
            return Ok(new
            {
                message = "Đặt ghế + tạo đơn thành công!",
                don = new
                {
                    maDon = don.MaDon,
                    tongTien = don.TongTien,
                    ngayTao = don.NgayDat,
                    trangThai = don.TrangThai
                },
                dsVe = danhSachVe.Select(v => new
                {
                    maVe = v.MaVe,
                    maGhe = v.MaGhe,
                    giaVe = v.GiaVe
                })
            });
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            return StatusCode(500, "Lỗi khi xử lý: " + ex.Message);
        }
    }
    [HttpPut("huy-ve")]
    public async Task<IActionResult> HuyVe([FromBody] HuyVeRequest req)
    {
        using var tran = await _context.Database.BeginTransactionAsync();

        try
        {
            var ve = await _context.Ves
                .Include(v => v.MaDonNavigation)
                .FirstOrDefaultAsync(v => v.MaVe == req.MaVe);

            if (ve == null)
                return NotFound("Không tìm thấy vé!");

            var don = ve.MaDonNavigation;

            if (don == null)
                return BadRequest("Vé này không thuộc đơn nào!");

            if (don.MaNguoiDung != req.MaNguoiDung)
                return BadRequest("Bạn không có quyền hủy vé của người khác!");

            ve.MaDon = null;
            await _context.SaveChangesAsync();
            bool donConVe = await _context.Ves.AnyAsync(v => v.MaDon == don.MaDon);
            if (!donConVe)
            {
                _context.Dons.Remove(don);
                await _context.SaveChangesAsync();
            }

            await tran.CommitAsync();

            return Ok("Hủy vé thành công!");
        }
        catch (Exception ex)
        {
            await tran.RollbackAsync();
            return StatusCode(500, "Lỗi: " + ex.Message);
        }
    }



}
