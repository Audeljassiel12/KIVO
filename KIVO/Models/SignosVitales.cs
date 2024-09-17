using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{    public class SignosVitales
    {
        public int Id { get; set; } // Clave primaria

        // Campos para cada signo vital
        public double? Estatura { get; set; }
        public double? Peso { get; set; }
        public double? Temperatura { get; set; }
        public double? FrecuenciaRespiratoria { get; set; }
        public double? Sistolica { get; set; }
        public double? Diastolica { get; set; }
        public double? FrecuenciaCardiaca { get; set; }
        public double? MasaCorporal { get; set; }
        public double? PorcentajeGrasaCorporal { get; set; }
        public double? MasaMuscular { get; set; }
        public double? PerimetroCefalico { get; set; }
        public double? SaturacionOxigeno { get; set; }
        public double? PorcentajeAgua { get; set; }
        public double? PorcentajeGrasaVisceral { get; set; }
        public double? Huesos { get; set; }
        public double? Metabolismo { get; set; }
        public double? PorcentajeProteinas { get; set; }
        public double? EdadCuerpo { get; set; }
        public double? PerimetroAbdominal { get; set; }

        // Relación con Cita
        public int CitaId { get; set; } // Clave foránea a Cita
        public Cita? Cita { get; set; } // Navegación hacia Cita
    }

}