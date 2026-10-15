using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Race_System_2_.Data;
using Race_System_2_.Models;

namespace Race_System_2_.Controllers
{
    public class RegistrationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegistrationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Registrations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Registrations.ToListAsync());
        }

        // GET: Registrations/Create (Participant Only)
        [Authorize(Roles = "Participant")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Registrations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Participant")]
        public async Task<IActionResult> Create([Bind("RegistrationID,Reg_Date,BidNumber,PaymentStatus,ParticipantID,EventRaceID")] Registration registration)
        {
            registration.Reg_Date = DateTime.Now;

            if (ModelState.IsValid)
            {
                _context.Add(registration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(registration);
        }
    }
}