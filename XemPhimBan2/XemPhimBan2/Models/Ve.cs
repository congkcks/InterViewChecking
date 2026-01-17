

namespace XemPhimBan2.Models;

public partial class Ve
{
    public int MaVe { get; set; }

    public int? MaDon { get; set; }

    public int? MaSuat { get; set; }

    public int? MaGhe { get; set; }

    public decimal? GiaVe { get; set; }

    public virtual ICollection<Chitiethoadon> Chitiethoadons { get; set; } = new List<Chitiethoadon>();

    public virtual Don? MaDonNavigation { get; set; }

    public virtual Ghe? MaGheNavigation { get; set; }

    public virtual Suatchieu? MaSuatNavigation { get; set; }
}
