using System;
using System.Collections.Generic;

namespace XemPhimBan2.Models;

public partial class Taikhoan
{
    public int MaNguoiDung { get; set; }

    public string TenDangNhap { get; set; } = null!;

    public string MatKhau { get; set; } = null!;

    public string? HoTen { get; set; }

    public string? SoDienThoai { get; set; }

    public string? Email { get; set; }

    public string? TrangThai { get; set; }

    public DateTime? NgayTao { get; set; }

    public virtual ICollection<Don> Dons { get; set; } = new List<Don>();
}
