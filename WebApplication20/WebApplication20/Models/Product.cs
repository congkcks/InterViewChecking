using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace WebApplication20.Models
{
    // Lớp Product
    public class Product
    {
        public int ID { set; get; }
        public String Name { set; get; }
        public String Desciption { set; get; }
        public Decimal Price { set; get; } = 0;
        public Product()
        {
            ID = 0;
            Name = "";
            Desciption = "";
            Price = 0;
        }
    }

    // Lớp giả định DbContext
    public class ProductContext
    {
        public List<Product> products = new List<Product>() {
                new Product {
                    ID=1,
                    Name = "Iphone",
                    Price = 900,
                    Desciption = "Điện thoại Iphone abc, xyz ..."
                },
                new Product {
                    ID = 2,
                    Name = "Samsung",
                    Price = 800,
                    Desciption = "Điện thoại Samsung, samsung điện thoại ..."
                },
                new Product {
                    ID = 3,
                    Name = "Nokia",
                    Price = 700,
                    Desciption = "Điện thoại Nokia, điện thoại Android"
                }
            };
        public ProductContext()
        {
            // Khởi tạo một danh sách các sản phẩm mẫu

        }

        // Tìm sản phẩm theo ID
        public Product FindProductByID(int ID)
        {
            foreach (var item in products)
            {
                if (item.ID == ID)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
