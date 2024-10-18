using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
    public class HistoriaPsiquiatrica
    {
        public int Id { get; set; } // Identificador único para la historia psiquiátrica.

        public string PacienteId { get; set; } // Identificador del paciente.
        public Paciente? Paciente { get; set; } // Relación con el modelo Paciente.

        // Campos booleanos con detalles opcionales
        public bool? ConcienciaEnfermedad { get; set; } // Indica si el paciente es consciente de su enfermedad.
        public string? DetallesConcienciaEnfermedad { get; set; } // Detalles sobre el impacto de la enfermedad en la vida del paciente.

        public bool? ApoyoFamiliaresAmigos { get; set; } // Indica si el paciente recibe apoyo de familiares y amigos.
        public string? DetallesApoyoFamiliaresAmigos { get; set; } // Detalles sobre el apoyo de familiares y amigos.

        public bool? VidaFamiliar { get; set; } // Información sobre la vida familiar del paciente.
        public bool? VidaSocial { get; set; } // Información sobre la vida social del paciente.
        public bool? VidaLaboral { get; set; } // Información sobre la vida laboral del paciente.
        public bool? RelacionConAutoridad { get; set; } // Información sobre la relación del paciente con la autoridad.
        public bool? ControlImpulsos { get; set; } // Información sobre la capacidad del paciente para controlar sus impulsos.
        public bool? LidiaConEstres { get; set; } // Información sobre cómo el paciente maneja el estrés.

        public string? DetallesVidaFamiliar { get; set; } // Detalles sobre la vida familiar.
        public string? DetallesVidaSocial { get; set; } // Detalles sobre la vida social.
        public string? DetallesVidaLaboral { get; set; } // Detalles sobre la vida laboral.
        public string? DetallesRelacionConAutoridad { get; set; } // Detalles sobre la relación con la autoridad.
        public string? DetallesControlImpulsos { get; set; } // Detalles sobre el control de impulsos.
        public string? DetallesLidiaConEstres { get; set; } // Detalles sobre cómo lidia con el estrés.
    }
}