using System.Collections.Generic;
using System.Security.Claims;
using KIVO.Models;
using KIVO.Models.Data.Repository.IRepository;
using KIVO.Models.Dto;
using KIVO.Models.UnityOfWork;
using KIVO.Models.ViewModels;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Stripe;
using Stripe.Checkout;


namespace KIVO.Controllers
{
    [Route("Configuracion")]
    [Authorize(Roles = "Admin")]
    [ServiceFilter(typeof(VerificarEstadoUsuarioAttribute))]
    public class ConfiguracionController : Controller
    {
        private readonly IDepartamentoRepository departamentoRepository;
        private readonly ICentroMedicoRepository centroMedicoRepository;
        private readonly IUnityOfWork unityOfWork;
        private readonly ILogger<ConfiguracionController> logger;

        public ConfiguracionController(IDepartamentoRepository departamentoRepository, ICentroMedicoRepository centroMedicoRepository, IUnityOfWork unityOfWork,ILogger<ConfiguracionController> logger)
        {
            this.departamentoRepository = departamentoRepository;
            this.centroMedicoRepository = centroMedicoRepository;
            this.unityOfWork = unityOfWork;
            this.logger = logger;
        }

        /// <summary>
        /// GET: Configuracion/step-one
        /// Renderiza la vista para registrar una organización.
        /// </summary>
        [HttpGet("step-one")]
        public async Task<IActionResult> RegistrarOrganizacion()
        {
            var model = new EntidadCentroMedicoViewModel
            {
                Departamentos = await GetDepartamentosSelectList()
            };

            return View("step-one", model);
        }

        /// <summary>
        /// POST: Configuracion/step-one
        /// Registra la organización y redirige a la selección de especialidad.
        /// </summary>
        [HttpPost("step-one")]
        public async Task<IActionResult> RegistrarOrganizacion(EntidadCentroMedicoViewModel model)
        {
            // Validar el modelo
            if (!ModelState.IsValid)
            {
                model.Departamentos = await GetDepartamentosSelectList(); // Rellenar departamentos en caso de error
                return View("step-one", model);
            }

            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var centroMedico = new CentroMedico
                {
                    Nombre = model.NombreEntidad,
                    CuidadId = model.MunicipioId,
                    DepartamentoId = model.DepartamentoId,
                    Direccion = model.Direccion,
                    Telefono = ""
                };

                var medico = new Medico
                {
                    Nombres = "", // Completar según sea necesario
                    Id = userId!,
                    CentroMedico = centroMedico,
                    EspecialidadMedicoId = 1, // Este valor se actualizará después
                    Apellidos = "",
                    Telefono = ""
                };

                // Crear el centro médico y médico en la unidad de trabajo
                await unityOfWork.centroMedicoRepository.AddAsync(centroMedico);
                await unityOfWork.medicoRepository.AddAsync(medico);

                var result = await unityOfWork.SaveAsync();

                if (result > 0)
                {
                    // Redirige a la página de selección de especialidad
                    return RedirectToAction("step-two", new { medicoId = medico.Id });
                }

                // Mensaje de error en caso de fallo
                TempData["Error"] = "Ocurrió un error interno, por favor intente nuevamente.";
            }
            catch (Exception ex)
            {
                // Registro del error
                logger.LogError(ex, "Error en RegistrarOrganizacion");
                TempData["Error"] = "Ocurrió un error al procesar la solicitud. Intente nuevamente.";
            }
            finally
            {
                // Rellenar departamentos independientemente del resultado
                model.Departamentos = await GetDepartamentosSelectList();
            }

            return View("step-one", model);
        }

        [HttpGet("step-two")]
        public async Task< IActionResult> RegistrarInfoDoctor()
        {
            return View("step-two",new MedicoDo() { Especialidades =await GetEspecialidadesSelectList()});
        }

        [HttpPost("step-two")]
        public IActionResult RegistrarInfoDoctor(MedicoDo doctorDto)
        {
            if (!ModelState.IsValid)
            {
                return View(doctorDto);

            }
            return RedirectToAction("step-three");


        }
        [HttpGet("step-three")]
        public async Task<IActionResult> PlanSelect()
        {
           return View("step-three");
        }
        [HttpPost("step-three")]
        public async Task<IActionResult> PlanSelect(string plan)
        {
            // Verifica cuál plan ha seleccionado el usuario
            if (plan == "NimboPro")
            {
                // Si seleccionó el plan de pago, redirige a la página de pago
                return RedirectToAction("Pago");
            }
            else if (plan == "FreeTrial")
            {
                // Si seleccionó la prueba gratuita, redirige a la vista de prueba
                return RedirectToAction("step-four");
            }

            // Si por alguna razón no se seleccionó ningún plan válido, redirige de nuevo
            return RedirectToAction("PlanSelect");
        }

        public IActionResult Pago()
        {
            return View();
        }
       
        [HttpPost("CrearSesionPago")]
        public async Task<IActionResult> CrearSesionPago([FromBody] PagoRequestDto request)
        {
            // Precio por el primer usuario
            const decimal firstUserPrice = 100m;
            // Precio por cada usuario adicional
            const decimal additionalUserPrice = 80m;

            // Determinar el precio total
            decimal total = firstUserPrice; // Comienza con el precio del primer usuario

            if (request.UserCount > 1)
            {
                // Agregar el precio de los usuarios adicionales
                total += (request.UserCount - 1) * additionalUserPrice;
            }

            // Calcular el descuento (por ejemplo, un 10% de descuento)
            decimal discountPercentage = 0.94m; // 10% de descuento
            decimal discountAmount = total * discountPercentage;
            total -= discountAmount; // Aplicar el descuento al total

            // Crear sesión de pago en Stripe
            var sessionOptions = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
        {
            new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    // Utilizando PriceData para crear el artículo sin necesidad de ProductData
                    UnitAmount = (long)(total * 100), // Stripe espera el monto en centavos
                    Currency = "usd",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = "Suscripción  " +
                        "KIVO PRO BUNDLE", // Nombre del producto
                    },
                },
                Quantity = 1, // Solo una línea de producto
            },
        },
                Mode = "payment",
                SuccessUrl = "http://tu_dominio.com/success?session_id={CHECKOUT_SESSION_ID}",
                CancelUrl = "https://localhost:7212/Configuracion",
            };

            var sessionService = new SessionService();
            var session = await sessionService.CreateAsync(sessionOptions);

            return Ok(new { sessionId = session.Id, total, discountAmount }); // Devuelve también el total y el descuento aplicado
        }
        [HttpGet("step-four")]
        public IActionResult OpcionesPricipal()
        {

            return View("step-four");
        }
        // Método para obtener la lista de departamentos como SelectListItem
        private async Task<List<SelectListItem>> GetDepartamentosSelectList()
        {
            var departamentos = await departamentoRepository.GetAllAsync();
            return departamentos.Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Nombre }).ToList();
        }

        // Método para obtener la lista de especialidades como SelectListItem
        private async Task<List<SelectListItem>> GetEspecialidadesSelectList()
        {
            var especialidades = await unityOfWork.espesialidadRepository.GetAllAsync();
            return especialidades.Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Nombre }).ToList();
        }
    }
}
