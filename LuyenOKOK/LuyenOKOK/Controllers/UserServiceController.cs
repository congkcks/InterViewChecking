using Microsoft.AspNetCore.Mvc;

namespace LuyenOKOK.Controllers;

public class UserServiceController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
