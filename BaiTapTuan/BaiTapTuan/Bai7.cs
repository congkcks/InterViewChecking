using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapTuan
{
    public class Bai7
    {
        //Viết chương trình nhập vào từ bàn phím dãy gồm N số thực
        // - Tính tổng dãy
        ///  Tính tổng các phần tử nằm trong đoạn[0, 100]
        // Tìm giá trị lớn nhất(nhỏ nhất)của dãy
        // Đếm số phần tử nhỏ hơn không hoặc lớn hơn 100

        public static void TinhTongDay()
        {
            Console.WriteLine("Nhap so phan tu cua day: ");
            int n = int.Parse(Console.ReadLine());
            double[] arr = new double[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Nhap phan tu thu " + i + ": ");
                arr[i] = double.Parse(Console.ReadLine());
            }
            double sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += arr[i];
            }
            Console.WriteLine("Tong day la: " + sum);
        }

        public static void TinhTongDayTrongDoan()
        {
            Console.WriteLine("Nhap so phan tu cua day: ");
            int n = int.Parse(Console.ReadLine());
            double[] arr = new double[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Nhap phan tu thu " + i + ": ");
                arr[i] = double.Parse(Console.ReadLine());
            }
            double sum = 0;
            for (int i = 0; i < n; i++)
            {
                if (arr[i] >= 0 && arr[i] <= 100)
                {
                    sum += arr[i];
                }
            }
            Console.WriteLine("Tong cac phan tu nam trong doan [0, 100] la: " + sum);
        }

        public static void TimMaxMin()
        {
            Console.WriteLine("Nhap so phan tu cua day: ");
            int n = int.Parse(Console.ReadLine());
            double[] arr = new double[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Nhap phan tu thu " + i + ": ");
                arr[i] = double.Parse(Console.ReadLine());
            }
            double max = arr[0];
            double min = arr[0];
            for (int i = 1; i < n; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
                if (arr[i] < min)
                {
                    min = arr[i];
                }
            }
            Console.WriteLine("Gia tri lon nhat cua day la: " + max);
            Console.WriteLine("Gia tri nho nhat cua day la: " + min);
        }
    }
}
