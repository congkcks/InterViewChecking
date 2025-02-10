using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
   public class ToaDo
    {
        public double x { get; set; }
        public double y { get; set; }
        public ToaDo()
        {
            x = 0;
            y = 0;
        }
        public ToaDo(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public void Nhap()
        {
            Console.WriteLine("Nhap x:");
           x=double.Parse(Console.ReadLine());
            Console.WriteLine("Nhap y:");
           y = double.Parse(Console.ReadLine());
        }
        public void In()
        {
            Console.WriteLine("Toa do: ({0},{1})", x, y);
        }
        public void KhoangCach(ToaDo t2)
        {
            double kc=Math.Sqrt(Math.Pow(x - t2.x, 2) + Math.Pow(y - t2.y, 2));
            Console.WriteLine("Khoang cach giua 2 diem la: {0}", kc);
        }
    }
}
