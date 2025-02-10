using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapTuan
{
    public class Bai3
    {
        //. Viết chương trình nhập vào từ bàn phím một số nguyên dương N. Kiểm tra
        //xem số đó có phải số nguyên tố hay không? In kết quả ra màn hình.
        public static void KiemTraSoNguyenTo()
        {
            Console.WriteLine("Nhap so nguyen duong N: ");
            int n = int.Parse(Console.ReadLine());
            if (n < 2)
            {
                Console.WriteLine(n + " khong phai la so nguyen to");
            }
            else
            {
                bool check = true;
                for (int i = 2; i <= Math.Sqrt(n); i++)
                {
                    if (n % i == 0)
                    {
                        check = false;
                        break;
                    }
                }
                if (check)
                {
                    Console.WriteLine(n + " la so nguyen to");
                }
                else
                {
                    Console.WriteLine(n + " khong phai la so nguyen to");
                }
            }
        }
    }
}
