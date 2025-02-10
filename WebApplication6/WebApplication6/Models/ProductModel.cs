namespace WebApplication6.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }
        public ProductModel()
        {
            Id = 0;
            Name = string.Empty;
            Brand = string.Empty;
            Price = 0;
        }
    }

}
