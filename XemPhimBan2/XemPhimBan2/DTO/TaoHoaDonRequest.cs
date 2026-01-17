namespace XemPhimBan2.DTO;

public class TaoHoaDonRequest
{
    public int MaDon { get; set; }
    public string? HinhThucThanhToan { get; set; } = "Tiền mặt";
    public decimal? ThueVat { get; set; } = 0.1m; 
}
