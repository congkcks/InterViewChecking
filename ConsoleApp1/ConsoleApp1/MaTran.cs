using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class MaTran
    {
        private int[,] a;
        private int m, n;
        public MaTran()
        {
            m = n = 2;
            a = new int[m, n];
        }
        public void Nhap()
        {
            Console.WriteLine("Nhap so hang:");
            m = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap so cot:");
            n = int.Parse(Console.ReadLine());
            a = new int[m, n];
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                {
                    Console.WriteLine("a[{0},{1}]:", i, j);
                    a[i, j] = int.Parse(Console.ReadLine());
                }
        }
        public void In()
        {
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write("{0}\t", a[i, j]);
                Console.WriteLine();
            }
        }
        public void Cong(MaTran matran1,MaTran matran2) {
            MaTran c = new MaTran();
            c.m = matran1.m;
            c.n = matran2.n;
            c.a = new int[c.m, c.n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    c.a[i, j] = matran1.a[i, j] + matran2.a[i, j];
                }
            }
            c.In();
        }
        // Tính tích 2 ma trận
        public void Nhan(MaTran matran1, MaTran matran2)
        {
            MaTran c = new MaTran();
            c.m = matran1.m;
            c.n = matran2.n;//vd 3 4*4 5 = 3 5
            c.a = new int[c.m, c.n];
            for (int i = 0; i < matran1.m; i++)
            {
                for (int j = 0; j < matran2.n; j++)
                {
                    c.a[i, j] = 0;
                    for (int k = 0; k < matran1.n; k++)
                    {
                        c.a[i, j] += matran1.a[i, k] * matran2.a[k, j];
                    }
                }
            }
            c.In();
        }

        
        
    }
}
