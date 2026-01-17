using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XemPhimBan2.Models;
using XemPhimBan2.DTO;
[ApiController]
[Route("api/[controller]")]
public class DonController : ControllerBase
{
    private readonly RapchieuphimContext _context;

    public DonController(RapchieuphimContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllDon()
    {
        var dons = await _context.Dons
            .Include(d => d.Ves)
            .ToListAsync();

        var result = dons.Select(d => new
        {
            maDon = d.MaDon,
            maNguoiDung = d.MaNguoiDung,
            ngayDat = d.NgayDat,
            tongTien = d.TongTien,
            trangThai = d.TrangThai,

            dsVe = d.Ves.Select(v => new
            {
                v.MaVe,
                v.MaGhe,
                v.MaSuat,
                v.GiaVe
            })
        });

        return Ok(result);
    }


    [HttpPost("tao-don")]
    public async Task<IActionResult> TaoDon([FromBody] TaoDonRequest req)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            int maNguoiDung = req.MaNguoiDung == 0 ? 1 : req.MaNguoiDung;
            var ves = await _context.Ves
                .Where(v => req.DsMaVe.Contains(v.MaVe))
                .ToListAsync();

            if (!ves.Any())
                return BadRequest("Không tìm thấy vé hợp lệ!");
            decimal tongTien = ves.Sum(v => v.GiaVe ?? 0);
            var don = new Don
            {
                MaNguoiDung = maNguoiDung,
                NgayDat = DateTime.Now,
                TongTien = tongTien,
                TrangThai = "CHO_THANH_TOAN"
            };

            _context.Dons.Add(don);
            await _context.SaveChangesAsync();

            foreach (var ve in ves)
            {
                ve.MaDon = don.MaDon;
            }

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return Ok(new
            {
                message = "Tạo đơn thành công!",
                maDon = don.MaDon,
                tongTien = don.TongTien,
                soLuongVe = ves.Count,
                maNguoiDung = don.MaNguoiDung,
                dsVe = ves.Select(v => new {
                    v.MaVe,
                    v.MaGhe,
                    v.MaSuat,
                    v.GiaVe
                })
            });
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            return StatusCode(500, new
            {
                message = "Lỗi khi tạo đơn!",
                detail = ex.InnerException?.Message ?? ex.Message
            });
        }
    }
    [HttpGet("{maDon}")]
    public async Task<IActionResult> GetDon(int maDon)
    {
        var don = await _context.Dons
            .Include(d => d.Ves)
            .FirstOrDefaultAsync(d => d.MaDon == maDon);

        if (don == null)
            return NotFound("Không tìm thấy đơn!");

        return Ok(new
        {
            maDon = don.MaDon,
            maNguoiDung = don.MaNguoiDung ?? 1,
            ngayDat = don.NgayDat,
            tongTien = don.TongTien,
            trangThai = don.TrangThai,

            dsVe = don.Ves.Select(v => new {
                v.MaVe,
                v.MaGhe,
                v.MaSuat,
                v.GiaVe
            })
        });
    }
    [HttpPut("cap-nhat/{maDon}")]
    public async Task<IActionResult> CapNhatDon(int maDon, [FromBody] CapNhatDonRequest req)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            var don = await _context.Dons
                .Include(d => d.Ves)
                .FirstOrDefaultAsync(d => d.MaDon == maDon);

            if (don == null)
                return NotFound("Không tìm thấy đơn!");

            if (!string.IsNullOrEmpty(req.TrangThai))
                don.TrangThai = req.TrangThai;
            if (req.DsMaVe != null && req.DsMaVe.Any())
            {
                foreach (var ve in don.Ves)
                    ve.MaDon = null;
                var vesMoi = await _context.Ves
                    .Where(v => req.DsMaVe.Contains(v.MaVe))
                    .ToListAsync();

                if (!vesMoi.Any())
                    return BadRequest("Không tìm thấy vé hợp lệ để cập nhật!");
                foreach (var ve in vesMoi)
                    ve.MaDon = don.MaDon;
                don.TongTien = vesMoi.Sum(v => v.GiaVe ?? 0);
            }

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return Ok(new
            {
                message = "Cập nhật đơn thành công!",
                maDon = don.MaDon,
                tongTien = don.TongTien,
                trangThai = don.TrangThai
            });
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            return StatusCode(500, new
            {
                message = "Lỗi khi cập nhật đơn!",
                detail = ex.InnerException?.Message ?? ex.Message
            });
        }
    }
    [HttpDelete("xoa/{maDon}")]
    public async Task<IActionResult> XoaDon(int maDon)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            var don = await _context.Dons
                .Include(d => d.Ves)
                .FirstOrDefaultAsync(d => d.MaDon == maDon);

            if (don == null)
                return NotFound("Không tìm thấy đơn!");
            foreach (var ve in don.Ves)
                ve.MaDon = null;

            await _context.SaveChangesAsync();
            _context.Dons.Remove(don);
            await _context.SaveChangesAsync();

            await transaction.CommitAsync();

            return Ok(new
            {
                message = "Xóa đơn thành công!",
                maDon = maDon
            });
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            return StatusCode(500, new
            {
                message = "Lỗi khi xóa đơn!",
                detail = ex.InnerException?.Message ?? ex.Message
            });
        }
    }
    [HttpGet("don-theo-nguoi-dung/{maNguoiDung}")]
    public async Task<IActionResult> LayDonTheoNguoiDung(int maNguoiDung)
    {
        var dons = await _context.Dons
            .Where(d => d.MaNguoiDung == maNguoiDung)
            .Include(d => d.Ves)
            .Select(d => new
            {
                d.MaDon,
                d.MaNguoiDung,
                d.NgayDat,
                d.TongTien,
                d.TrangThai,
                SoLuongVe = d.Ves.Count, 
                dsVe = d.Ves.Select(v => new
                {
                    v.MaVe,
                    v.MaGhe,
                    v.MaSuat,
                    v.GiaVe
                })
            })
            .ToListAsync();
        return Ok(dons);
    }
    [HttpDelete("huy-don/{maDon}")]
    public async Task<IActionResult> HuyDon(int maDon)
    {
        using var tran = await _context.Database.BeginTransactionAsync();

        try
        {
            var don = await _context.Dons
                .Include(d => d.Ves)
                .FirstOrDefaultAsync(d => d.MaDon == maDon);

            if (don == null)
                return NotFound("Không tìm thấy đơn!");

            // XÓA toàn bộ vé thuộc đơn (GIẢI PHÓNG GHẾ)
            _context.Ves.RemoveRange(don.Ves);

            // XÓA đơn
            _context.Dons.Remove(don);

            // LƯU
            await _context.SaveChangesAsync();

            await tran.CommitAsync();

            return Ok(new
            {
                message = "Hủy đơn thành công! Ghế đã được giải phóng."
            });
        }
        catch (Exception ex)
        {
            await tran.RollbackAsync();
            return StatusCode(500, "Lỗi: " + ex.Message);
        }
    }



}
