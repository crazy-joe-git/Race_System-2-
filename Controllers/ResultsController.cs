using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Race_System_2_.Data;
using Race_System_2_.Models;

namespace Race_System_2_.Controllers
{
    public class ResultsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResultsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Results
        public async Task<IActionResult> Index()
        {
            return View(await _context.Results.ToListAsync());
        }

        // GET: Results/Create (Organiser Only)
        [Authorize(Roles = "Organiser")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Results/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Organiser")]
        public async Task<IActionResult> Create([Bind("ResultID,FinishTime,Position,RegistrationID")] Result result)
        {
            if (ModelState.IsValid)
            {
                _context.Add(result);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(result);
        }
    }
}