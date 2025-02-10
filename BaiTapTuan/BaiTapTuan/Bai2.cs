using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapTuan
{
    public  class Bai2
    {
        //Viết chương trình giải và biện luận phương trình bậc 2: ax2 + bx + c = 0,
        //trong đó các hệ số a, b, c ∈ R
        public static void GiaiPhuongTrinhBac2()
        {
            Console.WriteLine("Nhap a: ");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Nhap b: ");
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine("Nhap c: ");
            double c = double.Parse(Console.ReadLine());
            double delta = b * b - 4 * a * c;
            if (delta < 0)
            {
                Console.WriteLine("Phuong trinh vo nghiem");
            }
            else if (delta == 0)
            {
                double x = -b / (2 * a);
                Console.WriteLine("Phuong trinh co nghiem kep x1 = x2 = " + x);
            }
            else
            {
                double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                Console.WriteLine("Phuong trinh co 2 nghiem phan biet x1 = " + x1 + " va x2 = " + x2);
            }
        }
    }
}
