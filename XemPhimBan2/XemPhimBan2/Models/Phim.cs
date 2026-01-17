

namespace XemPhimBan2.Models;

public partial class Phim
{
    public int MaPhim { get; set; }

    public string TenPhim { get; set; } = null!;

    public string? TheLoai { get; set; }

    public int? ThoiLuong { get; set; }

    public string? NgonNgu { get; set; }

    public string? QuocGia { get; set; }

    public DateOnly? NgayKhoiChieu { get; set; }

    public string? MoTa { get; set; }

    public virtual ICollection<Suatchieu> Suatchieus { get; set; } = new List<Suatchieu>();
}
