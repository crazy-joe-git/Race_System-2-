using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Race_System_2_.Data;
using Race_System_2_.Models;

namespace Race_System_2_.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Events
        public async Task<IActionResult> Index()
        {
            return View(await _context.Events.ToListAsync());
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var raceEvent = await _context.Events
                .FirstOrDefaultAsync(m => m.EventID == id);

            if (raceEvent == null) return NotFound();

            return View(raceEvent);
        }

        // GET: Events/Create (Organiser Only)
        [Authorize(Roles = "Organiser")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Organiser")]
        public async Task<IActionResult> Create([Bind("EventID,EventName,Description,EventDate,EventLocation,Distance,EventType,OrganizerName")] Event raceEvent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(raceEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(raceEvent);
        }

        // GET: Events/Edit/5 (Organiser Only)
        [Authorize(Roles = "Organiser")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var raceEvent = await _context.Events.FindAsync(id);
            if (raceEvent == null) return NotFound();

            return View(raceEvent);
        }

        // POST: Events/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Organiser")]
        public async Task<IActionResult> Edit(int id, [Bind("EventID,EventName,Description,EventDate,EventLocation,Distance,EventType,OrganizerName")] Event raceEvent)
        {
            if (id != raceEvent.EventID) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(raceEvent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Events.Any(e => e.EventID == id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(raceEvent);
        }

        // GET: Events/Delete/5 (Organiser Only)
        [Authorize(Roles = "Organiser")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var raceEvent = await _context.Events
                .FirstOrDefaultAsync(m => m.EventID == id);

            if (raceEvent == null) return NotFound();

            return View(raceEvent);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Organiser")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var raceEvent = await _context.Events.FindAsync(id);
            if (raceEvent != null)
            {
                _context.Events.Remove(raceEvent);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}