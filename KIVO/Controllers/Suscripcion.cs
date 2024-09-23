using KIVO.Models;
using KIVO.Models.Data;
using KIVO.Models.Data.Repository.IRepository;
using KIVO.Models.UnityOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KIVO.Controllers
{
    [ServiceFilter(typeof(VerificarEstadoUsuarioAttribute))]
    public class SuscripcionController : Controller
    {
        private readonly KivoDbContext _kivoDbContext;
        private readonly UserManager<User> userManager;

        public SuscripcionController(IUnityOfWork unityOfWork, KivoDbContext kivoDbContext,UserManager<User> userManager)
        {
            UnityOfWork = unityOfWork;
            _kivoDbContext = kivoDbContext;
            this.userManager = userManager;
        }

        public IUnityOfWork UnityOfWork { get; }
        [HttpGet]
        public IActionResult PlanesSubcriopnesConfi()
        {
            return View();
        }
        [HttpPost] // Asegúrate de que este método maneje POST
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PlanesSubcriopnesConfi( bool confirmar)
        {
            if (confirmar)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                  var usuario = await userManager.FindByIdAsync(userId!);

                // Obtener el centro médico del usuario
                var centroMedicoId = await _kivoDbContext.CentroMedicos
                    .Where(cm => cm.medicos.Any(m => m.Id == userId))
                    .Select(cm => cm.Id)
                    .FirstOrDefaultAsync();

                if (centroMedicoId == 0) // Verificar si no se encontró el centro médico
                {
                    TempData["Error"] = "No se encontró el centro médico asociado al usuario.";
                    return View();
                }

                // Verificar si el plan es gratuito sin cargar todos los campos
                var resultPlan = await _kivoDbContext.PlanSuscripcions.Select(a=>new {a.Id,a.IsFree}).FirstOrDefaultAsync(a=>a.IsFree);
                   
                if (resultPlan ==null || !resultPlan.IsFree) // Verificar si no es un plan gratuito
                {
                    TempData["Error"] = "El plan seleccionado no es gratuito.";
                    return View();
                }
                    
                var newSuscripcion = new Suscripcion
                {
                    CentroMedicoId = centroMedicoId,
                    PlanSuscripcionId =resultPlan.Id,
                    Activa = true,
                    FechaFin = DateTime.UtcNow.AddDays(90),
                    FechaInicio = DateTime.UtcNow,
                };
                      usuario.SelecionoPlan = true; 
                try
                {
                    await UnityOfWork.suscripcionRepository.AddAsync(newSuscripcion);
                     UnityOfWork.users.Update(usuario);
                    var result = await UnityOfWork.SaveAsync();

                    if (result > 0)
                    {
                        TempData["Success"] = "Suscripción creada exitosamente.";
                        return RedirectToAction("ListPasientes", "Pasiente");
                    }
                    else
                    {
                        TempData["Error"] = "Ocurrió un error al guardar la suscripción. Intente nuevamente.";
                    }
                }
                catch (Exception ex)
                {
                    // Log del error para depuración (puedes usar un logger aquí)
                    TempData["Error"] = "Ocurrió un error interno: " + ex.Message;
                }
            }
            else
            {
                TempData["Error"] = "Error de confirmación.";
            }

            return View();
        }


    }
}
