using System;
using System.Collections.Generic;

namespace kkkkkk.Models;

public partial class TbHoaDonNhap
{
    public string MaHoaDonNhap { get; set; } = null!;

    public string MaNhaCungCap { get; set; } = null!;

    public DateOnly NgayLap { get; set; }

    public virtual TbNhaCungCap MaNhaCungCapNavigation { get; set; } = null!;

    public virtual ICollection<TbChiTietHdn> TbChiTietHdns { get; set; } = new List<TbChiTietHdn>();
}
