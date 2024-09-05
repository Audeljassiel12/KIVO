using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
   public class PaCiente
{
    public int Id { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public string Sexo { get; set; } = null!;

    public string? Dirección { get; set; }

    public string? Teléfono { get; set; }

    public string Email { get; set; } = null!;

    public string? TipoSangre { get; set; }

    public string? EstadoCivil { get; set; }

    public string? Ocupación { get; set; }

    public DateTime FechaRegistro { get; set; }

    
  
}

}