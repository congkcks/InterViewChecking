using De5.Models;

namespace De5.IRepository
{
	public interface IRepository
	{
		List<Product> GetProducts();
		Product GetProduct(int id);
		List<Category> GetCategories();
		Category GetCategory(int id);


	}
}
