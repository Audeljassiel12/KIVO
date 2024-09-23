using KIVO.Models.Data.Repository.Repository;
using KIVO.Repository.IRepository;
using Microsoft.EntityFrameworkCore.Internal;

namespace KIVO.Models.Data.Repository.IRepository
{
    public interface IPlanSuscripcionRepository:IGenericRepository<PlanSuscripcion,int>
    {
        Task<int> FindIsFree();
        

        
    }
}
