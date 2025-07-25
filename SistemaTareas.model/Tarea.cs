using SistemaTareas.model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaTareas.model
{
    public class Tarea
    {
        [Key]
        public int TareaId { get; set; }

        [Required]
        [StringLength(200)]
        public string Titulo { get; set; }

        [StringLength(1000)]
        public string Descripcion { get; set; }

        [Required]
        [ForeignKey("Proyecto")]
        public int ProyectoId { get; set; }


        [ForeignKey("CreadoPorId")]
        [InverseProperty("TareasCreadas")]
        public virtual Usuario? CreadoPor { get; set; }

        [ForeignKey("AsignadoAId")]
        [InverseProperty("TareasAsignadas")]
        public virtual Usuario? AsignadoA { get; set; }

        public DateTime FechaCreacion { get; set; } 

        public DateTime? FechaVencimiento { get; set; }

        [Required]
        [StringLength(20)]
        public string Estado { get; set; } 

        [Required]
        [StringLength(20)]
        public string Prioridad { get; set; }

        public Proyecto? Proyecto { get; set; }
        public  List<ComentarioTarea>? Comentarios { get; set; }
        public List<HistorialTarea>? Historial { get; set; }
    }
}