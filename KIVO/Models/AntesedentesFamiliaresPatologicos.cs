using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    [StringLength(maximumLength: 300, MinimumLength = 50, ErrorMessage = "Los detalles de la hepatitis no cumplen por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]
    public string? DetallesHepatitis { get; set; }

    public bool? Sifilis { get; set; }
    [StringLength(maximumLength: 300, MinimumLength = 50, ErrorMessage = "Los detalles de la sifilis no cumplen por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]
    public string? DetallesSifilis { get; set; }

    public bool? TB { get; set; }
    [StringLength(maximumLength: 300, MinimumLength = 50, ErrorMessage = "Los detalles no cumplen por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]
    public string? DetallesTB { get; set; }

    public bool? Colera { get; set; }
    [StringLength(maximumLength: 300, MinimumLength = 50, ErrorMessage = "Los detalles del colera no cumplen por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]

    public string? DetallesColera { get; set; }
    public bool? Amebiasis { get; set; }
    [StringLength(maximumLength: 300, MinimumLength = 50, ErrorMessage = "Los detalles de la amebiasis no cumplen por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]

    public string? DetallesAmebiasis { get; set; }

    public bool? Tosferina { get; set; }
    [StringLength(maximumLength: 300, MinimumLength = 50, ErrorMessage = "Los detalles de la tosferina no cumplen por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]

    public string? DetallesTosferina { get; set; }

    public bool? Sarampion { get; set; }
    [StringLength(maximumLength: 300, MinimumLength = 50, ErrorMessage = "Los detalles del saranpion no cumplen por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]
    public string? DetallesSarampion { get; set; }

    public bool? Varicela { get; set; }
    [StringLength(maximumLength: 300, MinimumLength = 50, ErrorMessage = "Los detalles de la varicela no cumplen por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]

    public string? DetallesVaricela { get; set; }
    public bool? Rubéola { get; set; }
    [StringLength(maximumLength: 300, MinimumLength = 50, ErrorMessage = "Los detalles de la rubéola no cumplen por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]

    public string? DetallesRubéola { get; set; }

    public bool? Parotiditis { get; set; }
    [StringLength(maximumLength: 300, MinimumLength = 50, ErrorMessage = "Los detalles de la parotiditis no cumplen por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]

    public string? DetallesParotiditis { get; set; }

    public bool? Meningitis { get; set; }
    [StringLength(maximumLength: 300, MinimumLength = 50, ErrorMessage = "Los detalles de la meningitis no cumplen por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]

    public string? DetallesMeningitis { get; set; }

    public bool? Impetigo { get; set; }
    [StringLength(maximumLength: 300, MinimumLength = 50, ErrorMessage = "Los detalles de el impetigo no cumplen por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]

    public string? DetallesImpetigo { get; set; }

    public bool? FiebreTifoidea { get; set; }
         [StringLength(maximumLength: 300, MinimumLength = 50, ErrorMessage = "Los detalles de la fiebre tipoidea  no cumplen por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]

        public string? DetallesFiebreTifoidea { get; set; }

    public bool? Escarlatina { get; set; }
        [StringLength(maximumLength: 300, MinimumLength = 50, ErrorMessage = "Los detalles de la escarlatina no cumplen por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]

        public string? DetallesEscarlatina { get; set; }

    public bool? Malaria { get; set; }
        [StringLength(maximumLength: 300, MinimumLength = 50, ErrorMessage = "Los detalles de la malaria no cumplen por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]

        public string? DetallesMalaria { get; set; }

    public bool? Escabiosis { get; set; }
    [StringLength(maximumLength: 300, MinimumLength = 50, ErrorMessage = "Los detalles de la escabiosis no cumplen por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]

    public string? DetallesEscabiosis { get; set; }

    public bool? Pediculosis { get; set; }
    [StringLength(maximumLength: 300, MinimumLength = 50, ErrorMessage = "Los detalles de la pediculosis no cumplen por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]

    public string? DetallesPediculosis { get; set; }

    public bool? Tina { get; set; }
    [StringLength(maximumLength: 300, MinimumLength = 50, ErrorMessage = "Los detalles no cumplen por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]

    public string? DetallesTina { get; set; }

    public bool? Otros { get; set; }
    [StringLength(maximumLength: 300, MinimumLength = 50, ErrorMessage = "Los detalles no cumplen por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]

    public string? DetallesOtros { get; set; } 
}

}