using System;
using System.Collections.Generic;

namespace XemPhimBan2.Models;

public partial class Suatchieu
{
    public int MaSuat { get; set; }

    public int? MaPhim { get; set; }

    public int? MaPhong { get; set; }

    public int? MaCa { get; set; }

    public DateOnly? NgayChieu { get; set; }

    public decimal? GiaSuat { get; set; }

    public virtual Cachieu? MaCaNavigation { get; set; }

    public virtual Phim? MaPhimNavigation { get; set; }

    public virtual Phong? MaPhongNavigation { get; set; }

    public virtual ICollection<Ve> Ves { get; set; } = new List<Ve>();
}
