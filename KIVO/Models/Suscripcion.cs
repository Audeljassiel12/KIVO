using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
    public class Suscripcion
    {
        public int Id { get; set; } // Identificador único

        [Required]
        public int CentroMedicoId { get; set; } // FK de CentroMedico

        [Required]
        public int PlanSuscripcionId { get; set; } // FK a PlanSuscripcion

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; } // Fecha de inicio de la suscripción

        [Required]
        [DataType(DataType.Date)]
        [CompareDates("FechaInicio", ErrorMessage = "La Fecha de Fin debe ser posterior a la Fecha de Inicio.")]
        public DateTime FechaFin { get; set; } // Fecha de fin de la suscripción

        [Required]
        public bool Activa { get; set; } // Determina si la suscripción está activa

        // Relaciones
        public CentroMedico? CentroMedico { get; set; } // Relación con CentroMedico
        public PlanSuscripcion? PlanSuscripcion { get; set; } // Relación con PlanSuscripcion
    }
}
