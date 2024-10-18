using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
    public class EspecialidadMedica
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la especialidad es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre de la especialidad no puede exceder los 100 caracteres.")]
        public string? Nombre { get; set; } // Nombre de la especialidad (ej. Cardiología, Pediatría)

        // Relación con otros modelos
        public ICollection<Medico>? Medicos { get; set; } // Doctores que tienen esta especialidad
    }
}