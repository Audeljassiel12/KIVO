namespace KIVO.Models.ViewModels
{
    public class OrganizacionViewModel
    {
        public string TipoOrganizacion { get; set; }
        public string NombreOrganizacion { get; set; } // Solo para clínica
        public string Especialidad { get; set; } // Solo para consultorio
        public string NombreClinica { get; set; } // Para consultorio
    }

}
