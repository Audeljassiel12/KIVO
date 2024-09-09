using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
    public class CentroMedicoSubConfiguracion
{
    public int CentroMedicoId { get; set; }
    public CentroMedico? CentroMedico { get; set; }

    public int SubConfiguracionId { get; set; }
    public SubConfiguracion? SubConfiguracion { get; set; }

    public bool EstaActivado { get; set; }
}

}