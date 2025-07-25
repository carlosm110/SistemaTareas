using SistemaTareas.model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaTareas.model
{
    public class ComentarioTarea
    {
        [Key]
        public int ComentarioId { get; set; }
        [Required]
        public string Contenido { get; set; }

        public DateTime FechaCreacion { get; set; } 

        public virtual Tarea? Tarea { get; set; }
        public virtual Usuario? Usuario { get; set; }
        [Required]
        [ForeignKey("Tarea")]
        public int TareaId { get; set; }

        [Required]
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
    }
}