
namespace XemPhimBan2.DTO;

public class TaoSuatChieuRequest
{
    public int MaPhim { get; set; }
    public int MaPhong { get; set; }
    public int MaCa { get; set; }    // thêm vào
    public DateOnly NgayKhoiChieuMoi { get; set; }
    public decimal GiaVe { get; set; }   // dùng khi tạo vé
}
