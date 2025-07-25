using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;

namespace SistemaTareas.model
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string ContrasenaHash { get; set; }

        [StringLength(20)]
        public string Rol { get; set; }

        public DateTime FechaCreacion { get; set; }

        public List<AsignacionProyecto>? AsignacionesProyectos { get; set; }

        [InverseProperty("CreadoPor")]
        public virtual List<Tarea>? TareasCreadas { get; set; }

        [InverseProperty("AsignadoA")]
        public virtual List<Tarea>? TareasAsignadas { get; set; }
        
    }
}