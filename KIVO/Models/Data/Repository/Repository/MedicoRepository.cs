using KIVO.Models.Data.Repository.IRepository;

namespace KIVO.Models.Data.Repository.Repository
{
    public class MedicoRepository : GenericoRepository<Medico, string>, IMedicoRepository
    {
        public MedicoRepository(KivoDbContext kivoDbContext) : base(kivoDbContext)
        {
        }
    }
}
