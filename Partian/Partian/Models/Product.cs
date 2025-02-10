using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection.Metadata.Ecma335;
namespace Partian.Models
{
    public class Product : ViewComponent
    {
      public IViewComponentResult Invoke()
      {
            var product = new List<SanPham>();
            product.Add(new SanPham("SP01", "Iphone 6", "600"));
            product.Add(new SanPham("SP02", "Iphone 7", "700"));
            return View<List<SanPham>>(product);
      }
    }
}
