using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
    public enum ParteDelCuerpo
    {
        [Display(Name = "Parte posterior del torso")]
        PartePosteriorDelTorso,

        [Display(Name = "Parte frontal del miembro inferior izquierdo")]
        ParteFrontalDelMiembroInferiorIzquierdo,

        [Display(Name = "Parte posterior del miembro inferior izquierdo")]
        PartePosteriorDelMiembroInferiorIzquierdo,

        [Display(Name = "Parte frontal del miembro inferior derecho")]
        ParteFrontalDelMiembroInferiorDerecho,

        [Display(Name = "Parte posterior del miembro inferior derecho")]
        PartePosteriorDelMiembroInferiorDerecho,

        [Display(Name = "Zona frontal pélvica")]
        ZonaFrontalPelvica,

        [Display(Name = "Zona pélvica espalda")]
        ZonaPelvicaEspalda,

        [Display(Name = "Parte frontal del miembro superior derecho")]
        ParteFrontalDelMiembroSuperiorDerecho,

        [Display(Name = "Parte posterior del miembro superior derecho")]
        PartePosteriorDelMiembroSuperiorDerecho,

        [Display(Name = "Parte delantera del torso")]
        ParteDelanteraDelTorso,

        [Display(Name = "Parte frontal del miembro superior izquierdo")]
        ParteFrontalDelMiembroSuperiorIzquierdo,

        [Display(Name = "Parte posterior del miembro superior izquierdo")]
        PartePosteriorDelMiembroSuperiorIzquierdo,

        [Display(Name = "Parte frontal de la cabeza")]
        ParteFrontalDeLaCabeza,

        [Display(Name = "Parte posterior de la cabeza")]
        PartePosteriorDeLaCabeza,

        [Display(Name = "Parte delantera del cuello")]
        ParteDelanteraDelCuello,

        [Display(Name = "Parte posterior del cuello")]
        PartePosteriorDelCuello
    }

    public class ExploracionTopografica
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El ID de la cita es obligatorio.")]
        public int CitaId { get; set; }

        public Cita? Cita { get; set; }

        [Required(ErrorMessage = "La parte del cuerpo es obligatoria.")]
        public ParteDelCuerpo ParteDelCuerpo { get; set; }  

        [StringLength(500, ErrorMessage = "Las observaciones no pueden exceder los 500 caracteres.")]
        public string? Observaciones { get; set; }
    }
}