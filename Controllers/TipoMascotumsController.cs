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
    public class TipoMascotumsController : ControllerBase
    {
        private readonly MascotasContext _context;

        public TipoMascotumsController(MascotasContext context)
        {
            _context = context;
        }

        // GET: api/TipoMascotums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoMascotum>>> GetTipoMascota()
        {
            return await _context.TipoMascota.ToListAsync();
        }

        // GET: api/TipoMascotums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoMascotum>> GetTipoMascotum(int id)
        {
            var tipoMascotum = await _context.TipoMascota.FindAsync(id);

            if (tipoMascotum == null)
            {
                return NotFound();
            }

            return tipoMascotum;
        }

        // PUT: api/TipoMascotums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoMascotum(int id, TipoMascotum tipoMascotum)
        {
            if (id != tipoMascotum.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoMascotum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoMascotumExists(id))
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

        // POST: api/TipoMascotums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoMascotum>> PostTipoMascotum(TipoMascotum tipoMascotum)
        {
            _context.TipoMascota.Add(tipoMascotum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoMascotum", new { id = tipoMascotum.Id }, tipoMascotum);
        }

        // DELETE: api/TipoMascotums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoMascotum(int id)
        {
            var tipoMascotum = await _context.TipoMascota.FindAsync(id);
            if (tipoMascotum == null)
            {
                return NotFound();
            }

            _context.TipoMascota.Remove(tipoMascotum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoMascotumExists(int id)
        {
            return _context.TipoMascota.Any(e => e.Id == id);
        }
    }
}
