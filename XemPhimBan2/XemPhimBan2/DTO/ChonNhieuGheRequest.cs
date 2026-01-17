namespace XemPhimBan2.DTO;

public class ChonNhieuGheRequest
{
    public int MaSuat { get; set; }
    public List<int> DsMaGhe { get; set; } = new List<int>();
    public int MaNguoiDung { get; set; }
}
