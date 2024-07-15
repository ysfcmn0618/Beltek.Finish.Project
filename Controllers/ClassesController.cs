using Beltek.Finish.Project.Database;
using Beltek.Finish.Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Beltek.Finish.Project.Controllers
{
    public class ClassesController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            using (var context = new DbContextStudents())
            {
                var lst = context.Classes.ToList();
                return View(lst);
            }
        }
        [HttpPost]
        public IActionResult AddClass(Class cls) {
            using (var ctx= new DbContextStudents())
            {               
                ctx.Classes.Add(cls);
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }       

        }
        [HttpGet]
        public ViewResult AddClass()
        {
            return View();
        }

        public ViewResult EditClass(int id)
        {
            using (var ctx = new DbContextStudents())
            {
                var cls = ctx.Classes.Find(id);
                return View(cls);
            }
        }

        [HttpPost]
        public IActionResult EditClass(Class cls)
        {
            using (var ctx = new DbContextStudents())
            {
                ctx.Entry(cls).State = EntityState.Modified;
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        
        public IActionResult DeleteClass(int id) {
            using (var ctx = new DbContextStudents())
            {
                ctx.Classes.Remove(ctx.Classes.Find(id));
                ctx.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
