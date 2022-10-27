using NguyenVanToanBTH2.Data;
using NguyenVanToanBTH2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace NguyenVanToanBTH2.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _context.Students.ToListAsync();
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Student std)
        {
            if(ModelState.IsValid)
            {
                _context.Add(std);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(std);
        }

        private bool StudentExists(string Id)
        {
            return _context.Student.Any(e => e.StudentId == Id);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Student = await _context.Student.FindAsync(id);
            if (Student == null)
            {
                return NotFound();
            }
            return View(Student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
         public async Task<IActionResult> Edit(string id, [Bind("StudentId,SdtudentName")] Student std)
         {
            if (id != std.StdentId)
            {
                 return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(std);
                    await _context.SaveChangeAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(std.StudentId))
                    {
                         return NotFound();
                    }else{
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(std);
         }
         //Get:product/delete/5 
          public async Task<IActionResult> Delete(string id)
          {
            if (id == null)
            {
                 return NotFound();
            }
            var std = await _context.Student
                .FirstOrDefaultAsynsc(m=>m.StudentId == id);
            if (std == null)
            {
                 return NotFound();
            }
            return View(std);
          }
          //Get:product/delete/5 
          [HttpPost, ActionName("Delete")]
          [ValidateAntiForgeryToken]
           public async Task<IActionResult> DeleteConfirmed(string id)
           {
                var std = await _context.Student.FindAsync(id);
                _context.Student.Remove(std);
                await _context.SaveChangeAsync();
                return RedirectToAction(nameof(Index));
           }

    }
}