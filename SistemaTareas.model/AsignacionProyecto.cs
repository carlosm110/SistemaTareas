using SistemaTareas.model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaTareas.model
{
    public class AsignacionProyecto
    {
        [Key]
        public int AsignacionId { get; set; }

        [Required]
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }

        [Required]
        [ForeignKey("Proyecto")]
        public int ProyectoId { get; set; }

        [StringLength(50)]
        public string Rol { get; set; }

        public DateTime FechaAsignacion { get; set; } = DateTime.UtcNow;

        public Usuario? Usuario { get; set; }
        public Proyecto? Proyecto { get; set; }
    }
}