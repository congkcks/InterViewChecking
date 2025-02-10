using De5.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
namespace De5.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly Repository _Db;

		public HomeController(ILogger<HomeController> logger,Repository db)
		{
			_logger = logger;
			_Db = db;
		}

		public IActionResult Index()
		{
			var catagogies = _Db.GetCategories();
			ViewBag.Categories = catagogies;
			var products = _Db.GetProductsBy();
			ViewBag.Products = products;
			return View(products);
		}
		[HttpGet]
		public IActionResult ProductByCategory(int id)
		{
		    var catagogies = _Db.GetProductsByCategory(id);
			return PartialView("SanPham",catagogies);
		}
		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
