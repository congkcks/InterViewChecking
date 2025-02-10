using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class DanhSach
    {
        private List<SinhVien> ds;
        private int soluong;
        public DanhSach()
        {
            ds= new List<SinhVien>();
            soluong = 0;
        }
        public void Nhap()
        {
            Console.WriteLine("Nhap so luong sinh vien:");
            soluong = int.Parse(Console.ReadLine());
            for (int i = 0; i < soluong; i++)
            {
                SinhVien sv = new SinhVien();
                sv.Nhap();
                ds.Add(sv);
            }
        }
        public void InDS()
        {
            foreach (SinhVien sv in ds)
            {
                sv.In();
            }
        }
        public void LietKe()
        {

           foreach (SinhVien sv in ds)
            {
                if (sv.DiemTB >= 8)
                {
                    sv.In();
                }
            }
        }
        public void SapXep()
        {
            ds.Sort((sv1,sv2)=>sv1.MaSV.CompareTo(sv2.MaSV));

        }
    }

}
