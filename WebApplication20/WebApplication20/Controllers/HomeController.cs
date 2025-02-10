using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication20.Models;

namespace WebApplication20.Controllers
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
            ViewBag.Title = "Home Page";
            List<Student> students = new List<Student>
                {
                    new Student(1, "John"),
                    new Student(2, "Jane"),
                    new Student(3, "Doe")
                };
            return View(students);
        }

        public IActionResult Privacy()
        {
            return View();
        }
       
        public IActionResult ViewProduct(int id)
        { 

            return View(id);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
