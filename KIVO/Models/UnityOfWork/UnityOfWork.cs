
using KIVO.Models.Data;
using KIVO.Models.Data.Repository.IRepository;

namespace KIVO.Models.UnityOfWork
{
    public class UnityOfWork : IUnityOfWork
    {
      
        private readonly KivoDbContext dbContext;


        public UnityOfWork(IMedicoRepository medicoRepository,
            KivoDbContext dbContext,
            ICentroMedicoRepository centroMedicoRepository)
        {
            this.medicoRepository = medicoRepository;
            this.dbContext = dbContext;
            this.centroMedicoRepository = centroMedicoRepository;
        }

        public IMedicoRepository medicoRepository { get; }

        public ICentroMedicoRepository centroMedicoRepository { get; }
        public void Dispose()
        {
          dbContext.Dispose();
        }

        public async Task<int> SaveAsync()=> await dbContext.SaveChangesAsync();
       
    }
}
