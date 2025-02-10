using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebApplication10.Models
{
    public class ProDuct : PageModel
    {
        private readonly ILogger<ProDuct> _logger;

        public ProDuct(ILogger<ProDuct> logger)
        {
            _logger = logger;
        }

        public void OnGet(int? id)
        {
            if (id.HasValue)
            {
                ViewData["Title"] = $"Day la Trang Thu {id.Value}";
            }
            else
            {
                ViewData["Title"] = "Product";
            }
        }
    }
}
