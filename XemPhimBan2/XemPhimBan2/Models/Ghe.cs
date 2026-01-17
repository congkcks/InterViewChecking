

namespace XemPhimBan2.Models;

public partial class Ghe
{
    public int MaGhe { get; set; }

    public int? MaPhong { get; set; }

    public string? HangGhe { get; set; }

    public int? CotGhe { get; set; }

    public string? LoaiGhe { get; set; }

    public decimal? GiaGhe { get; set; }

    public virtual Phong? MaPhongNavigation { get; set; }

    public virtual ICollection<Ve> Ves { get; set; } = new List<Ve>();
}
