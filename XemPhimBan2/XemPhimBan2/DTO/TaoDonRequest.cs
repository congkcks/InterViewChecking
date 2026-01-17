namespace XemPhimBan2.DTO;

public class TaoDonRequest
{
    public int MaNguoiDung { get; set; }
    public List<int> DsMaVe { get; set; } = new List<int>();
}
