using KIVO.Models.Data.Repository.IRepository;

namespace KIVO.Models.Data.Repository.Repository
{
    public class EspecialidadRepository : GenericoRepository<EspecialidadMedica, int>, IEspesialidadRepository
    {
        public EspecialidadRepository(KivoDbContext kivoDbContext) : base(kivoDbContext)
        {
        }
    }
}
