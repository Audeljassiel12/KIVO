using KIVO.ExtencionMetodos;
using KIVO.Filter;
using KIVO.Models;
using KIVO.Models.Data.Repository.IRepository;
using KIVO.Models.Data.Repository.Repository;
using KIVO.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KIVO.Controllers
{
    [ServiceFilter(typeof(VerificarEstadoUsuarioAttribute))]
    public class PasienteController:Controller
    {
        public PasienteController(IPasienteRepository pasienteRepository)
        {
            _pacienteRepository = pasienteRepository;
        }

        public IPasienteRepository _pacienteRepository { get; }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var pacientes = await _pacienteRepository.GetAllAsync(); // Obtener todos los pacientes
            var viewModel = new PacienteViewModel
            {
                Pacientes = new List<Paciente> { new Paciente() { Nombres="audel"} }
            };
           

            return View(viewModel);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult BuscarPacientes(string query)
        {
          
            var pasi = new List<Paciente> { new Paciente() { Nombres = "chelsita" }, new Paciente() { Nombres = "audel" } , new Paciente() { Nombres = "fabian" }, new Paciente() { Nombres = "donis" }, new Paciente() { Nombres = "ana" }   };
            if (!string.IsNullOrEmpty(query))
            {
               pasi= pasi.Where(a => a.Nombres.StartsWith(query)).ToList();
            }


            return PartialView("_index",pasi);
        }

    }
}
