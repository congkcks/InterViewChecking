

namespace XemPhimBan2.Models;

public partial class Chitiethoadon
{
    public int MaCthd { get; set; }

    public int MaHoaDon { get; set; }

    public int MaVe { get; set; }

    public decimal? DonGia { get; set; }

    public int? SoLuong { get; set; }

    public decimal? ThanhTien { get; set; }

    public virtual Hoadon MaHoaDonNavigation { get; set; } = null!;

    public virtual Ve MaVeNavigation { get; set; } = null!;
}
