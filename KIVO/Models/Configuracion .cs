using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
   public class Configuracion
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public bool EsActivable { get; set; }
    public ICollection<SubConfiguracion> SubConfiguraciones { get; set; }
    public ICollection<CentroMedicoConfiguracion> CentroMedicoConfiguraciones { get; set; }
}

}