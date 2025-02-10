using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapTuan
{
   public  class Bai5
    {
        //Viết chương trình nhập vào từ bàn phím dãy gồm N số nguyên. Sắp xếp
        //dãy theo chiều tăng dần và in kết quả ra màn hình.
        public static void SapXepDaySo()
        {
            Console.WriteLine("Nhap so phan tu cua day: ");
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Nhap phan tu thu " + i + ": ");
                arr[i] = int.Parse(Console.ReadLine());
            }
            Array.Sort(arr);
            Console.WriteLine("Day so sau khi sap xep la: ");
            for (int i = 0; i < n; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }
    }
}
