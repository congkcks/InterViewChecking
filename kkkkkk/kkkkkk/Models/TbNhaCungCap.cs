using System;
using System.Collections.Generic;

namespace kkkkkk.Models;

public partial class TbNhaCungCap
{
    public string MaNhaCungCap { get; set; } = null!;

    public string TenNhaCungCap { get; set; } = null!;

    public string? SoDienThoai { get; set; }

    public string? Email { get; set; }

    public string DiaChi { get; set; } = null!;

    public virtual ICollection<TbHoaDonNhap> TbHoaDonNhaps { get; set; } = new List<TbHoaDonNhap>();
}
