using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
   public class Paciente
{
  
    public User? User { get; set; }
    [ForeignKey("UserId"),Key]
    public string UserId { get; set; } = null!;
        [Required(ErrorMessage =" funciono")] //jajdajldkjldkaj  

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


    public CentroMedico? CentroMedico{ get; set; }
     public int CentroMedicoId { get; set; }

    public Cuidad? Ciudad { get; set; }
    public int CiudadId { get; set; }
    public Departamento? Departamento { get; set; }
    public int DepartamentoId { get; set; }


    
  
}
}