using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XemPhimBan2.Models;
using XemPhimBan2.DTO;

[ApiController]
[Route("api/[controller]")]
public class TaiKhoanController : ControllerBase
{
    private readonly RapchieuphimContext _context;

    public TaiKhoanController(RapchieuphimContext context)
    {
        _context = context;
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest req)
    {
        var user = await _context.Taikhoans
            .FirstOrDefaultAsync(t => t.TenDangNhap == req.TenDangNhap
                                   && t.MatKhau == req.MatKhau);

        if (user == null)
            return BadRequest("Sai tài khoản hoặc mật khẩu!");

        return Ok(new
        {
            message = "Đăng nhập thành công!",
            maNguoiDung = user.MaNguoiDung,
            hoTen = user.HoTen,
            email = user.Email
        });
    }
    [HttpPost("logout")]
    public IActionResult Logout()
    {
        return Ok("Đăng xuất thành công!");
    }
    [HttpPost("dang-ky")]
    public async Task<IActionResult> DangKy([FromBody] DangKyRequest model)
    {
        // 1. Kiểm tra input cơ bản
        if (string.IsNullOrWhiteSpace(model.TenDangNhap) ||
            string.IsNullOrWhiteSpace(model.MatKhau))
        {
            return BadRequest("Tên đăng nhập và mật khẩu không được để trống!");
        }
        bool exists = await _context.Taikhoans
            .AnyAsync(t => t.TenDangNhap == model.TenDangNhap);

        if (exists)
        {
            return Conflict("Tên đăng nhập đã tồn tại!");
        }
        var tk = new Taikhoan
        {
            TenDangNhap = model.TenDangNhap,
            MatKhau = model.MatKhau,
            HoTen = model.HoTen,
            Email = model.Email,
            SoDienThoai = model.SoDienThoai,
            TrangThai = "HOAT_DONG",
            NgayTao = DateTime.Now
        };

        _context.Taikhoans.Add(tk);
        await _context.SaveChangesAsync();

        return Ok(new
        {
            message = "Đăng ký thành công!",
            data = new
            {
                tk.MaNguoiDung,
                tk.TenDangNhap,
                tk.HoTen,
                tk.Email,
                tk.SoDienThoai,
                tk.TrangThai,
                tk.NgayTao
            }
        });
    }
}
