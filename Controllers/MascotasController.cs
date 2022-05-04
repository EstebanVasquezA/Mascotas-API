#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mascotas_API.Models;

namespace Mascotas_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MascotasController : ControllerBase
    {
        private readonly MascotasContext _context;

        public MascotasController(MascotasContext context)
        {
            _context = context;
        }

        // GET: api/Mascotas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mascotum>>> GetMascota()
        {
            return await _context.Mascota.ToListAsync();
        }

        // GET: api/Mascotas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mascotum>> GetMascotum(int id)
        {
            var mascotum = await _context.Mascota.FindAsync(id);

            if (mascotum == null)
            {
                return NotFound();
            }

            return mascotum;
        }

        // PUT: api/Mascotas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMascotum(int id, Mascotum mascotum)
        {
            if (id != mascotum.Id)
            {
                return BadRequest();
            }

            _context.Entry(mascotum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MascotumExists(id))
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

        // POST: api/Mascotas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mascotum>> PostMascotum(Mascotum mascotum)
        {
            _context.Mascota.Add(mascotum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMascotum", new { id = mascotum.Id }, mascotum);
        }

        // DELETE: api/Mascotas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMascotum(int id)
        {
            var mascotum = await _context.Mascota.FindAsync(id);
            if (mascotum == null)
            {
                return NotFound();
            }

            _context.Mascota.Remove(mascotum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MascotumExists(int id)
        {
            return _context.Mascota.Any(e => e.Id == id);
        }
    }
}
