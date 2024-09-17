using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KIVO.Models.Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace KIVO.Models.Data.Repository.Repository
{
    public class PasienteRepository : GenericoRepository<Paciente, string>,IPasienteRepository
    {
        public PasienteRepository(KivoDbContext kivoDbContext) : base(kivoDbContext)
        {
        }

        public async Task<IEnumerable<Paciente>> GetPacienteByName(string name)
        {
          return await   EntityDeSet.
          Where(a=>a.Nombres.StartsWith(name, StringComparison.OrdinalIgnoreCase)).
          ToListAsync();
        }
    }
}