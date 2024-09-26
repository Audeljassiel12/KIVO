using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
   public class EnfermedadesHereditarias
{
    public int Id { get; set; }

    public string PacienteId { get; set; }
    public Paciente? Paciente { get; set; }

    // Enfermedades hereditarias
    public bool? Alergias { get; set; }
    public string? DetallesAlergias { get; set; }

    public bool? DiabetesMellitus { get; set; }
        public string? DetallesDiabetesMellitus { get; set; }

    public bool? HipertensionArterial { get; set; }
        public string? DetallesHipertensionArterial { get; set; }

    public bool? EnfermedadReumatica { get; set; }
    public string? DetallesEnfermedadReumatica { get; set; }

    public bool? EnfermedadesRenales { get; set; }
        public string? DetallesEnfermedadesRenales { get; set; }

    public bool? EnfermedadesOculares { get; set; }
    public string? DetallesEnfermedadesOculares { get; set; }

    public bool? EnfermedadesCardiacas { get; set; }
        public string? DetallesEnfermedadesCardiacas { get; set; }

    public bool? EnfermedadHepatica { get; set; }
    public string? DetallesEnfermedadHepatica { get; set; }

    public bool? EnfermedadesMusculares { get; set; }
    public string? DetallesEnfermedadesMusculares { get; set; }

    public bool? MalformacionesCongenitas { get; set; }
            public string? DetallesMalformacionesCongenitas { get; set; }

    public bool? DesordenesMentales { get; set; }
    public string? DetallesDesordenesMentales { get; set; }

    public bool? EnfermedadesDegenerativas { get; set; }
    public string? DetallesEnfermedadesDegenerativas { get; set; }

    public bool? AnomaliasCrecimientoDesarrollo { get; set; }
    public string? DetallesAnomaliasCrecimientoDesarrollo { get; set; }

    public bool? ErroresMetabolismo { get; set; }
    public string? DetallesErroresMetabolismo { get; set; }

    public bool? Otros { get; set; }
    public string? DetallesOtros { get; set; }
}

}