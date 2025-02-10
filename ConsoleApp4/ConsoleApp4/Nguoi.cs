using System;

public class Nguoi
{
    public string HoTen { get; set; }
    public string MaSo { get; set; }
    public int NamSinh { get; set; }
    public string GioiTinh { get; set; }

    public Nguoi(string hoTen, string maSo, int namSinh, string gioiTinh)
    {
        HoTen = hoTen;
        MaSo = maSo;
        NamSinh = namSinh;
        GioiTinh = gioiTinh;
    }

    public void HienThiThongTin()
    {
        Console.WriteLine($"Ho ten: {HoTen}");
        Console.WriteLine($"Ma so: {MaSo}");
        Console.WriteLine($"Nam sinh: {NamSinh}");
        Console.WriteLine($"Gioi tinh: {GioiTinh}");
    }
}

public class HocVien : Nguoi
{
    public int ThoiGianThamGia { get; set; } // So gio tham gia lop hoc
    public int SoLanTuongTac { get; set; } // So lan tuong tac

    public HocVien(string hoTen, string maSo, int namSinh, string gioiTinh, int thoiGianThamGia, int soLanTuongTac)
        : base(hoTen, maSo, namSinh, gioiTinh)
    {
        ThoiGianThamGia = thoiGianThamGia;
        SoLanTuongTac = soLanTuongTac;
    }

    public void HienThiThongTinHocVien()
    {
        HienThiThongTin();
        Console.WriteLine($"Thoi gian tham gia: {ThoiGianThamGia} gio");
        Console.WriteLine($"So lan tuong tac: {SoLanTuongTac}");
    }
}
