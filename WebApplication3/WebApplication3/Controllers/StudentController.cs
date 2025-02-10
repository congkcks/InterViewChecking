using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;
        private List<Student> listStudents; // Class-level variable

        public StudentController(ILogger<StudentController> logger)
        {
            _logger = logger;
            listStudents = GetStudents(); // Initialize the listStudents variable
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Index()
        {
            // Use the class-level listStudents variable
            return View(listStudents);
        }

        [HttpGet]
        public IActionResult Create()
        {
            //lấy danh sách các giá trị Gender để hiển thị radio button trên form
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            //lấy danh sách các giá trị Branch để hiển thị select-option trên form
            //Để hiển thị select-option trên View cần dùng List<SelectListItem>
            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem { Text = "IT", Value = "1" },
                new SelectListItem { Text = "BE", Value = "2" },
                new SelectListItem { Text = "CE", Value = "3" },
                new SelectListItem { Text = "EE", Value = "4" }
            };
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student s)
        {

            if (ModelState.IsValid) { 
               s.Id=listStudents.Last<Student>().Id+1;
                listStudents.Add(s);
                return View("Index",listStudents);
            }
            AddErrorsFromModel(ModelState.Values);

            return View();
        }

        private void AddErrorsFromModel(ModelStateDictionary.ValueEnumerable values)
        {
            throw new NotImplementedException();
        }

        private List<Student> GetStudents()
        {
            // Retrieve the list of students from the database or any other data source
            //Tạo danh sách sinh viên với 4 dữ liệu mẫu
            return new List<Student>()
            {
                new Student() { Id = 101, Name = "Hải Nam", Branch = Branch.IT,
                    Gender = Gender.Male, IsRegular=true,
                    Address = "A1-2018", Email = "nam@g.com" },
                new Student() { Id = 102, Name = "Minh Tú", Branch = Branch.BE,
                    Gender = Gender.Female, IsRegular=true,
                    Address = "A1-2019", Email = "tu@g.com" },
                new Student() { Id = 103, Name = "Hoàng Phong", Branch = Branch.CE,
                    Gender = Gender.Male, IsRegular=false,
                    Address = "A1-2020", Email = "phong@g.com" },
                new Student() { Id = 104, Name = "Xuân Mai", Branch = Branch.EE,
                    Gender = Gender.Female, IsRegular = false,
                    Address = "A1-2021", Email = "mai@g.com" }
            };
        }
    }
}
