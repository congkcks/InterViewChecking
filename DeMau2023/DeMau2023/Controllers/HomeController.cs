using DeMau2023.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace DeMau2023.Controllers
{
    public class HomeController : Controller
    {
		private readonly ILogger<HomeController> _logger;
		private readonly QlhangHoaContext _context;

		public HomeController(ILogger<HomeController> logger, QlhangHoaContext context)
		{
			_logger = logger; // Gán logger vào trường _logger
			_context = context; // Gán context vào trường _context
		}

		public IActionResult Index()
        {
            var hanghoa=_context.LoaiHangs.ToList();
            ViewBag.HangHoa=hanghoa;
            var loadhanghoa=(from h in _context.HangHoas
                            where h.Gia>=100
                            select h).ToList();
            ViewBag.Bai1 = loadhanghoa;
            return View();
        }
        [HttpGet]
        public IActionResult DangKi()
        {
			var hanghoa = _context.LoaiHangs.ToList();
			ViewBag.HangHoa = hanghoa;
            var malooai=(from p in _context.LoaiHangs
                        select p.MaLoai).ToList();
            var theselect=malooai.Select(p=>new SelectListItem
            {
                Value=p.ToString(),
                Text=p.ToString()
            }).ToList();
            ViewBag.MaLoai = theselect;
			return View();
        }
        [HttpPost]
        public IActionResult DangKi(HangHoa hangHoa)
        {
            _context.HangHoas.Add(hangHoa);
            _context.SaveChanges();
            return RedirectToAction("Index","Home");
        }
        public IActionResult PhanLoaiHang(string tenloai)
        {
			int maloai = _context.LoaiHangs
					 .Where(p => p.TenLoai == tenloai)
					 .Select(p => p.MaLoai)  // Lấy Id của LoaiHang
					 .FirstOrDefault();
			var fullhanghoa =(from sp in _context.HangHoas
                            where sp.MaLoai==maloai
                            select sp).ToList();
            return Json(fullhanghoa);
        }
        public IActionResult TimKiem(string key)
        {
            var hanghoa=_context.HangHoas.Where(p=>p.TenHang.Contains(key)).ToList();
            return Json(hanghoa);
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
