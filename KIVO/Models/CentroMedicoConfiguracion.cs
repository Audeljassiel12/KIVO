using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
   
    public class CentroMedicoConfiguracion
{
    public int CentroMedicoId { get; set; }
    public CentroMedico? CentroMedico { get; set; }

    public int ConfiguracionId { get; set; }
    public Configuracion? Configuracion { get; set; }

    public bool EstaActivado { get; set; }
    public ICollection<CentroMedicoSubConfiguracion>? CentroMedicoSubConfiguraciones { get; set; }
}

}