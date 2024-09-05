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
        public string Nombre { get; set; } = null!; // Nombre del centro médico
        public string? Direccion { get; set; } // Dirección física
        public string? Telefono { get; set; } // Número de teléfono
        public string? SitioWeb { get; set; } // Sitio web del centro médico
        public string? HorarioAtencion { get; set; } // Horario de atención como cadena de texto (ej. "Lunes a Viernes 9:00 - 17:00")
        public string? Descripcion { get; set; } // Descripción del centro médico
        public DateTime FechaRegistro { get; set; } // Fecha en que se registró el centro
        public TiposCentroMedico TipoCentroMedico { get; set; }  // tipos de centro medico

        public List<HorarioAtencion>? horarioAtencions{ get; set; }
        public List<Doctor>? Doctors { get; set; }   
        public List<PaCiente>? PaCientes { get; set; }
        

        

     
    }
}
