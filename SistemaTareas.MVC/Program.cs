
using SistemaTareas.ApiConsumer;
using SistemaTareas.model;
using System.Text;
namespace SistemaTareas.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Crud<AsignacionProyecto>.EndPoint = "https://localhost:7047/api/AsignacionesProyectos";
            Crud<ComentarioTarea>.EndPoint = "https://localhost:7047/api/ComentariosTareas";
            Crud<HistorialTarea>.EndPoint = "https://localhost:7047/api/HistorialTareas";
            Crud<Proyecto>.EndPoint = "https://localhost:7047/api/Proyectos";
            Crud<Tarea>.EndPoint = "https://localhost:7047/api/Tareas";
            Crud<Usuario>.EndPoint = "https://localhost:7047/api/Usuarios";


            var builder = WebApplication.CreateBuilder(args);

          
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}