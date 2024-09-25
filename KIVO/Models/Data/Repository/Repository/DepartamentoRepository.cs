using KIVO.Models.Data.Repository.IRepository;

namespace KIVO.Models.Data.Repository.Repository
{
    public class DepartamentoRepository : GenericoRepository<Departamento, int>, IDepartamentoRepository
    {
        public DepartamentoRepository(KivoDbContext kivoDbContext) : base(kivoDbContext)
        {
        }
    }
}
