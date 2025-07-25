using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaTareas.model;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<SistemaTareas.model.AsignacionProyecto> AsignacionesProyectos{ get; set; } = default!;


    public DbSet<SistemaTareas.model.HistorialTarea> HistorialTareas { get; set; } = default!;


    public DbSet<SistemaTareas.model.Tarea> Tareas { get; set; } = default!;

    public DbSet<SistemaTareas.model.Usuario> Usuarios { get; set; } = default!;

    public DbSet<SistemaTareas.model.ComentarioTarea> ComentariosTareas { get; set; } = default!;

public DbSet<SistemaTareas.model.Proyecto> Proyectos { get; set; } = default!;

}
