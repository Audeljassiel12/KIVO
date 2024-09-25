using KIVO.Models.Data.Repository.IRepository;

namespace KIVO.Models.Data.Repository.Repository
{
    public class CuidadRepositor : GenericoRepository<Cuidad, int>, ICuidadRepository
    {
        public CuidadRepositor(KivoDbContext kivoDbContext) : base(kivoDbContext)
        {
        }
    }
}
