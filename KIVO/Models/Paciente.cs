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
        public string? Id { get; set; }  // Identificador único del paciente.

        public User? User { get; set; }  // Relación con el objeto User.
        
        [ForeignKey("UserId")]
        public string? UserId { get; set; } = null!;  // Clave foránea hacia la tabla de usuarios.

        public string Nombres { get; set; } = null!;  // Nombres del paciente.
        
        public string Apellidos { get; set; } = null!;  // Apellidos del paciente.

        public DateTime FechaNacimiento { get; set; }  // Fecha de nacimiento del paciente.

        public string Genero { get; set; } = null!;  // Género del paciente.
        
        public string? Dirección { get; set; }  // Dirección del paciente.

        [PhoneNumber("NI", ErrorMessage = "El número de teléfono no es válido")]
        public string? Teléfono { get; set; }  // Número de teléfono del paciente.

        public string Email { get; set; } = null!;  // Correo electrónico del paciente.

        public string? TipoSangre { get; set; }  // Tipo de sangre del paciente.

        public string? EstadoCivil { get; set; }  // Estado civil del paciente.

        public string? Ocupación { get; set; }  // Ocupación del paciente.

        public string? FotoPerfilUrl { get; set; }  // URL de la foto de perfil del paciente.

        public DateTime FechaRegistro { get; set; }  // Fecha en que se registró el paciente en el sistema.

        public CentroMedico? CentroMedico { get; set; }  // Relación con el centro médico.

        public int CentroMedicoId { get; set; }  // ID del centro médico relacionado.

        public Cuidad? Ciudad { get; set; }  // Relación con la ciudad de residencia.

        public int? CiudadId { get; set; }  // ID de la ciudad relacionada.

        public Departamento? Departamento { get; set; }  // Relación con el departamento.

        public int? DepartamentoId { get; set; }  // ID del departamento relacionado.

        public List<Cita> Cita { get; set; }  // Lista de citas que el paciente tiene programadas.
    }
}
