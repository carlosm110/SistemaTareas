using SistemaTareas.model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaTareas.model
{
    public class HistorialTarea
    {
        [Key]
        public int HistorialId { get; set; }

        [Required]
        [StringLength(50)]
        public string CampoModificado { get; set; }

        public string ValorAnterior { get; set; }

        public string ValorNuevo { get; set; }

        public DateTime FechaCambio { get; set; } = DateTime.UtcNow;

        public virtual Tarea Tarea { get; set; }
        public virtual Usuario CambiadoPor { get; set; }
        [Required]
        [ForeignKey("Tarea")]
        public int TareaId { get; set; }

        [ForeignKey("Usuario")]
        public int? CambiadoPorId { get; set; }
    }
}