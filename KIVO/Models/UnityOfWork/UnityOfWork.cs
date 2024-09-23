
using KIVO.Models.Data;
using KIVO.Models.Data.Repository.IRepository;
using KIVO.Models.Data.Repository.Repository;
using Microsoft.EntityFrameworkCore;

namespace KIVO.Models.UnityOfWork
{
    public class UnityOfWork : IUnityOfWork
    {
      
        private readonly KivoDbContext dbContext;


        public UnityOfWork(IMedicoRepository medicoRepository,
            KivoDbContext dbContext,
            ICentroMedicoRepository centroMedicoRepository ,ISuscripcionRepository suscripcionRepository)
        {
            this.medicoRepository = medicoRepository;
            this.dbContext = dbContext;
            this.centroMedicoRepository = centroMedicoRepository;
            this.suscripcionRepository = suscripcionRepository; 
        }
       
        public IMedicoRepository medicoRepository { get; }

        public ICentroMedicoRepository centroMedicoRepository { get; }

        public IPlanSuscripcionRepository planSuscripcionRepository => throw new NotImplementedException();

        public ISuscripcionRepository suscripcionRepository  {get;}

        public DbSet<User> users => dbContext.Users;

        public void Dispose()
        {
          dbContext.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            try
            {
                return await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Captura errores relacionados con las actualizaciones en la base de datos
                throw new Exception("Error actualizando la base de datos", ex);
            }
            catch (Exception ex)
            {
                // Maneja cualquier otro tipo de excepción
                throw new Exception("Error durante la operación de guardado", ex);
            }
        }


    }
}
