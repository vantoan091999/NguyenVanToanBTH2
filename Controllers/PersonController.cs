using NguyenVanToanBTH2.Data;
using NguyenVanToanBTH2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace NguyenVanToanBTH2.Controllers
{
    public class PersonController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PersonController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _context.People.ToListAsync();
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Person ps)
        {
            if(ModelState.IsValid)
            {
                _context.Add(ps);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ps);
        }
    }
}