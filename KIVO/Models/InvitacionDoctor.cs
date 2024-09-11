using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
  public class InvitacionDoctor
    {
        public int Id { get; set; } // Clave primaria
        public string Email { get; set; }  = null!; // Email del doctor al que se envía la invitación
        public string Token { get; set; } = null!;  // Token único para la invitación
        public DateTime FechaInvitacion { get; set; } // Fecha en la que se envió la invitación
        public bool EstaAceptada { get; set; } // Estado de la invitación (si ha sido aceptada)
        public bool EstaExpirada { get; set; } // Indica si la invitación ha expirado
        public int CentroMedicoId { get; set; }

        // Información adicional del doctor para completar el registro
        public string Nombres { get; set; } = null!; 
        public string Apellidos { get; set; } = null!; 
        public string Especialidad { get; set; } = null!; 

        // anclas 

        public CentroMedico? centroMedico{ get; set; }
    }

}