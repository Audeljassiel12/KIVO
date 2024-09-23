using KIVO.Models.Data.Repository.IRepository;
using KIVO.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace KIVO.Models.UnityOfWork
{
    public interface IUnityOfWork:IDisposable
    {
        IMedicoRepository medicoRepository { get; }
        ICentroMedicoRepository centroMedicoRepository { get; }
        IPlanSuscripcionRepository planSuscripcionRepository { get; }
        ISuscripcionRepository suscripcionRepository { get; }
        DbSet<User> users { get;}
         
              
        Task<int> SaveAsync();
    }
}
