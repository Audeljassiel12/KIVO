using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
    public class AntecedentesFamiliaresPatologicos
    {
        [Key]
        public int AntecedentesFamiliaresPatologicosId { get; set; }

        [Required]
        public string PacienteId { get; set; }

        [ForeignKey("PacienteId")]
        public Paciente? Paciente { get; set; }

        // Enfermedades infecto-contagiosas

        public bool? Hepatitis { get; set; }

        [MaxLength(500, ErrorMessage = "Los detalles de Hepatitis no pueden superar los 500 caracteres.")]
        public string? DetallesHepatitis { get; set; }

        public bool? Sifilis { get; set; }

        [MaxLength(500, ErrorMessage = "Los detalles de Sífilis no pueden superar los 500 caracteres.")]
        public string? DetallesSifilis { get; set; }

        public bool? TB { get; set; }

        [MaxLength(500, ErrorMessage = "Los detalles de TB no pueden superar los 500 caracteres.")]
        public string? DetallesTB { get; set; }

        public bool? Colera { get; set; }

        [MaxLength(500, ErrorMessage = "Los detalles de Cólera no pueden superar los 500 caracteres.")]
        public string? DetallesColera { get; set; }

        public bool? Amebiasis { get; set; }

        [MaxLength(500, ErrorMessage = "Los detalles de Amebiasis no pueden superar los 500 caracteres.")]
        public string? DetallesAmebiasis { get; set; }

        public bool? Tosferina { get; set; }

        [MaxLength(500, ErrorMessage = "Los detalles de Tosferina no pueden superar los 500 caracteres.")]
        public string? DetallesTosferina { get; set; }

        public bool? Sarampion { get; set; }

        [MaxLength(500, ErrorMessage = "Los detalles de Sarampión no pueden superar los 500 caracteres.")]
        public string? DetallesSarampion { get; set; }

        public bool? Varicela { get; set; }

        [MaxLength(500, ErrorMessage = "Los detalles de Varicela no pueden superar los 500 caracteres.")]
        public string? DetallesVaricela { get; set; }

        public bool? Rubéola { get; set; }

        [MaxLength(500, ErrorMessage = "Los detalles de Rubéola no pueden superar los 500 caracteres.")]
        public string? DetallesRubeola { get; set; }

        public bool? Parotiditis { get; set; }

        [MaxLength(500, ErrorMessage = "Los detalles de Parotiditis no pueden superar los 500 caracteres.")]
        public string? DetallesParotiditis { get; set; }

        public bool? Meningitis { get; set; }

        [MaxLength(500, ErrorMessage = "Los detalles de Meningitis no pueden superar los 500 caracteres.")]
        public string? DetallesMeningitis { get; set; }

        public bool? Impetigo { get; set; }

        [MaxLength(500, ErrorMessage = "Los detalles de Impétigo no pueden superar los 500 caracteres.")]
        public string? DetallesImpetigo { get; set; }

        public bool? FiebreTifoidea { get; set; }

        [MaxLength(500, ErrorMessage = "Los detalles de Fiebre Tifoidea no pueden superar los 500 caracteres.")]
        public string? DetallesFiebreTifoidea { get; set; }

        public bool? Escarlatina { get; set; }

        [MaxLength(500, ErrorMessage = "Los detalles de Escarlatina no pueden superar los 500 caracteres.")]
        public string? DetallesEscarlatina { get; set; }

        public bool? Malaria { get; set; }

        [MaxLength(500, ErrorMessage = "Los detalles de Malaria no pueden superar los 500 caracteres.")]
        public string? DetallesMalaria { get; set; }

        public bool? Escabiosis { get; set; }

        [MaxLength(500, ErrorMessage = "Los detalles de Escabiosis no pueden superar los 500 caracteres.")]
        public string? DetallesEscabiosis { get; set; }

        public bool? Pediculosis { get; set; }

        [MaxLength(500, ErrorMessage = "Los detalles de Pediculosis no pueden superar los 500 caracteres.")]
        public string? DetallesPediculosis { get; set; }

        public bool? Tina { get; set; }

        [MaxLength(500, ErrorMessage = "Los detalles de Tiña no pueden superar los 500 caracteres.")]
        public string? DetallesTina { get; set; }

        public bool? Otros { get; set; }

        [MaxLength(500, ErrorMessage = "Los detalles de otras enfermedades no pueden superar los 500 caracteres.")]
        public string? DetallesOtros { get; set; }
    }
}