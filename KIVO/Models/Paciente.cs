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
        [Key]  
     public string? Id { get; set; }
     public User? User { get; set; }
    [ForeignKey("UserId")]
    public string? UserId { get; set; } = null!;
    public string Nombres { get; set; } = null!;
    public string Apellidos { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public string Genero { get; set; } = null!;

    public string? Dirección { get; set; }
        [PhoneNumber("NI", ErrorMessage = "El numero de telefono no es valido")]
        public string? Teléfono { get; set; }

    public string Email { get; set; } = null!;

    public string? TipoSangre { get; set; }

    public string? EstadoCivil { get; set; }

    public string? Ocupación { get; set; }
      public string? FotoPerfilUrl { get; set; }

        public DateTime FechaRegistro { get; set; }


    public CentroMedico? CentroMedico{ get; set; }
     public int CentroMedicoId { get; set; }

    public Cuidad? Ciudad { get; set; }
        public int? CiudadId { get; set; } = null; 
    public Departamento? Departamento { get; set; }
        public int? DepartamentoId { get; set; } = null; 

     public List<Cita> Cita { get; set; }


    
  
}
}