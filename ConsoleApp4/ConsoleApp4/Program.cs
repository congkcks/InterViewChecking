using System;
class Program
{
    static void Main()
    {
        // Nhap thong tin n hoc vien cua mot buoi sinh hoat
        int n;
        do
        {
            System.Console.Write("Nhap so hoc vien: ");
        } while (!int.TryParse(System.Console.ReadLine(), out n) || n <= 0);
        HocVien[] hocViens = new HocVien[n];
        for (int i = 0; i < hocViens.Length; i++)
        {
            System.Console.WriteLine($"Nhap thong tin hoc vien thu {i + 1}");
            System.Console.Write("Ho ten: ");
            string hoTen = System.Console.ReadLine() ?? string.Empty;
            System.Console.Write("Ma so: ");
            string maSo = System.Console.ReadLine() ?? string.Empty;
            int namSinh;
            do
            {
                System.Console.Write("Nam sinh: ");
            } while (!int.TryParse(System.Console.ReadLine(), out namSinh) || namSinh <= 0);
            System.Console.Write("Gioi tinh: ");
            string gioiTinh = System.Console.ReadLine() ?? string.Empty;
            int thoiGianThamGia;
            do
            {
                System.Console.Write("Thoi gian tham gia: ");
            } while (!int.TryParse(System.Console.ReadLine(), out thoiGianThamGia) || thoiGianThamGia <= 0);
            int soLanTuongTac;
            do
            {
                System.Console.Write("So lan tuong tac: ");
            } while (!int.TryParse(System.Console.ReadLine(), out soLanTuongTac) || soLanTuongTac <= 0);
            hocViens[i] = new HocVien(hoTen, maSo, namSinh, gioiTinh, thoiGianThamGia, soLanTuongTac);
        }
        // tim nhung hoc vien tre nhat
        int minNamSinh = hocViens[0].NamSinh;
        for (int i = 1; i < hocViens.Length; i++)
        {
            if (hocViens[i].NamSinh <= minNamSinh)
            {
                minNamSinh = hocViens[i].NamSinh;
            }
        }
        System.Console.WriteLine("Nhung hoc vien tre nhat:");
        for (int i = 0; i < hocViens.Length; i++)
        {
            if (hocViens[i].NamSinh == minNamSinh)
            {
                hocViens[i].HienThiThongTinHocVien();
            }
        }
        // Sap xep hoc vien theo so lan tuong tac tang dan
        for (int i = 0; i < hocViens.Length - 1; i++)
        {
            for (int j = i + 1; j < hocViens.Length; j++)
            {
                if (hocViens[i].SoLanTuongTac > hocViens[j].SoLanTuongTac)
                {
                    HocVien temp = hocViens[i];
                    hocViens[i] = hocViens[j];
                    hocViens[j] = temp;
                }
            }
        }
        System.Console.WriteLine("Danh sach hoc vien sau khi sap xep theo so lan tuong tac tang dan:");
        for (int i = 0; i < hocViens.Length; i++)
        {
            hocViens[i].HienThiThongTinHocVien();
        }
        // Tim hoc vien Nu co so lan tuong tac nhieu nhat
        int maxSoLanTuongTac = hocViens[0].SoLanTuongTac;
        for (int i = 1; i < hocViens.Length; i++)
        {
            if (hocViens[i].SoLanTuongTac >= maxSoLanTuongTac && hocViens[i].GioiTinh == "Nu")
            {
                maxSoLanTuongTac = hocViens[i].SoLanTuongTac;
            }
        }
        System.Console.WriteLine("Hoc vien Nu co so lan tuong tac nhieu nhat:");
        for (int i = 0; i < hocViens.Length; i++)
        {
            if (hocViens[i].SoLanTuongTac == maxSoLanTuongTac && hocViens[i].GioiTinh == "Nu")
            {
                hocViens[i].HienThiThongTinHocVien();
            }
        }
    }
}
