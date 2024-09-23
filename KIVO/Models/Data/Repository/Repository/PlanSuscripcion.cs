using KIVO.Models.Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace KIVO.Models.Data.Repository.Repository
{
    public class PlanSuscripcionRepository : GenericoRepository<PlanSuscripcion, int>, IPlanSuscripcionRepository
    {
        public PlanSuscripcionRepository(KivoDbContext kivoDbContext) : base(kivoDbContext)
        {
        }

        public async Task<int> FindIsFree()
        {
          return await EntityDeSet.Where(a=>a.IsFree).Select(a=>a.Id).FirstOrDefaultAsync();
        }
    }
}
