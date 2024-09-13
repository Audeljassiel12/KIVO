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
        [Required(ErrorMessage ="Sus dos {0} son requeridos")] 
        [StringLength(maximumLength:30,MinimumLength = 7,ErrorMessage = "Sus dos {0} no cumplen por el limite de caracteres establecidos.")]
    public string Nombres { get; set; } = null!;
        [Required(ErrorMessage ="Sus dos {0} son requeridos")] 
        [StringLength(maximumLength:30,MinimumLength = 7,ErrorMessage = "Sus dos {0} no cumplen por el limite de caracteres establecidos.")]
    public string Apellidos { get; set; } = null!;
        [Required(ErrorMessage ="Su fecha de nacimiento es requerida")]  
        [StringLength(maximumLength:10,MinimumLength = 10,ErrorMessage = "Su fecha de nacimeiento no cumplen por el limite de caracteres establecidos y debe usar dia, mes y año separados por /. ")]
    public DateTime FechaNacimiento { get; set; }
        [Required(ErrorMessage ="El {0} es requerido")] 
        [StringLength(maximumLength:1,MinimumLength = 1,ErrorMessage = "Valor no valido. ingrese 'M' para Masculino o 'F' para Femenino.")]
    public string Sexo { get; set; } = null!;
        [StringLength(maximumLength:50,MinimumLength = 10,ErrorMessage = "La {0} es demaciada larga por favor ingrese una mas detallada.")]
    public string? Dirección { get; set; }  
        [StringLength(maximumLength:8,MinimumLength = 8,ErrorMessage = "El numero de {0} no cumple con los limites de caracteres establecidos.")]
    public string? Teléfono { get; set; } 
        [Required(ErrorMessage ="Su correo electronico es requerido")]  
        [StringLength(maximumLength:70,MinimumLength = 10,ErrorMessage = "Su correo electronico sobrepasa el limite de caracteres establecidos. ")]
    public string Email { get; set; } = null!;
        [StringLength(maximumLength:4,MinimumLength = 2,ErrorMessage = "Su tipo de sangre debe de tener entre {1} y {2} caracteres.")]
    public string? TipoSangre { get; set; } 
        [StringLength(maximumLength:25,MinimumLength = 2,ErrorMessage = "Su estado civil no cumple con los caracteres determinados.")]
    public string? EstadoCivil { get; set; } 
        [StringLength(maximumLength:100,MinimumLength = 3,ErrorMessage = "Su ocupacion sobrepasa el limite de carcteres establecidos.")]
    public string? Ocupación { get; set; }

    public DateTime FechaRegistro { get; set; }


    public CentroMedico? CentroMedico{ get; set; }
     public int CentroMedicoId { get; set; }
     [StringLength(maximumLength:50,MinimumLength = 3,ErrorMessage = "El nombre de su {0} no cumple con los limites de caracteres establecidos.")]
    public Cuidad? Ciudad { get; set; }
    public int CiudadId { get; set; }
    public Departamento? Departamento { get; set; }
    public int DepartamentoId { get; set; }


    
  
}
}