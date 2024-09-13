using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{    public class SignosVitales
    {
        public int Id { get; set; } // Clave primaria

        // Campos para cada signo vital
        [StringLength(maximumLength:7,MinimumLength = 3,ErrorMessage = "No cumple con los limites de caracteres establecidos.")]
        public double? Estatura { get; set; }
        [StringLength(maximumLength:8,MinimumLength = 3,ErrorMessage = "No cumple con los limites de caracteres establecidos.")]
        public double? Peso { get; set; }
        [StringLength(maximumLength:8,MinimumLength = 3,ErrorMessage = "No cumple con los limites de caracteres establecidos.")]
        public double? Temperatura { get; set; }
        [StringLength(maximumLength:6,MinimumLength = 3,ErrorMessage = "No cumple con los limites de caracteres establecidos.")]
        public double? FrecuenciaRespiratoria { get; set; }
        [StringLength(maximumLength:10,MinimumLength = 3,ErrorMessage = "No cumple con los limites de caracteres establecidos.")]
        public double? Sistolica { get; set; }
        [StringLength(maximumLength:10,MinimumLength = 3,ErrorMessage = "No cumple con los limites de caracteres establecidos.")]
        public double? Diastolica { get; set; }
        [StringLength(maximumLength:6,MinimumLength = 3,ErrorMessage = "No cumple con los limites de caracteres establecidos.")]
        public double? FrecuenciaCardiaca { get; set; }
        [StringLength(maximumLength:10,MinimumLength = 3,ErrorMessage = "No cumple con los limites de caracteres establecidos.")]
        public double? MasaCorporal { get; set; }
        [StringLength(maximumLength:10,MinimumLength = 3,ErrorMessage = "No cumple con los limites de caracteres establecidos.")]

        public double? PorcentajeGrasaCorporal { get; set; }
        [StringLength(maximumLength:10,MinimumLength = 3,ErrorMessage = "No cumple con los limites de caracteres establecidos.")]

        public double? MasaMuscular { get; set; }
        [StringLength(maximumLength:10,MinimumLength = 3,ErrorMessage = "No cumple con los limites de caracteres establecidos.")]

        public double? PerimetroCefalico { get; set; }
        [StringLength(maximumLength:10,MinimumLength = 3,ErrorMessage = "No cumple con los limites de caracteres establecidos.")]

        public double? SaturacionOxigeno { get; set; }
        [StringLength(maximumLength:6,MinimumLength = 3,ErrorMessage = "No cumple con los limites de caracteres establecidos.")]

        public double? PorcentajeAgua { get; set; }
        [StringLength(maximumLength:10,MinimumLength = 3,ErrorMessage = "No cumple con los limites de caracteres establecidos.")]

        public double? PorcentajeGrasaVisceral { get; set; }
        [StringLength(maximumLength:5,MinimumLength = 3,ErrorMessage = "No cumple con los limites de caracteres establecidos.")]

        public double? Huesos { get; set; }
        [StringLength(maximumLength:10,MinimumLength = 3,ErrorMessage = "No cumple con los limites de caracteres establecidos.")]

        public double? Metabolismo { get; set; }
        [StringLength(maximumLength:5,MinimumLength = 3,ErrorMessage = "No cumple con los limites de caracteres establecidos.")]

        public double? PorcentajeProteinas { get; set; }
        [StringLength(maximumLength:4,MinimumLength = 3,ErrorMessage = "No cumple con los limites de caracteres establecidos.")]

        public double? EdadCuerpo { get; set; }
        [StringLength(maximumLength:5,MinimumLength = 3,ErrorMessage = " No cumple con los limites de caracteres establecidos.")]

        public double? PerimetroAbdominal { get; set; }

        // Relación con Cita
        public int CitaID { get; set; } // Clave foránea a Cita
        public Cita? Cita { get; set; } // Navegación hacia Cita
    }

}