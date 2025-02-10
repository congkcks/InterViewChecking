using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationditme.Models;

namespace WebApplicationditme.Controllers
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
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

                // Kiểm tra và tạo thư mục nếu chưa tồn tại
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                var filePath = Path.Combine(directoryPath, file.FileName);
                var relativePath = "/images/" + file.FileName; // Đường dẫn tương đối

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                ViewBag.Message = "Upload successful!";
                ViewBag.FilePath = relativePath; // Lưu đường dẫn tương đối vào ViewBag
            }
            else
            {
                ViewBag.Message = "Upload failed!";
                ViewBag.FilePath = string.Empty;
            }

            return View("Index");
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
