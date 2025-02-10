using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapTuan
{
    public class Bai6
    {
        // Viết chương trình nhập vào từ bàn phím dãy điểm. Tính độ dài đường gấp
        //khúc lần lượt đi qua các điểm thứ 1,2,..n..
        public static void TinhDoDaiDuongGapKhuc()
        {
            Console.WriteLine("Nhap so diem: ");
            int n = int.Parse(Console.ReadLine());
            double[] x = new double[n];
            double[] y = new double[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Nhap toa do x cua diem thu " + i + ": ");
                x[i] = double.Parse(Console.ReadLine());
                Console.WriteLine("Nhap toa do y cua diem thu " + i + ": ");
                y[i] = double.Parse(Console.ReadLine());
            }
            double sum = 0;
            for (int i = 0; i < n - 1; i++)
            {
                sum += Math.Sqrt(Math.Pow(x[i + 1] - x[i], 2) + Math.Pow(y[i + 1] - y[i], 2));
            }
            Console.WriteLine("Do dai duong gap khuc la: " + sum);
        }

    }
}
