using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XemPhimBan2.DTO;
using XemPhimBan2.Models;

[ApiController]
[Route("api/[controller]")]
public class HoaDonController : ControllerBase
{
    private readonly RapchieuphimContext _context;

    public HoaDonController(RapchieuphimContext context)
    {
        _context = context;
    }

    // GET: api/hoadon
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var hoadons = await _context.Hoadons
            .Include(h => h.MaDonNavigation)
            .Include(h => h.Chitiethoadons)
                .ThenInclude(ct => ct.MaVeNavigation)
            .ToListAsync();

        return Ok(hoadons);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHoaDon(int id)
    {
        var hd = await _context.Hoadons.FindAsync(id);
        if (hd == null) return NotFound();

        _context.Hoadons.Remove(hd);
        await _context.SaveChangesAsync();

        return Ok("Đã xóa hóa đơn.");
    }
    [HttpPost("tao")]
    public async Task<IActionResult> TaoHoaDon([FromBody] TaoHoaDonRequest req)
    {
        using var transaction = _context.Database.BeginTransaction();

        try
        {
            var don = await _context.Dons
                .Include(d => d.Ves)
                .FirstOrDefaultAsync(d => d.MaDon == req.MaDon);

            if (don == null)
                return NotFound("Không tìm thấy đơn!");

            if (!don.Ves.Any())
                return BadRequest("Đơn này không có vé để lập hóa đơn!");

            // 2. Tính tổng tiền vé
            decimal tongTienVe = don.Ves.Sum(v => v.GiaVe ?? 0);

            // 3. Tính VAT
            decimal vat = tongTienVe * (req.ThueVat ?? 0);

            // 4. Tạo hóa đơn
            var hoaDon = new Hoadon
            {
                MaDon = don.MaDon,
                NgayXuat = DateTime.Now,
                TongTien = tongTienVe + vat,
                ThueVat = vat,
                HinhThucThanhToan = req.HinhThucThanhToan,
                TrangThaiHoaDon = "Đã thanh toán"
            };

            _context.Hoadons.Add(hoaDon);
            await _context.SaveChangesAsync();

            // 5. Tạo chi tiết hóa đơn cho từng vé
            foreach (var ve in don.Ves)
            {
                var ct = new Chitiethoadon
                {
                    MaHoaDon = hoaDon.MaHoaDon,
                    MaVe = ve.MaVe,
                    DonGia = ve.GiaVe,
                };

                _context.Chitiethoadons.Add(ct);
            }
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            return Ok(new
            {
                message = "Tạo hóa đơn thành công!",
                maHoaDon = hoaDon.MaHoaDon,
                tongTien = hoaDon.TongTien,
                ngayXuat = hoaDon.NgayXuat?.ToString("dd/MM/yyyy HH:mm:ss")
            });
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            return StatusCode(500, "Lỗi: " + ex.Message);
        }
    }
}
