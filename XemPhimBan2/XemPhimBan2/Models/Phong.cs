

namespace XemPhimBan2.Models;

public partial class Phong
{
    public int MaPhong { get; set; }

    public string? TenPhong { get; set; }

    public int? TongSoGhe { get; set; }

    public virtual ICollection<Ghe> Ghes { get; set; } = new List<Ghe>();

    public virtual ICollection<Suatchieu> Suatchieus { get; set; } = new List<Suatchieu>();
}
