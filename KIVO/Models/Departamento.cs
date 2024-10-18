using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
    public class Departamento
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required(ErrorMessage = "El nombre del departamento es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        public string Nombre { get; set; } = null!;

        // Anclas  
        public List<CentroMedico>? CentroMedicos { get; set; }

        public List<Paciente>? Pacientes { get; set; }

        public List<Cuidad>? Ciudades { get; set; } 
    }
}

