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
        public string? HorarioAtencion { get; set; } // Horario de atención
        public string? Descripcion { get; set; } // Descripción del centro médico
        public DateTime FechaRegistro { get; set; } // Fecha de registro
        public TiposCentroMedico TipoCentroMedico { get; set; }  // Tipos de centro médico

        public int CuidadId { get; set; }  // Clave foránea a Cuidad
        public int DepartamentoId { get; set; } // Clave foránea a Departamento

        public Cuidad? Cuidad { get; set; } // Navegación a Cuidad
        public Departamento? Departamento { get; set; } // Navegación a Departamento

        public List<HorarioAtencion>? HorarioAtencions { get; set; }
        public List<Medico>? Medicos { get; set; }
        public List<Paciente>? Pacientes { get; set; }
        public List<Cita>? Citas { get; set; }
        public List<Suscripcion>? Suscripciones { get; set; }
        public List<InvitacionDoctor>? InvitacionDoctors { get; set; }
        public List<Producto>? Productos { get; set; }
    }


}
