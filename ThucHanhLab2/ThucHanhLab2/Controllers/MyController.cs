using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;
namespace MyWebApp.Controllers
{
    [Route("MyRoute")]
    public class MyController : Controller
    {
        public IActionResult Index2(int? id, String message, int page)
        {
            //Gửi dữ liệu về View qua ViewBag
            //ViewBag là một vùng bộ nhớ chía sẻ giữa view và action
            //Hoạt động như một Collection
            if (id != null)
                ViewBag.id = id;
            ViewBag.Message = message;
            ViewBag.Date = DateTime.Now;
            ViewBag.Page = page;
            Message m = new Message(message, page); 
            return View(m);
        }
        
        [HttpGet("MyAction/Add", Name ="addget")]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost("MyAction/Add")]
        public IActionResult Add(Message model)
        {
            ViewBag.Message = model.msg;
            ViewBag.Date = DateTime.Now;
            ViewBag.Page = model.pgnum;
            Message m = new Message(model.msg, model.pgnum);
            return View("MyView", m);
        }
        [HttpPost]
        public IActionResult Index1(Message model) {
            //Gửi dữ liệu về View dùng ViewBag
            //ViewBag là một vùng bộ nhớ chia sẻ giữa view và action
            //hoạt động như một cái Dictionary            
            ViewBag.message = model.msg;
            ViewBag.pgnum = model.pgnum;
            Message m = new Message(model.msg, model.pgnum);
            return View("MyView", m);    
        }
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

    }
}
