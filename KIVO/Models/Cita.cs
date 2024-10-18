using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
    public enum EstadoDeCita
    {
        Programada = 1,
        Proceso = 2,
        Finalizada = 3,
        Cancelada = 4
    }

    public class Cita
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La fecha de la cita es obligatoria.")]
        [DataType(DataType.Date)]
        public DateTime FechaCita { get; set; }

        [Required(ErrorMessage = "El motivo de la cita es obligatorio.")]
        [StringLength(200, ErrorMessage = "El motivo no puede exceder los 200 caracteres.")]
        public string Motivo { get; set; } = null!;

        [Required(ErrorMessage = "El estado de la cita es obligatorio.")]
        public EstadoDeCita EstadoDeCita { get; set; } // FK a EstadoCita

        // Anclas Relacion 
        [Required(ErrorMessage = "El paciente es obligatorio.")]
        public string PacienteId { get; set; } // Fk a Paciente
        [ForeignKey("PacienteId")]
        public Paciente? Paciente { get; set; }

        [Required(ErrorMessage = "El médico es obligatorio.")]
        public string MedicoId { get; set; } // Fk a Doctor
        [ForeignKey("MedicoId")]
        public Medico? Medico { get; set; }

        [Required(ErrorMessage = "El centro médico es obligatorio.")]
        public int CentroMedicoId { get; set; } // Fk a CentroMedico
        [ForeignKey("CentroMedicoId")]
        public CentroMedico? CentroMedico { get; set; }

        // Relacion de RecetaMedica
        public int? RecetaId { get; set; } // Fk a Receta
        [ForeignKey("RecetaId")]
        public Receta? Receta { get; set; }

        public int SignosVitalesId { get; set; } // Fk a SignosVitales  
        [ForeignKey("SignosVitalesId")]
        public SignosVitales? SignosVitales { get; set; }

        // Relacion de ExploracionTopografica
        public int? ExploracionTopograficaId { get; set; } // Fk a ExploracionTopografica
        [ForeignKey("ExploracionTopograficaId")]
        public ExploracionTopografica? ExploracionTopografica { get; set; }

        // Relacion de ResultadoLaboratorio
        public int? ResultadoLaboratorioId { get; set; } // Fk a ResultadoLaboratorio
        [ForeignKey("ResultadoLaboratorioId")]
        public ResultadoLaboratorio? ResultadoLaboratorio { get; set; }

        // Relacion de Nutricion
        public int? NutricionId { get; set; } // Fk a Nutricion
        [ForeignKey("NutricionId")]
        public Nutricion? Nutricion { get; set; }

        // Relacion de ExamenFisico
        public List<NotaDeEncuentro>? NotaDeEncuentros { get; set; }
    }
}