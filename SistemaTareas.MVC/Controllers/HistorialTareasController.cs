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
    public class HistorialTareasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HistorialTareasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HistorialTareas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.HistorialTarea.Include(h => h.CambiadoPor).Include(h => h.Tarea);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: HistorialTareas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historialTarea = await _context.HistorialTarea
                .Include(h => h.CambiadoPor)
                .Include(h => h.Tarea)
                .FirstOrDefaultAsync(m => m.HistorialId == id);
            if (historialTarea == null)
            {
                return NotFound();
            }

            return View(historialTarea);
        }

        // GET: HistorialTareas/Create
        public IActionResult Create()
        {
            ViewData["CambiadoPorId"] = new SelectList(_context.Set<Usuario>(), "UsuarioId", "ContrasenaHash");
            ViewData["TareaId"] = new SelectList(_context.Set<Tarea>(), "TareaId", "Descripcion");
            return View();
        }

        // POST: HistorialTareas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HistorialId,CampoModificado,ValorAnterior,ValorNuevo,FechaCambio,TareaId,CambiadoPorId")] HistorialTarea historialTarea)
        {
            if (ModelState.IsValid)
            {
                _context.Add(historialTarea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CambiadoPorId"] = new SelectList(_context.Set<Usuario>(), "UsuarioId", "ContrasenaHash", historialTarea.CambiadoPorId);
            ViewData["TareaId"] = new SelectList(_context.Set<Tarea>(), "TareaId", "Descripcion", historialTarea.TareaId);
            return View(historialTarea);
        }

        // GET: HistorialTareas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historialTarea = await _context.HistorialTarea.FindAsync(id);
            if (historialTarea == null)
            {
                return NotFound();
            }
            ViewData["CambiadoPorId"] = new SelectList(_context.Set<Usuario>(), "UsuarioId", "ContrasenaHash", historialTarea.CambiadoPorId);
            ViewData["TareaId"] = new SelectList(_context.Set<Tarea>(), "TareaId", "Descripcion", historialTarea.TareaId);
            return View(historialTarea);
        }

        // POST: HistorialTareas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HistorialId,CampoModificado,ValorAnterior,ValorNuevo,FechaCambio,TareaId,CambiadoPorId")] HistorialTarea historialTarea)
        {
            if (id != historialTarea.HistorialId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historialTarea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistorialTareaExists(historialTarea.HistorialId))
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
            ViewData["CambiadoPorId"] = new SelectList(_context.Set<Usuario>(), "UsuarioId", "ContrasenaHash", historialTarea.CambiadoPorId);
            ViewData["TareaId"] = new SelectList(_context.Set<Tarea>(), "TareaId", "Descripcion", historialTarea.TareaId);
            return View(historialTarea);
        }

        // GET: HistorialTareas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historialTarea = await _context.HistorialTarea
                .Include(h => h.CambiadoPor)
                .Include(h => h.Tarea)
                .FirstOrDefaultAsync(m => m.HistorialId == id);
            if (historialTarea == null)
            {
                return NotFound();
            }

            return View(historialTarea);
        }

        // POST: HistorialTareas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var historialTarea = await _context.HistorialTarea.FindAsync(id);
            if (historialTarea != null)
            {
                _context.HistorialTarea.Remove(historialTarea);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistorialTareaExists(int id)
        {
            return _context.HistorialTarea.Any(e => e.HistorialId == id);
        }
    }
}
