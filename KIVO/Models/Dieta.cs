using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
    public enum NivelDeApetito
    {
        Excesivo = 0,
        Bien = 1,
        Justo = 2,
        Pobre = 3,
        Ninguno = 4
    }

    public class Dieta
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El ID del paciente es obligatorio.")]
        public string PacienteId { get; set; } // FK a Paciente

        [ForeignKey("PacienteId")]
        public Paciente? Paciente { get; set; }

        // Comidas
        public bool? Desayuno { get; set; }
        
        [StringLength(200, ErrorMessage = "Los detalles del desayuno no pueden exceder los 200 caracteres.")]
        public string? DetallesDesayuno { get; set; }

        public bool? MananaDeColacion { get; set; }
        
        [StringLength(200, ErrorMessage = "Los detalles de la mañana de colación no pueden exceder los 200 caracteres.")]
        public string? DetallesMananaDeColacion { get; set; }

        public bool? Almuerzo { get; set; }
        
        [StringLength(200, ErrorMessage = "Los detalles del almuerzo no pueden exceder los 200 caracteres.")]
        public string? DetallesAlmuerzo { get; set; }

        public bool? TardeDeColacion { get; set; }
        
        [StringLength(200, ErrorMessage = "Los detalles de la tarde de colación no pueden exceder los 200 caracteres.")]
        public string? DetallesTardeDeColacion { get; set; }

        public bool? Cena { get; set; }
        
        [StringLength(200, ErrorMessage = "Los detalles de la cena no pueden exceder los 200 caracteres.")]
        public string? DetallesCena { get; set; }

        public bool? PreparadoEnCasa { get; set; }
        
        [StringLength(200, ErrorMessage = "Los detalles de preparado en casa no pueden exceder los 200 caracteres.")]
        public string? DetallesPreparadoEnCasa { get; set; }

        // Nivel de apetito
        public NivelDeApetito? NivelDeApetito { get; set; }  // Excesivo, Bien, Justo, Pobre, Ninguno

        // Saciedad
        public bool? Saciedad { get; set; }
        
        [StringLength(200, ErrorMessage = "Los detalles sobre saciedad no pueden exceder los 200 caracteres.")]
        public string? DetallesSaciedad { get; set; }  // Detalles adicionales sobre saciedad

        // Número de vasos de agua al día
        [StringLength(50, ErrorMessage = "El número de vasos de agua no puede exceder los 50 caracteres.")]
        public string? NumeroDeVasosDeAgua { get; set; }  // 1 o menos, 2 a 3, 4 o más

        // Preferencias alimentarias
        [StringLength(200, ErrorMessage = "Las preferencias alimentarias no pueden exceder los 200 caracteres.")]
        public string? PreferenciasAlimentarias { get; set; }

        // Enfermedades alimentarias
        public bool? EnfermedadesAlimentarias { get; set; }
        
        [StringLength(200, ErrorMessage = "Los detalles sobre enfermedades alimentarias no pueden exceder los 200 caracteres.")]
        public string? DetallesEnfermedadesAlimentarias { get; set; }

        // Suplementos
        public bool? Suplementos { get; set; }
        
        [StringLength(200, ErrorMessage = "Los detalles sobre suplementos no pueden exceder los 200 caracteres.")]
        public string? DetallesSuplementos { get; set; }

        // Dietas pasadas
        public bool? DietasPasadas { get; set; }
        
        [StringLength(200, ErrorMessage = "Los detalles sobre dietas pasadas no pueden exceder los 200 caracteres.")]
        public string? DetallesDietasPasadas { get; set; }

        // Peso ideal
        [StringLength(50, ErrorMessage = "El peso ideal no puede exceder los 50 caracteres.")]
        public string? PesoIdeal { get; set; }
        
        [StringLength(200, ErrorMessage = "Los detalles sobre el peso ideal no pueden exceder los 200 caracteres.")]
        public string? DetallesPesoIdeal { get; set; }

        // Enfermedades actuales relacionadas con el peso
        public bool? EnfermedadesActualesRelacionadasConElPeso { get; set; }
        
        [StringLength(200, ErrorMessage = "Los detalles sobre enfermedades actuales relacionadas con el peso no pueden exceder los 200 caracteres.")]
        public string? DetallesEnfermedadesActualesRelacionadasConElPeso { get; set; }  

        // Dolencias pasadas relacionadas con el peso
        public bool? DolenciasPasadasRelacionadasConElPeso { get; set; }
        
        [StringLength(200, ErrorMessage = "Los detalles sobre dolencias pasadas relacionadas con el peso no pueden exceder los 200 caracteres.")]
        public string? DetallesDolenciasPasadasRelacionadasConElPeso { get; set; }

        // Ingesta de líquidos
        public bool? IngestaDeLiquidos { get; set; }
        
        [StringLength(200, ErrorMessage = "Los detalles sobre ingesta de líquidos no pueden exceder los 200 caracteres.")]
        public string? DetallesIngestaDeLiquidos { get; set; }

        // Educación nutricional
        public bool? EducacionNutricional { get; set; }
        
        [StringLength(200, ErrorMessage = "Los detalles sobre educación nutricional no pueden exceder los 200 caracteres.")]
        public string? DetallesEducacionNutricional { get; set; }

        // Otros
        public bool? Otros { get; set; }
        
        [StringLength(200, ErrorMessage = "Los detalles sobre otros no pueden exceder los 200 caracteres.")]
        public string? DetallesOtros { get; set; }
    }
}