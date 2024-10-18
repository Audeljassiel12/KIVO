using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
    public class Medico
    {
        public string Id { get; set; } // Identificador único del médico.
        
        public string Nombres { get; set; } = null!; // Nombres del médico.
        
        public string Apellidos { get; set; } = null!; // Apellidos del médico.
        
        public string? Telefono { get; set; } = null!; // Número de teléfono del médico.
        
        public CentroMedico? CentroMedico { get; set; } // Relación con el centro médico al que está asociado.
        
        public int CentroMedicoId { get; set; } // Identificador del centro médico.
        
        public List<Cita> Citas { get; set; } // Lista de citas que el médico tiene programadas.
        
        public EspecialidadMedica? EspecialidadMedico { get; set; } // Especialidad médica del médico.
        
        public int? EspecialidadMedicoId { get; set; } // Identificador de la especialidad médica.
    }
}
