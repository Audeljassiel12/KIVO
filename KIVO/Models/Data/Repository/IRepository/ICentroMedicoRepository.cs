using KIVO.Models.Data.Repository.Repository;
using KIVO.Models.ViewModels;
using KIVO.Repository.IRepository;

namespace KIVO.Models.Data.Repository.IRepository
{
    public interface ICentroMedicoRepository:IGenericRepository<CentroMedico,int>
    {
        Task<EntidadCentroMedicoViewModel?> GetInfoConsultorioPorMedicoId(string medicoId);
    }
}
