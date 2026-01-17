namespace XemPhimBan2.DTO;
    public class TaoPhongRequest
    {
        public string TenPhong { get; set; }          // Tên phòng, VD: "Phòng 2"
        public int SoHang { get; set; }               // Số hàng ghế (A, B, C…)
        public int SoCot { get; set; }                // Số cột ghế (1..n)
        public string LoaiGheMacDinh { get; set; }    // THUONG / VIP / COUPLE
        public decimal GiaMacDinh { get; set; }       // Giá ghế mặc định
    }
