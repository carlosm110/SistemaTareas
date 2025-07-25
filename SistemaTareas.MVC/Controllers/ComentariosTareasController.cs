using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaTareas.MVC.Data;
using SistemaTareas.model;

namespace SistemaTareas.MVC.Controllers
{
    public class ComentariosTareasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ComentariosTareasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ComentariosTareas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ComentarioTarea.Include(c => c.Tarea).Include(c => c.Usuario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ComentariosTareas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comentarioTarea = await _context.ComentarioTarea
                .Include(c => c.Tarea)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.ComentarioId == id);
            if (comentarioTarea == null)
            {
                return NotFound();
            }

            return View(comentarioTarea);
        }

        // GET: ComentariosTareas/Create
        public IActionResult Create()
        {
            ViewData["TareaId"] = new SelectList(_context.Set<Tarea>(), "TareaId", "Descripcion");
            ViewData["UsuarioId"] = new SelectList(_context.Set<Usuario>(), "UsuarioId", "ContrasenaHash");
            return View();
        }

        // POST: ComentariosTareas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ComentarioId,Contenido,FechaCreacion,TareaId,UsuarioId")] ComentarioTarea comentarioTarea)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comentarioTarea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TareaId"] = new SelectList(_context.Set<Tarea>(), "TareaId", "Descripcion", comentarioTarea.TareaId);
            ViewData["UsuarioId"] = new SelectList(_context.Set<Usuario>(), "UsuarioId", "ContrasenaHash", comentarioTarea.UsuarioId);
            return View(comentarioTarea);
        }

        // GET: ComentariosTareas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comentarioTarea = await _context.ComentarioTarea.FindAsync(id);
            if (comentarioTarea == null)
            {
                return NotFound();
            }
            ViewData["TareaId"] = new SelectList(_context.Set<Tarea>(), "TareaId", "Descripcion", comentarioTarea.TareaId);
            ViewData["UsuarioId"] = new SelectList(_context.Set<Usuario>(), "UsuarioId", "ContrasenaHash", comentarioTarea.UsuarioId);
            return View(comentarioTarea);
        }

        // POST: ComentariosTareas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ComentarioId,Contenido,FechaCreacion,TareaId,UsuarioId")] ComentarioTarea comentarioTarea)
        {
            if (id != comentarioTarea.ComentarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comentarioTarea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComentarioTareaExists(comentarioTarea.ComentarioId))
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
            ViewData["TareaId"] = new SelectList(_context.Set<Tarea>(), "TareaId", "Descripcion", comentarioTarea.TareaId);
            ViewData["UsuarioId"] = new SelectList(_context.Set<Usuario>(), "UsuarioId", "ContrasenaHash", comentarioTarea.UsuarioId);
            return View(comentarioTarea);
        }

        // GET: ComentariosTareas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comentarioTarea = await _context.ComentarioTarea
                .Include(c => c.Tarea)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.ComentarioId == id);
            if (comentarioTarea == null)
            {
                return NotFound();
            }

            return View(comentarioTarea);
        }

        // POST: ComentariosTareas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comentarioTarea = await _context.ComentarioTarea.FindAsync(id);
            if (comentarioTarea != null)
            {
                _context.ComentarioTarea.Remove(comentarioTarea);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComentarioTareaExists(int id)
        {
            return _context.ComentarioTarea.Any(e => e.ComentarioId == id);
        }
    }
}
