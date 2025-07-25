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
    public class AsignacionesProyectosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AsignacionesProyectosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AsignacionesProyectos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AsignacionProyecto.Include(a => a.Proyecto).Include(a => a.Usuario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AsignacionesProyectos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignacionProyecto = await _context.AsignacionProyecto
                .Include(a => a.Proyecto)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.AsignacionId == id);
            if (asignacionProyecto == null)
            {
                return NotFound();
            }

            return View(asignacionProyecto);
        }

        // GET: AsignacionesProyectos/Create
        public IActionResult Create()
        {
            ViewData["ProyectoId"] = new SelectList(_context.Set<Proyecto>(), "ProyectoId", "Descripcion");
            ViewData["UsuarioId"] = new SelectList(_context.Set<Usuario>(), "UsuarioId", "ContrasenaHash");
            return View();
        }

        // POST: AsignacionesProyectos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AsignacionId,UsuarioId,ProyectoId,Rol,FechaAsignacion")] AsignacionProyecto asignacionProyecto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asignacionProyecto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProyectoId"] = new SelectList(_context.Set<Proyecto>(), "ProyectoId", "Descripcion", asignacionProyecto.ProyectoId);
            ViewData["UsuarioId"] = new SelectList(_context.Set<Usuario>(), "UsuarioId", "ContrasenaHash", asignacionProyecto.UsuarioId);
            return View(asignacionProyecto);
        }

        // GET: AsignacionesProyectos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignacionProyecto = await _context.AsignacionProyecto.FindAsync(id);
            if (asignacionProyecto == null)
            {
                return NotFound();
            }
            ViewData["ProyectoId"] = new SelectList(_context.Set<Proyecto>(), "ProyectoId", "Descripcion", asignacionProyecto.ProyectoId);
            ViewData["UsuarioId"] = new SelectList(_context.Set<Usuario>(), "UsuarioId", "ContrasenaHash", asignacionProyecto.UsuarioId);
            return View(asignacionProyecto);
        }

        // POST: AsignacionesProyectos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AsignacionId,UsuarioId,ProyectoId,Rol,FechaAsignacion")] AsignacionProyecto asignacionProyecto)
        {
            if (id != asignacionProyecto.AsignacionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asignacionProyecto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsignacionProyectoExists(asignacionProyecto.AsignacionId))
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
            ViewData["ProyectoId"] = new SelectList(_context.Set<Proyecto>(), "ProyectoId", "Descripcion", asignacionProyecto.ProyectoId);
            ViewData["UsuarioId"] = new SelectList(_context.Set<Usuario>(), "UsuarioId", "ContrasenaHash", asignacionProyecto.UsuarioId);
            return View(asignacionProyecto);
        }

        // GET: AsignacionesProyectos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignacionProyecto = await _context.AsignacionProyecto
                .Include(a => a.Proyecto)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.AsignacionId == id);
            if (asignacionProyecto == null)
            {
                return NotFound();
            }

            return View(asignacionProyecto);
        }

        // POST: AsignacionesProyectos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asignacionProyecto = await _context.AsignacionProyecto.FindAsync(id);
            if (asignacionProyecto != null)
            {
                _context.AsignacionProyecto.Remove(asignacionProyecto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsignacionProyectoExists(int id)
        {
            return _context.AsignacionProyecto.Any(e => e.AsignacionId == id);
        }
    }
}
