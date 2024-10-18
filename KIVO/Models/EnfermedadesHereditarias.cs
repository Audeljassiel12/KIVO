using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
    public class EnfermedadesHereditarias
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El ID del paciente es obligatorio.")]
        public string PacienteId { get; set; } // FK a Paciente

        [ForeignKey("PacienteId")]
        public Paciente? Paciente { get; set; }

        // Enfermedades hereditarias
        public bool? Alergias { get; set; }
        
        [StringLength(200, ErrorMessage = "Los detalles sobre alergias no pueden exceder los 200 caracteres.")]
        public string? DetallesAlergias { get; set; }

        public bool? DiabetesMellitus { get; set; }
        
        [StringLength(200, ErrorMessage = "Los detalles sobre diabetes mellitus no pueden exceder los 200 caracteres.")]
        public string? DetallesDiabetesMellitus { get; set; }

        public bool? HipertensionArterial { get; set; }
        
        [StringLength(200, ErrorMessage = "Los detalles sobre hipertensión arterial no pueden exceder los 200 caracteres.")]
        public string? DetallesHipertensionArterial { get; set; }

        public bool? EnfermedadReumatica { get; set; }
        
        [StringLength(200, ErrorMessage = "Los detalles sobre enfermedad reumática no pueden exceder los 200 caracteres.")]
        public string? DetallesEnfermedadReumatica { get; set; }

        public bool? EnfermedadesRenales { get; set; }
        
        [StringLength(200, ErrorMessage = "Los detalles sobre enfermedades renales no pueden exceder los 200 caracteres.")]
        public string? DetallesEnfermedadesRenales { get; set; }

        public bool? EnfermedadesOculares { get; set; }
        
        [StringLength(200, ErrorMessage = "Los detalles sobre enfermedades oculares no pueden exceder los 200 caracteres.")]
        public string? DetallesEnfermedadesOculares { get; set; }

        public bool? EnfermedadesCardiacas { get; set; }
        
        [StringLength(200, ErrorMessage = "Los detalles sobre enfermedades cardíacas no pueden exceder los 200 caracteres.")]
        public string? DetallesEnfermedadesCardiacas { get; set; }

        public bool? EnfermedadHepatica { get; set; }
        
        [StringLength(200, ErrorMessage = "Los detalles sobre enfermedad hepática no pueden exceder los 200 caracteres.")]
        public string? DetallesEnfermedadHepatica { get; set; }

        public bool? EnfermedadesMusculares { get; set; }
        
        [StringLength(200, ErrorMessage = "Los detalles sobre enfermedades musculares no pueden exceder los 200 caracteres.")]
        public string? DetallesEnfermedadesMusculares { get; set; }

        public bool? MalformacionesCongenitas { get; set; }
        
        [StringLength(200, ErrorMessage = "Los detalles sobre malformaciones congénitas no pueden exceder los 200 caracteres.")]
        public string? DetallesMalformacionesCongenitas { get; set; }

        public bool? DesordenesMentales { get; set; }
        
        [StringLength(200, ErrorMessage = "Los detalles sobre desórdenes mentales no pueden exceder los 200 caracteres.")]
        public string? DetallesDesordenesMentales { get; set; }

        public bool? EnfermedadesDegenerativas { get; set; }
        
        [StringLength(200, ErrorMessage = "Los detalles sobre enfermedades degenerativas no pueden exceder los 200 caracteres.")]
        public string? DetallesEnfermedadesDegenerativas { get; set; }

        public bool? AnomaliasCrecimientoDesarrollo { get; set; }
        
        [StringLength(200, ErrorMessage = "Los detalles sobre anomalías de crecimiento y desarrollo no pueden exceder los 200 caracteres.")]
        public string? DetallesAnomaliasCrecimientoDesarrollo { get; set; }

        public bool? ErroresMetabolismo { get; set; }
        
        [StringLength(200, ErrorMessage = "Los detalles sobre errores de metabolismo no pueden exceder los 200 caracteres.")]
        public string? DetallesErroresMetabolismo { get; set; }

        public bool? Otros { get; set; }
        
        [StringLength(200, ErrorMessage = "Los detalles sobre otros no pueden exceder los 200 caracteres.")]
        public string? DetallesOtros { get; set; }
    }
}