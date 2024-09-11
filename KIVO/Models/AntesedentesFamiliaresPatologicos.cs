using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
    public class AntecedentesFamiliaresPatologicos
{
    public int AntecedentesFamiliaresPatologicosId { get; set; }

    public int PacienteId { get; set; }
    public Paciente? Paciente { get; set; }

    // Enfermedades infecto-contagiosas
    public bool? Hepatitis { get; set; }
    public string? DetallesHepatitis { get; set; }

    public bool? Sifilis { get; set; }
    public string? DetallesSifilis { get; set; }

    public bool? TB { get; set; }
    public string? DetallesTB { get; set; }

    public bool? Colera { get; set; }
    public string? DetallesColera { get; set; }

    public bool? Amebiasis { get; set; }
    public string? DetallesAmebiasis { get; set; }

    public bool? Tosferina { get; set; }
    public string? DetallesTosferina { get; set; }

    public bool? Sarampion { get; set; }
    public string? DetallesSarampion { get; set; }

    public bool? Varicela { get; set; }
    public string? DetallesVaricela { get; set; }

    public bool? Rubéola { get; set; }
    public string? DetallesRubéola { get; set; }

    public bool? Parotiditis { get; set; }
    public string? DetallesParotiditis { get; set; }

    public bool? Meningitis { get; set; }
    public string? DetallesMeningitis { get; set; }

    public bool? Impetigo { get; set; }
    public string? DetallesImpetigo { get; set; }

    public bool? FiebreTifoidea { get; set; }
        public string? DetallesFiebreTifoidea { get; set; }

    public bool? Escarlatina { get; set; }
        public string? DetallesEscarlatina { get; set; }

    public bool? Malaria { get; set; }
        public string? DetallesMalaria { get; set; }

    public bool? Escabiosis { get; set; }
    public string? DetallesEscabiosis { get; set; }

    public bool? Pediculosis { get; set; }
    public string? DetallesPediculosis { get; set; }

    public bool? Tina { get; set; }
    public string? DetallesTina { get; set; }

    public bool? Otros { get; set; }
    public string? DetallesOtros { get; set; }
}

}