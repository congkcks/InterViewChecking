using System;

namespace ConsoleApp5
{
    public class Nguoi
    {
        public string Hoten { get; set; } = string.Empty;
        public int Tuoi { get; set; }

        public virtual void Nhap()
        {
            Console.Write("Nhap ho ten: ");
            Hoten = Console.ReadLine() ?? string.Empty;
            Console.Write("Nhap tuoi: ");
            int tuoi;
            while (!int.TryParse(Console.ReadLine(), out tuoi))
            {
                Console.Write("Tuoi khong hop le. Vui long nhap lai: ");
            }
            Tuoi = tuoi;
        }

        public virtual void Xuat()
        {
            Console.WriteLine($"Ho ten: {Hoten}, Tuoi: {Tuoi}");
        }
    }

    public class BenhNhan : Nguoi
    {
        public string Loaibenh { get; set; } = string.Empty;

        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhap loai benh (A, B, C): ");
            Loaibenh = Console.ReadLine() ?? string.Empty;
            while (Loaibenh != "A" && Loaibenh != "B" && Loaibenh != "C")
            {
                Console.Write("Loai benh khong hop le. Vui long nhap lai (A, B, C): ");
                Loaibenh = Console.ReadLine() ?? string.Empty;
            }
        }

        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine($"Loai benh: {Loaibenh}");
        }
    }

    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Nhap So Benh Nhan");
            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input) || !int.TryParse(input, out int n))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return;
            }

            BenhNhan[] bn = new BenhNhan[20];
            for (int i = 0; i < n; i++)
            {
                bn[i] = new BenhNhan(); // Ensure the array elements are initialized
                bn[i].Nhap();
            }

            // thống kê sô bệnh nhân của mỗi loại bệnh biết chỉ có 3 loại bệnh A,B,C
            int[] count = new int[3];
            for (int i = 0; i < n; i++)
            {
                if (bn[i].Loaibenh == "A")
                {
                    count[0]++;
                }
                else if (bn[i].Loaibenh == "B")
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

            // tim benh nhan co tuoi nho nhat cua loai benh A
            int min = int.MaxValue;
            BenhNhan? ittuoi = null;
            for (int i = 0; i < n; i++)
            {
                if (bn[i].Loaibenh == "A")
                {
                    if (bn[i].Tuoi < min)
                    {
                        min = bn[i].Tuoi;
                        ittuoi = bn[i];
                    }
                }
            }

            if (ittuoi != null)
            {
                Console.WriteLine("Benh Nhan Co Tuoi Nho Nhat Cua Loai Benh A");
                ittuoi.Xuat();
            }
            else
            {
                Console.WriteLine("Khong co benh nhan loai A.");
            }
        }
    }
}
