using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication10.Pages
{
    public class PadelModel : PageModel
    {
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                ViewData["Title"] = "ViewProduct";
            }
            else
            {
                ViewData["Title"] = "Page " + id.ToString();
            }

            return Page();
        }
    }
}
