using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Race_System_2_.Data;
using Race_System_2_.Models;

namespace Race_System_2_.Controllers
{
    public class EventRacesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventRacesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EventRaces
        public async Task<IActionResult> Index()
        {
            return View(await _context.EventRaces.ToListAsync());
        }

        // GET: EventRaces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventRace = await _context.EventRaces
                .FirstOrDefaultAsync(m => m.EventRaceID == id);
            if (eventRace == null)
            {
                return NotFound();
            }

            return View(eventRace);
        }

        // GET: EventRaces/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EventRaces/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventRaceID,StartTime,MaxParticipants,EventID,CategoryID")] EventRace eventRace)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventRace);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventRace);
        }

        // GET: EventRaces/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventRace = await _context.EventRaces.FindAsync(id);
            if (eventRace == null)
            {
                return NotFound();
            }
            return View(eventRace);
        }

        // POST: EventRaces/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventRaceID,StartTime,MaxParticipants,EventID,CategoryID")] EventRace eventRace)
        {
            if (id != eventRace.EventRaceID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventRace);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventRaceExists(eventRace.EventRaceID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(eventRace);
        }

        // GET: EventRaces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventRace = await _context.EventRaces
                .FirstOrDefaultAsync(m => m.EventRaceID == id);
            if (eventRace == null)
            {
                return NotFound();
            }

            return View(eventRace);
        }

        // POST: EventRaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventRace = await _context.EventRaces.FindAsync(id);
            if (eventRace != null)
            {
                _context.EventRaces.Remove(eventRace);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventRaceExists(int id)
        {
            return _context.EventRaces.Any(e => e.EventRaceID == id);
        }
    }
}
