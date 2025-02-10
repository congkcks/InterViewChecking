using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public  class BenhNhan : Nguoi
    {
        public string loaibenh;
        public BenhNhan()
        {
            loaibenh = "A";
        }
        public void Nhap()
        {
            this.hoten= Console.ReadLine();
            this.tuoi = int.Parse(Console.ReadLine());
            this.loaibenh = Console.ReadLine();
        }
        public void Xuat()
        {
            Console.WriteLine("Ho Ten: " + this.hoten);
            Console.WriteLine("Tuoi: " + this.tuoi);
            Console.WriteLine("Loai Benh: " + this.loaibenh);
        }
    }
}
