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
    public class EventRacesApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EventRacesApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EventRacesApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventRace>>> GetEventRaces()
        {
            return await _context.EventRaces.ToListAsync();
        }

        // GET: api/EventRacesApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventRace>> GetEventRace(int id)
        {
            var eventRace = await _context.EventRaces.FindAsync(id);

            if (eventRace == null)
            {
                return NotFound();
            }

            return eventRace;
        }

        // PUT: api/EventRacesApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventRace(int id, EventRace eventRace)
        {
            if (id != eventRace.EventRaceID)
            {
                return BadRequest();
            }

            _context.Entry(eventRace).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventRaceExists(id))
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

        // POST: api/EventRacesApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EventRace>> PostEventRace(EventRace eventRace)
        {
            _context.EventRaces.Add(eventRace);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventRace", new { id = eventRace.EventRaceID }, eventRace);
        }

        // DELETE: api/EventRacesApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventRace(int id)
        {
            var eventRace = await _context.EventRaces.FindAsync(id);
            if (eventRace == null)
            {
                return NotFound();
            }

            _context.EventRaces.Remove(eventRace);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventRaceExists(int id)
        {
            return _context.EventRaces.Any(e => e.EventRaceID == id);
        }
    }
}
