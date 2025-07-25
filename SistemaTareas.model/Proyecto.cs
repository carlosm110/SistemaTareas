using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;

namespace SistemaTareas.model
{
    public class Proyecto
    {
        [Key]
        public int ProyectoId { get; set; }

        [Required]
        [StringLength(200)]
        public string Nombre { get; set; }

        [StringLength(1000)]
        public string Descripcion { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; }

        [Required]
        [StringLength(20)]
        public string Estado { get; set; }  
        public List<AsignacionProyecto>? AsignacionesProyectos { get; set; }
        public List<Tarea>? Tareas { get; set; }
    }
}