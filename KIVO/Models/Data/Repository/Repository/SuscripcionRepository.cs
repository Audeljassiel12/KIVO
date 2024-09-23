using KIVO.Models.Data.Repository.IRepository;

namespace KIVO.Models.Data.Repository.Repository
{
    public class SuscripcionRepository : GenericoRepository<Suscripcion, int>, ISuscripcionRepository
    {
        public SuscripcionRepository(KivoDbContext kivoDbContext) : base(kivoDbContext)
        {
        }
    }
}
