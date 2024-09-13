using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
    public enum NivelDeApetito
    {
        Excesivo =0,
        Bien =1,
        Justo =2,
        Pobre =3,
        Ninguno =4
    }
    

   public class Dieta
{
    public int Id { get; set; }

    public int PacienteId { get; set; }
    public Paciente? Paciente { get; set; }

    // Comidas
    public bool? Desayuno { get; set; }
     [StringLength(maximumLength: 300, MinimumLength = 50, ErrorMessage = "Los detalles no cumplen por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]

    public string? DetallesDesayuno { get; set; }

    public bool? MananaDeColacion { get; set; }
     [StringLength(maximumLength: 300, MinimumLength = 50, ErrorMessage = "Los detalles no cumplen por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]

    public string? DetallesMananaDeColacion { get; set; }

    public bool? Almuerzo { get; set; }
     [StringLength(maximumLength: 300, MinimumLength = 50, ErrorMessage = "Los detalles no cumplen por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]

    public string? DetallesAlmuerzo { get; set; }

    public bool? TardeDeColacion { get; set; }
     [StringLength(maximumLength: 300, MinimumLength = 50, ErrorMessage = "Los detalles no cumplen por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]

    public string? DetallesTardeDeColacion { get; set; }

    public bool? Cena { get; set; }
     [StringLength(maximumLength: 300, MinimumLength = 50, ErrorMessage = "Los detalles no cumplen por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]

    public string? DetallesCena { get; set; }

    public bool? PreparadoEnCasa { get; set; }
     [StringLength(maximumLength: 300, MinimumLength = 50, ErrorMessage = "Los detalles no cumplen por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]

    public string? DetallesPreparadoEnCasa { get; set; }

    // Nivel de apetito
    public NivelDeApetito? NivelDeApetito { get; set; }  // Excesivo, Bien, Justo, Pobre, Ninguno

    // Saciedad
    public bool? Saciedad { get; set; }
     [StringLength(maximumLength: 300, MinimumLength = 50, ErrorMessage = "Los detalles no cumplen por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]

    public string? DetallesSaciedad { get; set; }  // Detalles adicionales sobre saciedad

    // Número de vasos de agua al día
    public string? NumeroDeVasosDeAgua { get; set; }  // 1 o menos, 2 a 3, 4 o más

    // Preferencias alimentarias
    public string? PreferenciasAlimentarias { get; set; }

    // Enfermedades alimentarias
    public bool? EnfermedadesAlimentarias { get; set; }
     [StringLength(maximumLength: 300, MinimumLength = 50, ErrorMessage = "Los detalles no cumplen por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]

    public string? DetallesEnfermedadesAlimentarias { get; set; }

    // Suplementos
    public bool? Suplementos { get; set; }
     [StringLength(maximumLength: 300, MinimumLength = 50, ErrorMessage = "Los detalles no cumplen por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]

        public string? DetallesSuplementos { get; set; }

    // Dietas pasadas
    public bool? DietasPasadas { get; set; }
     [StringLength(maximumLength: 300, MinimumLength = 50, ErrorMessage = "Los detalles no cumplen por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]

    public string? DetallesDietasPasadas { get; set; }

    // Peso ideal
    public string? PesoIdeal { get; set; }
     [StringLength(maximumLength: 300, MinimumLength = 50, ErrorMessage = "Los detalles no cumplen por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]

    public string? DetallesPesoIdeal { get; set; }

    // Enfermedades actuales relacionadas con el peso
    public bool? EnfermedadesActualesRelacionadasConElPeso { get; set; }
     [StringLength(maximumLength: 300, MinimumLength = 50, ErrorMessage = "Los detalles no cumplen por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]

    public string? DetallesEnfermedadesActualesRelacionadasConElPeso { get; set; }  

    // Dolencias pasadas relacionadas con el peso
    public bool? DolenciasPasadasRelacionadasConElPeso { get; set; }
     [StringLength(maximumLength: 300, MinimumLength = 50, ErrorMessage = "Los detalles no cumplen por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]

    public string? DetallesDolenciasPasadasRelacionadasConElPeso { get; set; }

    // Ingesta de líquidos
    public bool? IngestaDeLiquidos { get; set; }
     [StringLength(maximumLength: 300, MinimumLength = 50, ErrorMessage = "Los detalles no cumplen por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]

    public string? DetallesIngestaDeLiquidos { get; set; }

    // Educación nutricional
    public bool? EducacionNutricional { get; set; }
     [StringLength(maximumLength: 300, MinimumLength = 50, ErrorMessage = "Los detalles no cumplen por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]

    public string? DetallesEducacionNutricional { get; set; }

    // Otros
    public bool? Otros { get; set; }
     [StringLength(maximumLength: 300, MinimumLength = 50, ErrorMessage = "Los detalles no cumplen por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]

    public string? DetallesOtros { get; set; }
}

}