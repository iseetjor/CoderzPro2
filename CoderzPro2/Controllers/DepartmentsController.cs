using CoderzPro2.Data;
using CoderzPro2.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoderzPro2.Controllers
{
    public class DepartmentsController : Controller
    {

        private AppDbContext db;

        public DepartmentsController(AppDbContext _db)
        {
            db = _db;
        }


        public IActionResult Index()
        {
          
            return View(db.Departments);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            db.Departments.Add(department);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
