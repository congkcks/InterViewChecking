using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationDauMoi.Models;

namespace WebApplicationDauMoi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int id)
        {
            List<Sv> lists= new List<Sv>();
            lists.Add(new Sv("1", "Dao Tuan Anh"));
            lists.Add(new Sv("2", "Le Xuan Bao Anh"));
            Sv a = new Sv("3", "4");
            return View(a);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [Route("daubuoi/ditbano/{id:int}")]
        public IActionResult Trang2(int id)
        {
            var bien = new[] {
                new { id = 1, name = "Dao Tuan Anh" },
                new { id = 2, name = "Le Xuan Bao Anh" }
            };
            if(id == 1)
            {
               ViewBag.bien = bien[0];
                return View();
            }
            if(id == 2)
            {
                ViewBag.bien = bien[1];
                return View();
            }
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
