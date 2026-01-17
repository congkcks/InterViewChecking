using System;
using System.Collections.Generic;

namespace XemPhimBan2.Models;

public partial class Don
{
    public int MaDon { get; set; }

    public int? MaNguoiDung { get; set; }

    public DateTime? NgayDat { get; set; }

    public decimal? TongTien { get; set; }

    public string? TrangThai { get; set; }

    public virtual Hoadon? Hoadon { get; set; }

    public virtual Taikhoan? MaNguoiDungNavigation { get; set; }

    public virtual ICollection<Ve> Ves { get; set; } = new List<Ve>();
}
