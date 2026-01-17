
namespace XemPhimBan2.DTO;

public class CapNhatSuatChieuRequest
{
    public int MaSuat { get; set; }

    public int? MaPhim { get; set; }
    public int? MaPhong { get; set; }
    public int? MaCa { get; set; }
    public DateOnly? NgayChieu { get; set; }
    public decimal? GiaSuat { get; set; }
}


