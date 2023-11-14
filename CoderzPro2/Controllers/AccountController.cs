using CoderzPro2.Data;
using CoderzPro2.Models;
using CoderzPro2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoderzPro2.Controllers
{
    public class AccountController : Controller
    {

        private AppDbContext db;

        public AccountController(AppDbContext _db)
        {
            db = _db;
        }
        public IActionResult Register()
        {
            ViewBag.Roles = new SelectList(db.Roles, "RoleId", "RoleName");
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            
            if (ModelState.IsValid) 
            {
                User user = new User 
                {
                Email = model.Email,
                Password = model.Password,
                FullName=model.FullName,
                RoleId = model.RoleId,
                UserName = model.UserName,
                IsActive=true,
                IsDeleted=false
                };
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            ViewBag.Roles = new SelectList(db.Roles, "RoleId", "RoleName");
            return View(model);
        
        }
    }
}
