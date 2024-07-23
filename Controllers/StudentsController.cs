using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Beltek.Finish.Project.Database;
using Beltek.Finish.Project.Models;
using System.Collections.Generic;

namespace Beltek.Finish.Project.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Index()
        {
            using (var context = new DbContextStudents())
            {
                var lst = context.Students.Include(x => x.Class).ToList();
                return View(lst);
            }
            //var lst = new Student().GetAll();
            //return View(lst);
        }


        [HttpPost]
        public IActionResult AddStudent(Student stdnt)
        {
            using (var ctx = new DbContextStudents())
            {
                var quota = ctx.Classes.Find(stdnt.ClassId).ClassQuota;
                var mevcutOgrenci =ctx.Students.Count(x => x.ClassId == stdnt.ClassId);
                if (mevcutOgrenci < quota)
                {
                    ctx.Students.Add(stdnt);
                    ctx.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.Clear();
                    ModelState.AddModelError("", "Kontenjan dolu");                    
                    var list = ctx.Classes.ToList();
                    foreach (var c in list)
                        stdnt.classList.Add(new SelectListItem(c.ClassName, c.ClassId.ToString()));
                    return View(stdnt);
                }                
            }

        }
        [HttpGet]
        public IActionResult AddStudent()
        {

            using (var ctx = new DbContextStudents())
            {                
                var model = new Student();
                var list = ctx.Classes.ToList();
                foreach (var c in list)
                    model.classList.Add(new SelectListItem(c.ClassName, c.ClassId.ToString()));

                return View(model);

            }

        }

        [HttpGet]
        public IActionResult EditStudent(int id)
        {

            using (var ctx = new DbContextStudents())
            {
                var list = ctx.Classes.ToList();
                var student = ctx.Students.Find(id);
                foreach (var c in list)
                    student.classList.Add(new SelectListItem(c.ClassName, c.ClassId.ToString()));
                return View(student);
            }

        }
        [HttpPost]
        public IActionResult EditStudent(Student student)
        {
            using (var ctx = new DbContextStudents())
            {
                ctx.Entry(student).State = EntityState.Modified;
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }


        }
        public IActionResult DeleteStudent(int id)
        {
            using (var ctx = new DbContextStudents())
            {
                ctx.Students.Remove(ctx.Students.Find(id));
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }

        }

        #region otomatik olusturulan
        //// GET: Students/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.Students == null)
        //    {
        //        return NotFound();
        //    }

        //    var student = await _context.Students
        //        .Include(s => s.Class)
        //        .FirstOrDefaultAsync(m => m.StudentId == id);
        //    if (student == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(student);
        //}




        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("StudentId,StudentName,StudentSurname,StudentNumber,ClassId")] Student student)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(student);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "ClassName", student.ClassId);
        //    return View(student);
        //}

        //// GET: Students/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Students == null)
        //    {
        //        return NotFound();
        //    }

        //    var student = await _context.Students.FindAsync(id);
        //    if (student == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "ClassName", student.ClassId);
        //    return View(student);
        //}

        //// POST: Students/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("StudentId,StudentName,StudentSurname,StudentNumber,ClassId")] Student student)
        //{
        //    if (id != student.StudentId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(student);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!StudentExists(student.StudentId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "ClassName", student.ClassId);
        //    return View(student);
        //}

        //// GET: Students/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Students == null)
        //    {
        //        return NotFound();
        //    }

        //    var student = await _context.Students
        //        .Include(s => s.Class)
        //        .FirstOrDefaultAsync(m => m.StudentId == id);
        //    if (student == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(student);
        //}

        //// POST: Students/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Students == null)
        //    {
        //        return Problem("Entity set 'DbContextStudents.Students'  is null.");
        //    }
        //    var student = await _context.Students.FindAsync(id);
        //    if (student != null)
        //    {
        //        _context.Students.Remove(student);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool StudentExists(int id)
        //{
        //  return (_context.Students?.Any(e => e.StudentId == id)).GetValueOrDefault();
        //} 
        #endregion
    }
}
