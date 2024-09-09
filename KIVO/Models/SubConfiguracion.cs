using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
   public class SubConfiguracion
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!; 
    public int ConfiguracionId { get; set; }
    public Configuracion? Configuracion { get; set; }
}

}