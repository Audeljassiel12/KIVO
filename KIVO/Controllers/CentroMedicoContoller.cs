using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using KIVO.ExtencionMetodos;
using KIVO.Filter;
using KIVO.Migrations;
using KIVO.Models;
using KIVO.Models.Data.Repository.IRepository;
using KIVO.Models.UnityOfWork;
using KIVO.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace KIVO.Controllers
{

  
    public class CentroMedicoController:Controller
    {
        private readonly ILogger<CentroMedicoController> logger;
        private readonly IUnityOfWork unityOfWork;
        private readonly IEspesialidadRepository espesialidadRepository;
        private readonly SignInManager<User> signInManager;
        private readonly ICentroMedicoRepository centroMedicoRepository;

        public UserManager<User> UserManager { get; }
        public IDepartamentoRepository DepartamentoRepository { get; }

        public CentroMedicoController(ILogger<CentroMedicoController> logger, IUnityOfWork unityOfWork,UserManager<User> userManager,IEspesialidadRepository espesialidadRepository,SignInManager<User> signInManager,IDepartamentoRepository departamentoRepository,ICentroMedicoRepository centroMedicoRepository)
        {
            this.logger = logger;
            this.unityOfWork = unityOfWork;
            UserManager = userManager;
            this.espesialidadRepository = espesialidadRepository;
            this.signInManager = signInManager;
            DepartamentoRepository = departamentoRepository;
            this.centroMedicoRepository = centroMedicoRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        
      
        public async Task<IActionResult> RegistrarOrganizacion()
        {
            var departamentos = await DepartamentoRepository.GetAllAsync();
            var model = new EntidadCentroMedicoViewModel();
            if (!Request.IsAjaxRequest())
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                model = await centroMedicoRepository.GetInfoConsultorioPorMedicoId(userId);

                if (model != null)
                {

                    model.Departamentos = departamentos.Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Nombre, Selected = a.Id == model.DepartamentoId }).ToList();
                }

                model = new EntidadCentroMedicoViewModel() { Departamentos = departamentos.Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Nombre }).ToList() };
                return View(model);

            }

         model = new EntidadCentroMedicoViewModel() { Departamentos = departamentos.Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Nombre }).ToList() };
            
          
            return PartialView("RegistrarOrganisacion",model);
        }
   
        [HttpPost]
        [Authorize(Roles ="Admin")]
        [ServiceFilter(typeof(OrganizacionConfiguradaFilter))]
        
        public async Task<IActionResult> Guardar(EntidadCentroMedicoViewModel model) {
        // Validación del formulario
        if (!ModelState.IsValid) {
           
            
            return  RedirectToAction("RegistrarOrganizacion");
        }
            // Obtener el ID del usuario autenticado
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Obtener los datos del usuario desde la base de datos usando UserManager
  
            var centroMedico = new CentroMedico()
            {
                Nombre = model.NombreEntidad,
                CuidadId = model.MunicipioId,
                DepartamentoId = model.DepartamentoId,
                Direccion = model.Direccion,
                Telefono = "9993993939"
            };
            var medico = new Medico()
            {
                Nombres = "",
                Id = userId!,
                CentroMedico = centroMedico,
                EspecialidadMedicoId = 1,
                Apellidos ="",
                Telefono = "949483933"
              
            };


       
           await unityOfWork.centroMedicoRepository.AddAsync(centroMedico);
            await unityOfWork.medicoRepository.AddAsync(medico);
          
    
         
            var result =   await unityOfWork.SaveAsync();
             
            if(result>0) return PartialView("~/Views/Medico/AddInfo.cshtml");
            TempData["Error"] = "Ocurrio un error interno por favor intente nuevamente";
            return PartialView("/Views/Medico/AddInfo.cshtml");
        
    }
    }
}