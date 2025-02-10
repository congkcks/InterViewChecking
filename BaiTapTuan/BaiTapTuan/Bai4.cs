using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapTuan
{
    public class Bai4
    {

        //Viết chương trình nhập vào từ bàn phím số nguyên dương N. Kiểm tra số
       // đó có phải số hoàn hảo hay không? In kết quả ra màn hình.VD: 6 là số hoàn hảo
        //(vì 6=1+2+3)
        public static void KiemTraSoHoanHao()
        {
            Console.WriteLine("Nhap so nguyen duong N: ");
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 1; i < n; i++)
            {
                if (n % i == 0)
                {
                    sum += i;
                }
            }
            if (sum == n)
            {
                Console.WriteLine(n + " la so hoan hao");
            }
            else
            {
                Console.WriteLine(n + " khong phai la so hoan hao");
            }
        }
        
    }
}
