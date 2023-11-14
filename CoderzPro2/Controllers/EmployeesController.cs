using CoderzPro2.Data;
using CoderzPro2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CoderzPro2.Controllers
{
    public class EmployeesController : Controller
    {

        private AppDbContext db;

        public EmployeesController(AppDbContext _db)
        {
            db = _db;
        }

        public IActionResult Index()
        {
            ViewBag.del = db.Employees.Where(x => x.IsDeleted == true).Count();
            return View(db.Employees.Include(x=>x.Department).
                Where(x => x.IsDeleted == false));
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.GetAllDepartments = 
                new SelectList(db.Departments, "DepartmentId", "Name");
            return View();
        }


        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var emp = db.Employees.Find(id);
            if (emp == null)
            {
                return RedirectToAction("Index");
            }

            return View(emp);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var emp = db.Employees.Find(id);
            if (emp == null)
            {
                return RedirectToAction("Index");
            }

            return View(emp);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            db.Employees.Update(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var emp = db.Employees.Find(id);
            if (emp == null)
            {
                return RedirectToAction("Index");
            }

            return View(emp);
        }

        [HttpPost]
        public IActionResult Delete(Employee employee)
        {
            if (!db.Employees.Any())
            {
                return RedirectToAction("Index");
            }

            var user = db.Employees.Find(employee.EmployeeId);
            if (user == null) { return RedirectToAction("Index"); }
            db.Employees.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult SoftDelete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var emp = db.Employees.Find(id);
            if (emp == null)
            {
                return RedirectToAction("Index");
            }

            return View(emp);
        }


        [HttpPost]
        public IActionResult SoftDelete(Employee employee)
        {
            if (!db.Employees.Any())
            {
                return RedirectToAction("Index");
            }
            var user = db.Employees.Find(employee.EmployeeId);
            user!.IsDeleted = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeletedEmployeesList()
        {
            return View(db.Employees.Where(x => x.IsDeleted == true));
        }
        public IActionResult RestoreEmployee(int id)
        {
            var user = db.Employees.Find(id);
            user!.IsDeleted = false;
            db.SaveChanges();
            return RedirectToAction("Index");  
        }

    }
}
