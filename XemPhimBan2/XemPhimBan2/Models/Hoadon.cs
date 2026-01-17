

namespace XemPhimBan2.Models;

public partial class Hoadon
{
    public int MaHoaDon { get; set; }

    public int? MaDon { get; set; }

    public DateTime? NgayXuat { get; set; }

    public decimal? TongTien { get; set; }

    public decimal? ThueVat { get; set; }

    public string? HinhThucThanhToan { get; set; }

    public string? TrangThaiHoaDon { get; set; }

    public virtual ICollection<Chitiethoadon> Chitiethoadons { get; set; } = new List<Chitiethoadon>();

    public virtual Don? MaDonNavigation { get; set; }
}
