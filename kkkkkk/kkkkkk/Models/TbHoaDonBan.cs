using System;
using System.Collections.Generic;

namespace kkkkkk.Models;

public partial class TbHoaDonBan
{
    public string MaHoaDonBan { get; set; } = null!;

    public string MaKhachHang { get; set; } = null!;

    public DateOnly NgayBan { get; set; }

    public virtual TbKhachHang MaKhachHangNavigation { get; set; } = null!;

    public virtual ICollection<TbChiTietHdb> TbChiTietHdbs { get; set; } = new List<TbChiTietHdb>();
}
