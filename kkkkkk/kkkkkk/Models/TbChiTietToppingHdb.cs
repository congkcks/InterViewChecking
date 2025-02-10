using System;
using System.Collections.Generic;

namespace kkkkkk.Models;

public partial class TbChiTietToppingHdb
{
    public string MaHoaDonBan { get; set; } = null!;

    public string MaSanPham { get; set; } = null!;

    public string MaTopping { get; set; } = null!;

    public int SoLuong { get; set; }

    public virtual TbTopping MaToppingNavigation { get; set; } = null!;

    public virtual TbChiTietHdb TbChiTietHdb { get; set; } = null!;
}
