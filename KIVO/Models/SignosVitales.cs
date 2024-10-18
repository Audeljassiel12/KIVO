using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
    public class SignosVitales
    {
        public int Id { get; set; } // Clave primaria

        // Campos para cada signo vital
        [Range(0, 3, ErrorMessage = "La estatura debe estar entre 0 y 3 metros.")]
        public double? Estatura { get; set; }

        [Range(0, 500, ErrorMessage = "El peso debe estar entre 0 y 500 kg.")]
        public double? Peso { get; set; }

        [Range(30, 45, ErrorMessage = "La temperatura debe estar entre 30 y 45 grados Celsius.")]
        public double? Temperatura { get; set; }

        [Range(10, 40, ErrorMessage = "La frecuencia respiratoria debe estar entre 10 y 40 respiraciones por minuto.")]
        public double? FrecuenciaRespiratoria { get; set; }

        [Range(60, 180, ErrorMessage = "La presión sistólica debe estar entre 60 y 180 mmHg.")]
        public double? Sistolica { get; set; }

        [Range(40, 120, ErrorMessage = "La presión diastólica debe estar entre 40 y 120 mmHg.")]
        public double? Diastolica { get; set; }

        [Range(40, 180, ErrorMessage = "La frecuencia cardíaca debe estar entre 40 y 180 latidos por minuto.")]
        public double? FrecuenciaCardiaca { get; set; }

        [Range(10, 50, ErrorMessage = "El índice de masa corporal debe estar entre 10 y 50.")]
        public double? MasaCorporal { get; set; }

        [Range(5, 50, ErrorMessage = "El porcentaje de grasa corporal debe estar entre 5% y 50%.")]
        public double? PorcentajeGrasaCorporal { get; set; }

        public double? MasaMuscular { get; set; }

        [Range(30, 60, ErrorMessage = "El perímetro cefálico debe estar entre 30 y 60 cm.")]
        public double? PerimetroCefalico { get; set; }

        [Range(70, 100, ErrorMessage = "La saturación de oxígeno debe estar entre 70% y 100%.")]
        public double? SaturacionOxigeno { get; set; }

        public double? PorcentajeAgua { get; set; }

        public double? PorcentajeGrasaVisceral { get; set; }

        public double? Huesos { get; set; }

        public double? Metabolismo { get; set; }

        public double? PorcentajeProteinas { get; set; }

        public double? EdadCuerpo { get; set; }

        public double? PerimetroAbdominal { get; set; }

        // Relación con Cita
        [Required]
        public int CitaId { get; set; } // Clave foránea a Cita

        public Cita? Cita { get; set; } // Navegación hacia Cita
    }
}
