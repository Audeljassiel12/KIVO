using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
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
using Microsoft.Extensions.Logging;

namespace KIVO.Controllers
{

  
    public class CentroMedicoController:Controller
    {
        private readonly ILogger<CentroMedicoController> logger;
        private readonly IUnityOfWork unityOfWork;
        private readonly IEspesialidadRepository espesialidadRepository;

        public UserManager<User> UserManager { get; }

        public CentroMedicoController(ILogger<CentroMedicoController> logger, IUnityOfWork unityOfWork,UserManager<User> userManager,IEspesialidadRepository espesialidadRepository)
        {
            this.logger = logger;
            this.unityOfWork = unityOfWork;
            UserManager = userManager;
            this.espesialidadRepository = espesialidadRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [ServiceFilter(typeof(OrganizacionConfiguradaFilter))]
        public async Task<IActionResult> RegistrarOrganizacion()
        {
            var lista = await espesialidadRepository.GetAllAsync();
            var model = new EntidadMedicaViewModel
            {
              Especialidades = lista.Select(a=> new SelectListItem { Value= a.Id.ToString(), Text = a.Nombre}).ToList()
            };
            return View(model);
        }
   
        [HttpPost]
        [Authorize(Roles ="Admin")]
        [ServiceFilter(typeof(OrganizacionConfiguradaFilter))]
        
        public async Task<IActionResult> Guardar(EntidadMedicaViewModel model) {
        // Validación del formulario
        if (!ModelState.IsValid) {
           
            
            return  RedirectToAction("RegistrarOrganizacion");
        }
            // Obtener el ID del usuario autenticado
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Obtener los datos del usuario desde la base de datos usando UserManager
            var usuario = await UserManager.FindByIdAsync(userId!);
            usuario.HaConfiguradoOrganizacion = true; 

            var centroMedico = new CentroMedico()
            {
                Nombre = model.NombreEntidad,
            };
            var medico = new Medico()
            {
                Nombres = usuario.Nombres,
                Id = userId!,
                CentroMedico = centroMedico,
                EspecialidadMedicoId = model.EspecialidadId,
                Apellidos = usuario.Nombres,
                Telefono = usuario.PhoneNumber
            };


       
           await unityOfWork.centroMedicoRepository.AddAsync(centroMedico);
            await unityOfWork.medicoRepository.AddAsync(medico);
             unityOfWork.users.Update(usuario);
    
         
            var result =   await unityOfWork.SaveAsync();
             
            if(result>0) return RedirectToAction("PlanesSubcripcion", "Subcripcion");
            TempData["Error"] = "Ocurrio un error interno por favor intente nuevamente";
            return RedirectToAction("RegistrarOrganizacion");
        
    }
    }
}