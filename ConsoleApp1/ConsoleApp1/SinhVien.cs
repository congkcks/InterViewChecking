using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class SinhVien
    {
        public string MaSV { get; set; }
        public string Ten { get; set; }
        public string NamSinh { get; set; }
        public int DiemCSDL { get; set; }
        public int DiemLapTrinh { get; set; }
        public int DiemTB { get; set; }
        public SinhVien()
        {
            MaSV = "";
            Ten = "";
            NamSinh = "";
            DiemCSDL = 0;
            DiemLapTrinh = 0;
            DiemTB = 0;

        }
        public SinhVien(string maSV, string ten, string namSinh, int diemCSDL, int diemLapTrinh, int diemTB)
        {
            MaSV = maSV;
            Ten = ten;
            NamSinh = namSinh;
            DiemCSDL = diemCSDL;
            DiemLapTrinh = diemLapTrinh;
            DiemTB = diemTB;
        }
        public void Nhap()
        {
            Console.WriteLine("Nhap ma sinh vien: ");
            MaSV = Console.ReadLine();
            Console.WriteLine("Nhap ten sinh vien: ");
            Ten = Console.ReadLine();
            Console.WriteLine("Nhap nam sinh: ");
            NamSinh = Console.ReadLine();
            Console.WriteLine("Nhap diem CSDL: ");
            DiemCSDL = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap diem Lap Trinh: ");
            DiemLapTrinh = int.Parse(Console.ReadLine());
            DiemTB = (DiemCSDL + DiemLapTrinh) / 2;
        }
        public void In()
        {
            Console.WriteLine("Ma sinh vien: " + MaSV);
            Console.WriteLine("Ten sinh vien: " + Ten);
            Console.WriteLine("Nam sinh: " + NamSinh);
            Console.WriteLine("Diem CSDL: " + DiemCSDL);
            Console.WriteLine("Diem Lap Trinh: " + DiemLapTrinh);
            Console.WriteLine("Diem trung binh:  " + DiemTB);

        }
       

    }
}
      

     

   
