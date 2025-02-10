using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApp.Data;
using MyWebApp.Models;
using System.Drawing.Printing;

namespace MyWebApp.Controllers
{
    public class DeLTController : Controller
    {
        private SchoolContext db;
        private int pageSize = 5;
        public DeLTController(SchoolContext context)
        {
            db = context;
        }
        public IActionResult Index(int? mid)
        {
            var learners = (IQueryable<Learner>)db.Learners
                    .Include(m => m.Major)
                    .OrderByDescending(l => l.EnrollmentDate)
                    .Take(10);
            if (mid != null)
            {
                learners = (IQueryable<Learner>)db.Learners
                    .Where(l => l.MajorID == mid)
                    .Include(m => m.Major)
                    .OrderByDescending(l => l.EnrollmentDate);
            }
            var result = learners.ToList();
            return View(result);
        }
        public IActionResult Index1(int? mid)
        {
            var learners = (IQueryable<Learner>)db.Learners
                    .Include(m => m.Major)
                    .OrderByDescending(l=>l.LastName)
                    .Take(10);
            if (mid != null)
            {
                learners = (IQueryable<Learner>)db.Learners
                    .Where(l => l.MajorID == mid)
                    .Include(m => m.Major)
                    .OrderByDescending(l => l.LastName)
                    .Take(10);
            }
            var result = learners.ToList();
            return View(result);
        }
        public IActionResult Index2(int? mid)
        {
            var learners = (IQueryable<Learner>)db.Learners
                    .Include(m => m.Major)
                    .OrderByDescending(l => l.Major.MajorName);
            if (mid != null)
            {
                learners = (IQueryable<Learner>)db.Learners
                    .Where(l => l.MajorID == mid)
                    .Include(m => m.Major)
                    .OrderByDescending(l => l.Major.MajorName);
            }
            //tính số trang
            int pageNum = (int)Math.Ceiling(learners.Count() / (float)pageSize);
            //trả số trang về view để hiển thị nav-trang
            ViewBag.pageNum = pageNum;
            //lấy dữ liệu trang đầu
            var result = learners.Take(pageSize).ToList();
            return View(result);
        }
        public IActionResult LearnerFilter(int? mid, int? keyword, int? pageIndex)
        {
            //lấy toàn bộ learners trong dbset chuyển về IQuerrable<Learner> để dùng Lingq
            var learners = (IQueryable<Learner>)db.Learners;
            //lấy chỉ số trang, nếu chỉ số trang null thì gán ngầm định bằng 1
            int page = (int)(pageIndex == null || pageIndex <= 0 ? 1 : pageIndex);
            //nếu có mid thì lọc learner theo mid (chuyên ngành)
            if (mid != null)
            {
                learners = learners.Where(l => l.MajorID == mid); //lọc
                ViewBag.mid = mid; //gửi mid về view để ghi lại trên nav-trang
            }
            //nếu có keyword thì tìm kiếm theo tên
            if (keyword != null)
            {
                learners = learners.Where(l => l.EnrollmentDate.Day==keyword); //tìm kiếm
                ViewBag.keyword = keyword; //gửi keyword về view để ghi lại trên nav-trang
            }
            //tính số trang
            
            //int pageNum = (int)Math.Ceiling(learners.Count() / (float)pageSize);
            //ViewBag.pageNum = pageNum; //gửi số trang về view để hiển thị nav-trang
            //chọn dữ liệu trong trang hiện tại
            //var result = learners.Skip(pageSize * (page - 1))
            //                .Take(pageSize)
            //                .Include(m => m.Major);
            var result = learners.Include(m => m.Major)
                                 .OrderBy(l => l.FirstMidName)
                                 .ToList();
            return PartialView("LearnerTable", result);
        }
    }
}
