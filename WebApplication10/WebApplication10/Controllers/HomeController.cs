using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using WebApplication10.Models;

namespace WebApplication10.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILogger<ProDuct> _productLogger;

        public HomeController(ILogger<HomeController> logger, ILogger<ProDuct> productLogger)
        {
            _logger = logger;
            _productLogger = productLogger;
        }

        public IActionResult ViewProduct(int? id)
        {
            if (id == null)
            {
               ViewData["Title"] = "Product";
                return View();
            }
            ViewData["Title"] = $"Day la Trang Thu {id.Value}";
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
    }
}
