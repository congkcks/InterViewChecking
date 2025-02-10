using System;

public class Mang
{
    private int[] arr;
    private int n;
    public Mang()
    {
        n = 0;
        arr = new int[100];
    }
    public void Nhap()
    {

        Console.Write("Nhap so phan tu: ");
        n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Console.Write("arr[" + i + "] = ");
            arr[i] = int.Parse(Console.ReadLine());
        }
    }
    public void Xuat()
    {
        for (int i = 0; i < n; i++)
        {
            Console.Write(arr[i] + " ");
        }
    }
    public void SapXep()
    {
        Array.Sort(arr, 0, n);
    }
    public void TimKiem()
    {
        int x = int.Parse(Console.ReadLine());
        if (Array.FindAll(arr, e => e == x).Length > 0)
        {
            Console.WriteLine("Co");
        }
        else
        {
            Console.WriteLine("Khong");
        }
    }
}
public class Program
{
    public delegate void In();
    public static void In1(){
        Console.WriteLine("Hello");
    }
    public static void Main()
    {
         In in1= new In(In1);
        in1();
        
       
    }
}
