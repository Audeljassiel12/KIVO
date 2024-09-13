using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
   public class EnfermedadesHereditarias
{
    public int Id { get; set; }

    public int PacienteId { get; set; }
    public Paciente? Paciente { get; set; }

    // Enfermedades hereditarias
    public bool? Alergias { get; set; }
     [StringLength(maximumLength: 121, MinimumLength = 50, ErrorMessage = "Los detalles no cumplen por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]

    public string? DetallesAlergias { get; set; }
    public bool? DiabetesMellitus { get; set; }
      [StringLength(maximumLength: 121, MinimumLength = 50, ErrorMessage = "Los detalles no cumplen por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]

        public string? DetallesDiabetesMellitus { get; set; }

    public bool? HipertensionArterial { get; set; }
      [StringLength(maximumLength: 121, MinimumLength = 50, ErrorMessage = "Los detalles no cumplen por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]

        public string? DetallesHipertensionArterial { get; set; }

    public bool? EnfermedadReumatica { get; set; }
     [StringLength(maximumLength: 121, MinimumLength = 50, ErrorMessage = "Los detalles no cumplen por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]

    public string? DetallesEnfermedadReumatica { get; set; }

    public bool? EnfermedadesRenales { get; set; }
     [StringLength(maximumLength: 121, MinimumLength = 50, ErrorMessage = "Los detalles no cumplen por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]

        public string? DetallesEnfermedadesRenales { get; set; }

    public bool? EnfermedadesOculares { get; set; }
     [StringLength(maximumLength: 121, MinimumLength = 50, ErrorMessage = "Los detalles no cumplen por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]

    public string? DetallesEnfermedadesOculares { get; set; }

    public bool? EnfermedadesCardiacas { get; set; }
     [StringLength(maximumLength: 121, MinimumLength = 50, ErrorMessage = "Los detalles no cumplen por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]

        public string? DetallesEnfermedadesCardiacas { get; set; }

    public bool? EnfermedadHepatica { get; set; }
     [StringLength(maximumLength: 121, MinimumLength = 50, ErrorMessage = "Los detalles no cumplen por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]

    public string? DetallesEnfermedadHepatica { get; set; }

    public bool? EnfermedadesMusculares { get; set; }
     [StringLength(maximumLength: 121, MinimumLength = 50, ErrorMessage = "Los detalles no cumplen por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]

    public string? DetallesEnfermedadesMusculares { get; set; }

    public bool? MalformacionesCongenitas { get; set; }
     [StringLength(maximumLength: 121, MinimumLength = 50, ErrorMessage = "Los detalles no cumplen por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]

            public string? DetallesMalformacionesCongenitas { get; set; }

    public bool? DesordenesMentales { get; set; }
     [StringLength(maximumLength: 121, MinimumLength = 50, ErrorMessage = "Los detalles no cumplen por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]

    public string? DetallesDesordenesMentales { get; set; }

    public bool? EnfermedadesDegenerativas { get; set; }
     [StringLength(maximumLength: 121, MinimumLength = 50, ErrorMessage = "Los detalles no cumplen por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]

    public string? DetallesEnfermedadesDegenerativas { get; set; }

    public bool? AnomaliasCrecimientoDesarrollo { get; set; }
     [StringLength(maximumLength: 121, MinimumLength = 50, ErrorMessage = "Los detalles no cumplen por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]

    public string? DetallesAnomaliasCrecimientoDesarrollo { get; set; }

    public bool? ErroresMetabolismo { get; set; }
     [StringLength(maximumLength: 121, MinimumLength = 50, ErrorMessage = "Los detalles no cumplen por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]

    public string? DetallesErroresMetabolismo { get; set; }

    public bool? Otros { get; set; }
     [StringLength(maximumLength: 121, MinimumLength = 50, ErrorMessage = "Los detalles no cumplen por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]

    public string? DetallesOtros { get; set; }
}

}