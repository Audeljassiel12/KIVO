using KIVO.Models.Data.Repository.IRepository;
using KIVO.Models.Data;

namespace KIVO.Models.UnityOfWork
{
    public interface IUnityOfWork:IDisposable
    {
        IMedicoRepository medicoRepository { get; }
        ICentroMedicoRepository centroMedicoRepository { get; }
        
        Task<int> SaveAsync();
    }
}
