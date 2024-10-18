using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace KIVO.Models
{
    public class User : IdentityUser
    {
        // Relación con Paciente y Medico (pueden ser nulos)
        public Paciente? Paciente { get; set; }
        public Medico? Medico { get; set; }

        // Código de verificación
        [Required]
        [StringLength(6, ErrorMessage = "El código de verificación debe tener 6 caracteres.")]
        public string VerificationCode { get; set; } = null!;

        // Fecha de expiración del código de verificación
        [DataType(DataType.DateTime)]
        public DateTime? VerificationCodeExpiry { get; set; }

        // Nombre del usuario (opcional)
        [StringLength(100, ErrorMessage = "El campo Nombres no debe exceder los 100 caracteres.")]
        public string? Nombres { get; set; }

        // Indicador si ha configurado la organización
        [Required]
        public bool HaConfiguradoOrganizacion { get; set; }

        // Indicador si ha seleccionado un plan
        [Required]
        public bool SeleccionoPlan { get; set; }
    }
}
