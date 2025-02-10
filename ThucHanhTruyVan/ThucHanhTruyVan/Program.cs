using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ThucHanhTruyVan.Models;
public class Program
{
    public static void Main()
    {
        Bt1csdlContext db = new Bt1csdlContext();
        var ketqua = (from s in db.TSaches
                     orderby s.MaSach descending
                     select s).Take(3);
        foreach (var item in ketqua)
        {
            Console.WriteLine(item.MaSach);
        }
    }
}