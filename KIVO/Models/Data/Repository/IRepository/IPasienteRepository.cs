using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KIVO.Repository.IRepository;

namespace KIVO.Models.Data.Repository.IRepository
{
    public interface IPasienteRepository:IGenericRepository<Paciente,string>
    {
        Task<IEnumerable<Paciente>> GetPacienteByName(string name);
        
    }

   
}