
using KIVO.ExtencionMetodos;
using KIVO.Filter;
using KIVO.Models;
using KIVO.Models.Data;
using KIVO.Models.Data.Repository.IRepository;
using KIVO.Models.Data.Repository.Repository;
using KIVO.Models.Dto;
using KIVO.Models.ViewModels;
using KIVO.Services.IServerces;
using KIVO.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace KIVO.Controllers
{
    [Authorize(Roles = "Admin,SubAdmin,Medico")]
    [ServiceFilter(typeof(VerificarEstadoUsuarioAttribute))]
    public class PacienteController : Controller
    {
        private readonly IPacienteService pacienteService;
        private readonly IDepartamentoRepository departamentoRepository;

        public PacienteController(IPasienteRepository pasienteRepository,IPacienteService pacienteService,IDepartamentoRepository departamentoRepository)
        {
            _pacienteRepository = pasienteRepository;
            this.pacienteService = pacienteService;
            this.departamentoRepository = departamentoRepository;
        }
        public IActionResult Cita()
        {
            return View();
        }

        public IPasienteRepository _pacienteRepository { get; }
   
        public async Task<IActionResult> Index()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            try
            {
                var pacientes = await pacienteService.ObtenerPacientesPorCentroMedicoAsync(userId); // Obtener todos los pacientes
               
                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return PartialView("Index", pacientes);
                }

                return View(pacientes);
            }
            catch (Exception ex)
            {
                // Aquí puedes registrar el error o hacer algo más
                return StatusCode(500, ex.Message); // Devuelve un mensaje de error
            }
        }

        [HttpGet]
        public async Task<IActionResult> BuscarPacientes(string query, int page = 1)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            // Llama al servicio para buscar pacientes con el criterio y la paginación
            var paginacionResult = await pacienteService.ObtenerPacientesPorCentroMedicoAsync(userId,query,page);

            // Devuelve la vista parcial con los resultados
            return PartialView("_index", paginacionResult);
        }

     
        public async Task< IActionResult> NuevoPaciente()
        {

            var pasientenDto = new PacienteDTO()
            {
                Departamentos = (await departamentoRepository.GetAllAsync()).Select(a=>new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Value=a.Id.ToString(),Text=a.Nombre }).ToList()
            }
            ;
           
            if (Request.IsAjaxRequest())
            {
                return PartialView("NuevoPaciente", pasientenDto);
            }
            return View(pasientenDto);
        }

        [HttpPost]
        public async Task<IActionResult> NuevaPaciente(PacienteDTO pacienteDTO)
        {
            try
            {
                // 1. Obtener el ID del usuario logueado desde los claims
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

                // No es necesario verificar si userId es nulo, ya que el usuario está autenticado debido a [Authorize]

                // 2. Llamar al servicio para agregar el paciente
                var pacienteId = await pacienteService.AgregarPacienteAsync(pacienteDTO, userId);

                // 3. Retornar un Ok si todo sale bien
                return Ok(new { Message = "Paciente agregado exitosamente", PacienteId = pacienteId ,
                    success= true});
                }
            catch (InvalidOperationException ex)
            {
                // 4. Manejo de excepciones específicas
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                // 5. Retornar un mensaje genérico de error sin exponer detalles internos
                return StatusCode(500, "Ocurrió un error al procesar la solicitud. Inténtelo de nuevo más tarde.");
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetDetallesPaciente(string pacienteId)
        {
            try
            {
                
                var pasienteData = await _pacienteRepository.GetByIdAsync(pacienteId);
                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return PartialView("GetDetallesPaciente", pasienteData);
                }
                return View(pasienteData);
            }
            catch(Exception ex )
            {
                Console.Write(ex);
                return View();
            }
           
        }
             public IActionResult detalle() 
        {
            return View();
        }
    }
    


}
