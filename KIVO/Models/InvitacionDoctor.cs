using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
    public class InvitacionDoctor
    {
        public int Id { get; set; } // Clave primaria para identificar la invitación.
        
        public string Email { get; set; } = null!; // Email del doctor al que se envía la invitación.
        
        public string Token { get; set; } = null!; // Token único para la invitación, utilizado para verificar la autenticidad.
        
        public DateTime FechaInvitacion { get; set; } // Fecha en la que se envió la invitación.
        
        public bool EstaAceptada { get; set; } // Estado de la invitación (indica si ha sido aceptada por el doctor).
        
        public bool EstaExpirada { get; set; } // Indica si la invitación ha expirado.
        
        public int CentroMedicoId { get; set; } // Identificador del centro médico asociado a la invitación.

        // Información adicional del doctor para completar el registro
        public string Nombres { get; set; } = null!; // Nombres del doctor.
        
        public string Apellidos { get; set; } = null!; // Apellidos del doctor.
        
        public string Especialidad { get; set; } = null!; // Especialidad del doctor.

        // Relación con el centro médico
        public CentroMedico? centroMedico { get; set; } // Relación opcional con el centro médico al que se envió la invitación.
    }
}
