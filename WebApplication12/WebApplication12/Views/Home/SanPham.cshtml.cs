using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WebApplication12.Services;

namespace RazorPagesIntro.Pages
{
    public class SanPham : PageModel
    {
        private readonly ILogger<SanPham> _logger;
        private readonly IProductService _productService;

        public SanPham(ILogger<SanPham> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public void OnGet()
        {
            int id = Convert.ToInt32(Request.RouteValues["id"]);
            // Retrieve data based on the id from the URL
            var data = _productService.GetDataById(id);
            if (data == null)
            {
                ViewData["Title"] = $"{id}";
            }
            ViewData["Title"] = $"Day La Trang Thu ";

        }

    }
}
