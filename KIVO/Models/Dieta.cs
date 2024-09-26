using System;
using System.Collections.Generic;
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

    public string PacienteId { get; set; }
    public Paciente? Paciente { get; set; }

    // Comidas
    public bool? Desayuno { get; set; }
    public string? DetallesDesayuno { get; set; }

    public bool? MananaDeColacion { get; set; }
    public string? DetallesMananaDeColacion { get; set; }

    public bool? Almuerzo { get; set; }
    public string? DetallesAlmuerzo { get; set; }

    public bool? TardeDeColacion { get; set; }
    public string? DetallesTardeDeColacion { get; set; }

    public bool? Cena { get; set; }
    public string? DetallesCena { get; set; }

    public bool? PreparadoEnCasa { get; set; }
    public string? DetallesPreparadoEnCasa { get; set; }

    // Nivel de apetito
    public NivelDeApetito? NivelDeApetito { get; set; }  // Excesivo, Bien, Justo, Pobre, Ninguno

    // Saciedad
    public bool? Saciedad { get; set; }
    public string? DetallesSaciedad { get; set; }  // Detalles adicionales sobre saciedad

    // Número de vasos de agua al día
    public string? NumeroDeVasosDeAgua { get; set; }  // 1 o menos, 2 a 3, 4 o más

    // Preferencias alimentarias
    public string? PreferenciasAlimentarias { get; set; }

    // Enfermedades alimentarias
    public bool? EnfermedadesAlimentarias { get; set; }
    public string? DetallesEnfermedadesAlimentarias { get; set; }

    // Suplementos
    public bool? Suplementos { get; set; }
        public string? DetallesSuplementos { get; set; }

    // Dietas pasadas
    public bool? DietasPasadas { get; set; }
    public string? DetallesDietasPasadas { get; set; }

    // Peso ideal
    public string? PesoIdeal { get; set; }
    public string? DetallesPesoIdeal { get; set; }

    // Enfermedades actuales relacionadas con el peso
    public bool? EnfermedadesActualesRelacionadasConElPeso { get; set; }
    public string? DetallesEnfermedadesActualesRelacionadasConElPeso { get; set; }  

    // Dolencias pasadas relacionadas con el peso
    public bool? DolenciasPasadasRelacionadasConElPeso { get; set; }
    public string? DetallesDolenciasPasadasRelacionadasConElPeso { get; set; }

    // Ingesta de líquidos
    public bool? IngestaDeLiquidos { get; set; }
    public string? DetallesIngestaDeLiquidos { get; set; }

    // Educación nutricional
    public bool? EducacionNutricional { get; set; }
    public string? DetallesEducacionNutricional { get; set; }

    // Otros
    public bool? Otros { get; set; }
    public string? DetallesOtros { get; set; }
}

}