namespace KIVO.Models
{   public enum TiposCentroMedico
    {
        Consultorio = 0,
        Clinica = 1
    }


    public class CentroMedico
    {
        [Key]
        public int Id { get; set; } // Clave primaria

        [Url(ErrorMessage = "El campo LogoUrl debe ser una URL válida.")]
        public string? LogoUrl { get; set; } = null!;

        [Required(ErrorMessage = "El nombre del centro médico es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        public string Nombre { get; set; } = null!; // Nombre del centro médico

        [StringLength(200, ErrorMessage = "La dirección no puede exceder los 200 caracteres.")]
        public string? Direccion { get; set; } // Dirección física

        [Phone(ErrorMessage = "El campo Teléfono debe ser un número de teléfono válido.")]
        [StringLength(15, ErrorMessage = "El número de teléfono no puede exceder los 15 caracteres.")]
        public string? Telefono { get; set; } // Número de teléfono

        [Url(ErrorMessage = "El campo SitioWeb debe ser una URL válida.")]
        public string? SitioWeb { get; set; } // Sitio web del centro médico

        [StringLength(100, ErrorMessage = "El horario de atención no puede exceder los 100 caracteres.")]
        public string? HorarioAtencion { get; set; } // Horario de atención

        [StringLength(500, ErrorMessage = "La descripción no puede exceder los 500 caracteres.")]
        public string? Descripcion { get; set; } // Descripción del centro médico

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaRegistro { get; set; } // Fecha de registro

        [Required(ErrorMessage = "El tipo de centro médico es obligatorio.")]
        public TiposCentroMedico TipoCentroMedico { get; set; }  // Tipos de centro médico

        [Required(ErrorMessage = "El campo CuidadId es obligatorio.")]
        public int CuidadId { get; set; }  // Clave foránea a Cuidad

        [Required(ErrorMessage = "El campo DepartamentoId es obligatorio.")]
        public int DepartamentoId { get; set; } // Clave foránea a Departamento

        [ForeignKey("CuidadId")]
        public Cuidad? Cuidad { get; set; } // Navegación a Cuidad

        [ForeignKey("DepartamentoId")]
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
