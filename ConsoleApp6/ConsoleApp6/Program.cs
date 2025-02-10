using System;
using System.Collections.Generic;

class Sach
{
    public string MaSach { get; set; }
    public string TenSach { get; set; }
    public string TenTacGia { get; set; }
    public int SoLuong { get; set; }

    public Sach(string maSach, string tenSach, string tenTacGia, int soLuong)
    {
        MaSach = maSach;
        TenSach = tenSach;
        TenTacGia = tenTacGia;
        SoLuong = soLuong;
    }
}

class SachMoi : Sach
{
    public string QrCode { get; set; }

    public SachMoi(string maSach, string tenSach, string tenTacGia, int soLuong, string qrCode)
        : base(maSach, tenSach, tenTacGia, soLuong)
    {
        QrCode = qrCode;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<SachMoi> danhSachSach = new List<SachMoi>();

        // Nhập thông tin danh sách đầu sách
        Console.Write("Nhập số lượng sách: ");
        int soLuongSach = int.Parse(Console.ReadLine());

        for (int i = 0; i < soLuongSach; i++)
        {
            Console.WriteLine($"Nhập thông tin sách thứ {i + 1}:");
            Console.Write("Mã sách: ");
            string maSach = Console.ReadLine();
            Console.Write("Tên sách: ");
            string tenSach = Console.ReadLine();
            Console.Write("Tên tác giả: ");
            string tenTacGia = Console.ReadLine();
            Console.Write("Số lượng: ");
            int soLuong = int.Parse(Console.ReadLine());
            Console.Write("QR Code: ");
            string qrCode = Console.ReadLine();

            danhSachSach.Add(new SachMoi(maSach, tenSach, tenTacGia, soLuong, qrCode));
        }

        // Kiểm tra sách có QR Code cho trước còn trong cửa hàng không
        Console.Write("Nhập QR Code cần kiểm tra: ");
        string qrCodeCanKiemTra = Console.ReadLine();

        SachMoi sachTimThay = danhSachSach.Find(sach => sach.QrCode == qrCodeCanKiemTra);

        if (sachTimThay != null)
        {
            Console.WriteLine($"Sách với QR Code {qrCodeCanKiemTra} còn trong cửa hàng.");
            Console.WriteLine($"Số lượng tồn: {sachTimThay.SoLuong}");
        }
        else
        {
            Console.WriteLine($"Sách với QR Code {qrCodeCanKiemTra} không còn trong cửa hàng.");
        }
    }
}
