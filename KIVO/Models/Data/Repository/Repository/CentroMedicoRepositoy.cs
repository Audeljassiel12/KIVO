using KIVO.Models.Data.Repository.IRepository;

namespace KIVO.Models.Data.Repository.Repository
{
    public class CentroMedicoRepositoy : GenericoRepository<CentroMedico ,int>, ICentroMedicoRepository
    {
        public CentroMedicoRepositoy(KivoDbContext kivoDbContext) : base(kivoDbContext)
        {
        }
    }
}
