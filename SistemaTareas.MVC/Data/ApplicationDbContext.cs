using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemaTareas.model;

namespace SistemaTareas.MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<SistemaTareas.model.AsignacionProyecto> AsignacionProyecto { get; set; } = default!;
        public DbSet<SistemaTareas.model.ComentarioTarea> ComentarioTarea { get; set; } = default!;
        public DbSet<SistemaTareas.model.HistorialTarea> HistorialTarea { get; set; } = default!;
        public DbSet<SistemaTareas.model.Proyecto> Proyecto { get; set; } = default!;
        public DbSet<SistemaTareas.model.Tarea> Tarea { get; set; } = default!;
        public DbSet<SistemaTareas.model.Usuario> Usuario { get; set; } = default!;
    }
}
