using System.ComponentModel.DataAnnotations;

namespace KIVO.Models
{   public enum TiposCentroMedico
    {
        Consultorio = 0,
        Clinica = 1
    }
   

    public class CentroMedico
    {
        public int Id { get; set; } // Clave primaria
        public string? LogoUrl { get; set; } = null!;
        [Required(ErrorMessage ="EL {0} del centro medico es requerido")] 
        [StringLength(maximumLength:120,MinimumLength = 70,ErrorMessage = "EL {0} de su centro medico no cumplen por el limite de caracteres establecidos.")]
        public string Nombre { get; set; } = null!; // Nombre del centro médico
        [Required(ErrorMessage ="La {0} de su centro medico es requerido")]  
        [StringLength(maximumLength:200,MinimumLength = 100,ErrorMessage = "La {0} es demaciada larga por favor ingrese una mas detallada.")]
        public string? Direccion { get; set; } // Dirección física
        [Required(ErrorMessage ="El numero de {0} es requerido")] 
        [StringLength(maximumLength:10,MinimumLength = 8,ErrorMessage = "El numero de {0} no cumple con los limites de caracteres establecidos.")]
        public string? Telefono { get; set; } // Número de teléfono
        public string? SitioWeb { get; set; } // Sitio web del centro médico
        public string? HorarioAtencion { get; set; } // Horario de atención como cadena de texto (ej. "Lunes a Viernes 9:00 - 17:00")
        [Required(ErrorMessage ="La {0} de su centro medico es requerido")] 
        [StringLength(maximumLength:300,MinimumLength = 150,ErrorMessage = "La {0} de su centro medico no cumple con los limites de caracteres establecidos.")]
        public string? Descripcion { get; set; } // Descripción del centro médico
        public DateTime FechaRegistro { get; set; } // Fecha en que se registró el centro
        [Required(ErrorMessage ="El tipo de centro medico es requerido")] 
        [StringLength(maximumLength:10,MinimumLength = 8,ErrorMessage = "El tipo de centro medico no cumple con los limites de caracteres establecidos.")]
        public TiposCentroMedico TipoCentroMedico { get; set; }  // tipos de centro medico
    
         public int? CuidadId {get;set;}  // fk a cuidad
         public int? DepartamentoId {get; set; }
        [Required(ErrorMessage ="Su {0} es requerido")] 
        [StringLength(maximumLength:50,MinimumLength = 25,ErrorMessage = "El nombre de su {0} no cumple con los limites de caracteres establecidos.")]
        public Cuidad? Cuidad{ get; set; }
        [Required(ErrorMessage ="Su {0} es requerido")] 
        [StringLength(maximumLength:60,MinimumLength = 30,ErrorMessage = "El nombre de su {0} no cumple con los limites de caracteres establecidos.")]
        public Departamento? Departamento {get;set;}
        public List<HorarioAtencion>? horarioAtencions{ get; set; }
      
        public List<Medico>? medicos { get; set; }   
        public List<Paciente>? PaCientes { get; set; }
        public List<Cita>? Citas { get; set; }
        
        public List<Suscripcion>? Suscripcions{ get; set; }
      
        public List<InvitacionDoctor>? InvitacionDoctors {get;set;} 

        public List<Producto>? Productos{ get; set; }

        

     
    }
}
