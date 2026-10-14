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
    public class RaceCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RaceCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RaceCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.RaceCategories.ToListAsync());
        }

        // GET: RaceCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raceCategory = await _context.RaceCategories
                .FirstOrDefaultAsync(m => m.CategoryID == id);
            if (raceCategory == null)
            {
                return NotFound();
            }

            return View(raceCategory);
        }

        // GET: RaceCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RaceCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryID,CategoryName,Distance,Category_description")] RaceCategory raceCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(raceCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(raceCategory);
        }

        // GET: RaceCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raceCategory = await _context.RaceCategories.FindAsync(id);
            if (raceCategory == null)
            {
                return NotFound();
            }
            return View(raceCategory);
        }

        // POST: RaceCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryID,CategoryName,Distance,Category_description")] RaceCategory raceCategory)
        {
            if (id != raceCategory.CategoryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(raceCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RaceCategoryExists(raceCategory.CategoryID))
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
            return View(raceCategory);
        }

        // GET: RaceCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raceCategory = await _context.RaceCategories
                .FirstOrDefaultAsync(m => m.CategoryID == id);
            if (raceCategory == null)
            {
                return NotFound();
            }

            return View(raceCategory);
        }

        // POST: RaceCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var raceCategory = await _context.RaceCategories.FindAsync(id);
            if (raceCategory != null)
            {
                _context.RaceCategories.Remove(raceCategory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RaceCategoryExists(int id)
        {
            return _context.RaceCategories.Any(e => e.CategoryID == id);
        }
    }
}
