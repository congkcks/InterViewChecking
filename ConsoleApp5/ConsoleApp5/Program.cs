using System;



namespace ConsoleApp5
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Nhap So Benh Nhan");
            int n = int.Parse(Console.ReadLine());
            BenhNhan[] bn = new BenhNhan[n];
            for (int i = 0; i < n; i++)
            {
                bn[i]=new BenhNhan();
                bn[i].Nhap();
            }
            //thống kê sô bệnh nhân của mỗi loại bệnh biết chỉ có 3 loại bệnh A,B,C
            int[] count = new int[3];
            for (int i = 0; i < n; i++)
            {
                if (bn[i].loaibenh == "A")
                {
                    count[0]++;
                }
                else if (bn[i].loaibenh == "B")
                {
                    count[1]++;
                }
                else
                {
                    count[2]++;
                }
            }
            Console.WriteLine("So Benh Nhan Loai A: " + count[0]);
            Console.WriteLine("So Benh Nhan Loai B: " + count[1]);
            Console.WriteLine("So Benh Nhan Loai C: " + count[2]);
            //tim benh nhan co tuoi nho nhat cua loai benh A
            int min = 10000;
            BenhNhan ittuoi = new BenhNhan();
            for (int i = 0; i < n; i++)
            {
                if (bn[i].loaibenh == "A")
                {
                    if (bn[i].tuoi < min)
                    {
                        min = bn[i].tuoi;
                        ittuoi=bn[i];
                    }
                }
            }
            Console.WriteLine("Benh Nhan Co Tuoi Nho Nhat Cua Loai Benh A La:");
            ittuoi.Xuat();

        }
    }
}