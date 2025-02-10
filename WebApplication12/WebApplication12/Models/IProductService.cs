// IProductService.cs
using WebApplication12.Models;

namespace WebApplication12.Services
{
    public interface IProductService
    {
        object GetDataById(int id);
    }
}
// ProductService.cs
namespace WebApplication12.Services
{
    public class ProductService : IProductService
    {
        public object GetDataById(int id)
        {
            // Implement your logic to get data by id
            // Ensure that the returned data is not null
            return new Lop(id, "Day la Trang Thu id");
        }
    }
}
