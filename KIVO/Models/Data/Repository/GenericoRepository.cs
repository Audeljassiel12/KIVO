using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KIVO.Models.Data;
using KIVO.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace KIVO.Repository
{
    public class GenericoRepository<T, TId> : IGenericRepository<T, TId> where T : class
    {
        protected DbSet<T> EntityDeSet;
        private readonly KivoDbContext _DbContext;
        public GenericoRepository(KivoDbContext kivoDbContext)
        {
            EntityDeSet = kivoDbContext.Set<T>();
            _DbContext = kivoDbContext;
        }

        public async Task AddAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            await EntityDeSet.AddAsync(entity);
        }
        public void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            EntityDeSet.Remove(entity);
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await EntityDeSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(TId id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var entity = await EntityDeSet.FindAsync(id);
            return entity!; // Devuelve null si no se encuentra la entidad
        }

        public void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            EntityDeSet.Update(entity);
        }
    }
}