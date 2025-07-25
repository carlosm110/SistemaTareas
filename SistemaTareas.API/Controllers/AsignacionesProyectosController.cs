using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaTareas.model;

namespace SistemaTareas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignacionesProyectosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AsignacionesProyectosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/AsignacionesProyectos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AsignacionProyecto>>> GetAsignacionProyecto()
        {
            return await _context.AsignacionProyecto.ToListAsync();
        }

        // GET: api/AsignacionesProyectos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AsignacionProyecto>> GetAsignacionProyecto(int id)
        {
            var asignacionProyecto = await _context.AsignacionProyecto.FindAsync(id);

            if (asignacionProyecto == null)
            {
                return NotFound();
            }

            return asignacionProyecto;
        }

        // PUT: api/AsignacionesProyectos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsignacionProyecto(int id, AsignacionProyecto asignacionProyecto)
        {
            if (id != asignacionProyecto.AsignacionId)
            {
                return BadRequest();
            }

            _context.Entry(asignacionProyecto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsignacionProyectoExists(id))
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

        // POST: api/AsignacionesProyectos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AsignacionProyecto>> PostAsignacionProyecto(AsignacionProyecto asignacionProyecto)
        {
            _context.AsignacionProyecto.Add(asignacionProyecto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAsignacionProyecto", new { id = asignacionProyecto.AsignacionId }, asignacionProyecto);
        }

        // DELETE: api/AsignacionesProyectos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsignacionProyecto(int id)
        {
            var asignacionProyecto = await _context.AsignacionProyecto.FindAsync(id);
            if (asignacionProyecto == null)
            {
                return NotFound();
            }

            _context.AsignacionProyecto.Remove(asignacionProyecto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AsignacionProyectoExists(int id)
        {
            return _context.AsignacionProyecto.Any(e => e.AsignacionId == id);
        }
    }
}
