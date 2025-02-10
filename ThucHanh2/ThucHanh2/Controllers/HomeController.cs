using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ThucHanh2.Models;

namespace ThucHanh2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            var lop = new[] {
               new { MaLop = "CTK43", TenLop = "Kỹ thuật phần mềm" },
               new { MaLop = "CTK44", TenLop = "Kỹ thuật phần mềm" },
            };
            return Content(lop[0].MaLop);

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
