using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Race_System_2_.Data;
using Race_System_2_.Models;

namespace Race_System_2_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaceCategoriesApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RaceCategoriesApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/RaceCategoriesApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RaceCategory>>> GetRaceCategories()
        {
            return await _context.RaceCategories.ToListAsync();
        }

        // GET: api/RaceCategoriesApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RaceCategory>> GetRaceCategory(int id)
        {
            var raceCategory = await _context.RaceCategories.FindAsync(id);

            if (raceCategory == null)
            {
                return NotFound();
            }

            return raceCategory;
        }

        // PUT: api/RaceCategoriesApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRaceCategory(int id, RaceCategory raceCategory)
        {
            if (id != raceCategory.CategoryID)
            {
                return BadRequest();
            }

            _context.Entry(raceCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RaceCategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/RaceCategoriesApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RaceCategory>> PostRaceCategory(RaceCategory raceCategory)
        {
            _context.RaceCategories.Add(raceCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRaceCategory", new { id = raceCategory.CategoryID }, raceCategory);
        }

        // DELETE: api/RaceCategoriesApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRaceCategory(int id)
        {
            var raceCategory = await _context.RaceCategories.FindAsync(id);
            if (raceCategory == null)
            {
                return NotFound();
            }

            _context.RaceCategories.Remove(raceCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RaceCategoryExists(int id)
        {
            return _context.RaceCategories.Any(e => e.CategoryID == id);
        }
    }
}
