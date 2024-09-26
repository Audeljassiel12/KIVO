using KIVO.Models.Data.Repository.IRepository;
using KIVO.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace KIVO.Models.Data.Repository.Repository
{
    public class CentroMedicoRepositoy : GenericoRepository<CentroMedico ,int>, ICentroMedicoRepository
    {
        public CentroMedicoRepositoy(KivoDbContext kivoDbContext) : base(kivoDbContext)
        {
        }
        public async Task<EntidadCentroMedicoViewModel?> GetInfoConsultorioPorMedicoId(string medicoId)
        {
            return await EntityDeSet
                .Where(c => c.Medicos.Any(m => m.Id == medicoId)) // Filtra por médicos relacionados
                .Select(c => new EntidadCentroMedicoViewModel() {Direccion= c.Direccion, DepartamentoId = c.DepartamentoId,MunicipioId=c.CuidadId,NombreEntidad = c.Nombre} ) // Selecciona solo el nombre del consultorio
                .FirstOrDefaultAsync();
        }
    }
}
