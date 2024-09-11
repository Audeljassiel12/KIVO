using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
   

   using System.ComponentModel.DataAnnotations;

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
    public int CitaId { get; set; }
    public Cita? Cita { get; set; }
    public ParteDelCuerpo ParteDelCuerpo { get; set; }  

    public string? Observaciones { get; set; }
 
}

}