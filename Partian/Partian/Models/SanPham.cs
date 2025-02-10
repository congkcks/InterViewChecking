namespace Partian.Models
{
    public class SanPham
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string giaca { get; set; }
        public SanPham(string MaSP, string TenSP, string giaca)
        {
            this.MaSP = MaSP;
            this.TenSP = TenSP;
            this.giaca = giaca;
        }
    }
}
