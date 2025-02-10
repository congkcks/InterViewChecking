using CSDl.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CSDl.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SchoolContext _context;

        public HomeController(ILogger<HomeController> logger, SchoolContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var dulieu = _context.Learners.ToList();
            return View(dulieu);
        }

        public IActionResult Privacy()
        {
            var dulieu = _context.Learners.FirstOrDefault();
            if(dulieu != null)
            {
                dulieu.LastName = "Nguyen Van A";
                _context.SaveChanges();
                return View(dulieu);
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
