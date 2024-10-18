using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
    public class HistoriaPostnatal
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El ID del paciente es obligatorio.")]
        public string PacienteId { get; set; }
        public Paciente? Paciente { get; set; }

        // Revisión del nacimiento
        public bool? RevisionNacimiento { get; set; }
        [StringLength(500, ErrorMessage = "Los detalles de la revisión no pueden exceder los 500 caracteres.")]
        public string? DetallesRevisionNacimiento { get; set; }

        // Datos del bebé
        [StringLength(100, ErrorMessage = "El nombre del bebé no puede exceder los 100 caracteres.")]
        public string? NombreBebe { get; set; }
        [Range(0, 10, ErrorMessage = "El peso al nacer debe estar entre 0 y 10 kg.")]
        public decimal? PesoAlNacer { get; set; }  // Peso en kg

        // Salud del bebé
        public bool? SaludBebe { get; set; }
        [StringLength(500, ErrorMessage = "Los detalles de la salud del bebé no pueden exceder los 500 caracteres.")]
        public string? DetallesSaludBebe { get; set; }

        // Alimentación infantil
        public bool? AlimentacionInfantil { get; set; }
        [StringLength(100, ErrorMessage = "El tipo de alimentación no puede exceder los 100 caracteres.")]
        public string? TipoAlimentacion { get; set; }  // Ej: Leche materna, Sustituto, Ambos

        // Estado emocional
        public bool? EstadoEmocional { get; set; }
        [StringLength(500, ErrorMessage = "Los detalles del estado emocional no pueden exceder los 500 caracteres.")]
        public string? DetallesEstadoEmocional { get; set; }
    }
}