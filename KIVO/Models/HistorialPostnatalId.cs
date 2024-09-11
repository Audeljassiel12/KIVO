using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
   public class HistoriaPostnatal
{
    public int Id { get; set; }

    public int PacienteId { get; set; }
    public Paciente? Paciente { get; set; }

    // Revisión del nacimiento
    public bool? RevisiónNacimiento { get; set; }
    public string? DetallesRevisionNacimiento { get; set; }

    // Datos del bebé
    public string? NombreBebe { get; set; }
    public decimal? PesoAlNacer { get; set; }  // Peso en kg

    // Salud del bebé
    public bool? SaludBebe { get; set; }
    public string? DetallesSaludBebe { get; set; }

    // Alimentación infantil
    public bool? AlimentacionInfantil { get; set; }
    public string? TipoAlimentacion { get; set; }  // Ej: Leche materna, Sustituto, Ambos

    // Estado emocional
    public bool? EstadoEmocional { get; set; }
    public string? DetallesEstadoEmocional { get; set; }
}

}