using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AstronautsWebApplication.Data;
using AstronautsWebApplication.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace AstronautsWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AstronautsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AstronautsController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Astronaut>>> GetAstronauts()
        {
            var astronauts = await _context.Astronauts.ToListAsync();
         
            return astronauts;
        }

        // GET: api/Astronauts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Astronaut>> GetAstronaut(Guid id)
        {
            var astronaut = await _context.Astronauts.FindAsync(id);

            if (astronaut == null)
            {
                return NotFound();
            }

            return astronaut;
        }

        [HttpPost]
        public async Task<ActionResult<Astronaut>> PostAstronaut(Astronaut astronaut)
        {
            _context.Astronauts.Add(astronaut);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAstronaut", new { id = astronaut.Id }, astronaut);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAstronaut(Guid id)
        {
            var astronaut = await _context.Astronauts.FindAsync(id);
            if (astronaut == null)
            {
                return NotFound();
            }

            _context.Astronauts.Remove(astronaut);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAstronaut(Guid id, Astronaut astronaut)
        {
            if (id != astronaut.Id)
            {
                return BadRequest();
            }

            _context.Entry(astronaut).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AstronautExists(id))
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

        private bool AstronautExists(Guid id)
        {
            return _context.Astronauts.Any(e => e.Id == id);
        }
    }
}
