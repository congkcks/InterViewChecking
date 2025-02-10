using System;
using System.Collections.Generic;

namespace kkkkkk.Models;

public partial class TbChiTietHdn
{
    public string MaHoaDonNhap { get; set; } = null!;

    public string MaVatTu { get; set; } = null!;

    public int SoLuongNhap { get; set; }

    public int GiaNhap { get; set; }

    public virtual TbHoaDonNhap MaHoaDonNhapNavigation { get; set; } = null!;

    public virtual TbVatTu MaVatTuNavigation { get; set; } = null!;
}
