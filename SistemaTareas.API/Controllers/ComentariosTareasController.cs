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
    public class ComentariosTareasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ComentariosTareasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ComentariosTareas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComentarioTarea>>> GetComentarioTarea()
        {
            return await _context.ComentariosTareas.ToListAsync();
        }

        // GET: api/ComentariosTareas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ComentarioTarea>> GetComentarioTarea(int id)
        {
            var comentarioTarea = await _context.ComentariosTareas.FindAsync(id);

            if (comentarioTarea == null)
            {
                return NotFound();
            }

            return comentarioTarea;
        }

        // PUT: api/ComentariosTareas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComentarioTarea(int id, ComentarioTarea comentarioTarea)
        {
            if (id != comentarioTarea.ComentarioId)
            {
                return BadRequest();
            }

            _context.Entry(comentarioTarea).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComentarioTareaExists(id))
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

        // POST: api/ComentariosTareas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ComentarioTarea>> PostComentarioTarea(ComentarioTarea comentarioTarea)
        {
            _context.ComentariosTareas.Add(comentarioTarea);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComentarioTarea", new { id = comentarioTarea.ComentarioId }, comentarioTarea);
        }

        // DELETE: api/ComentariosTareas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComentarioTarea(int id)
        {
            var comentarioTarea = await _context.ComentariosTareas.FindAsync(id);
            if (comentarioTarea == null)
            {
                return NotFound();
            }

            _context.ComentariosTareas.Remove(comentarioTarea);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComentarioTareaExists(int id)
        {
            return _context.ComentariosTareas.Any(e => e.ComentarioId == id);
        }
    }
}
