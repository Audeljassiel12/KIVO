using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
    public class NotaDeEncuentro
    {
        public int Id { get; set; }  // Identificador único
        public int CitaId { get; set; }  // Relación con la Cita
        public Cita? Cita { get; set; } // Objeto Cita relacionado
        public string? Observaciones { get; set; } // Observaciones de la cita
    }
}
