//using KIVO.Models;
//using KIVO.Models.Data.Repository.IRepository;
//using KIVO.Models.Dto;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using System.Security.Claims; // Asegúrate de incluir esto


//namespace KIVO.Controllers
//    {
//        public class MedicoController : Controller
//        {
//            private readonly ICuidadRepository cuidadRepository;
//        private readonly IMedicoRepository medicoRepository;

//        public IDepartamentoRepository DepartamentoRepository { get; }
//        public SignInManager<User> SignInManager { get; }

//        public MedicoController(ICuidadRepository cuidadRepository, IDepartamentoRepository departamentoRepository, IMedicoRepository medicoRepository,SignInManager<User> signInManager)
//            {
//                this.cuidadRepository = cuidadRepository;
//                DepartamentoRepository = departamentoRepository;
//            this.medicoRepository = medicoRepository;
//            SignInManager = signInManager;
//        }

//            public async Task< ActionResult> AddInfo()
//            {
//                var departamentos =await DepartamentoRepository.GetAllAsync();

//                var model = new DoctorDto
//                {
//                    Departamentos = departamentos.Select(d => new SelectListItem
//                    {
//                        Value = d.Id.ToString(),
//                        Text = d.Nombre
//                    }).ToList()
//                };

//                return View(model);
//            }
//        [HttpPost]
//        public async Task<ActionResult> AddInfo()
//        {
//           var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

//            // Obtener los datos del usuario desde la base de datos usando UserManager
//           var medico =   await medicoRepository.GetByIdAsync(userId);
//            if(medico is null)
//            {
//              await  SignInManager.SignOutAsync();
//                return RedirectToAction("Login","Account");
//            }
//            medico


//        }

//        // Acción que devuelve ciudades según el departamento seleccionado
//        [HttpGet]
//            public async Task< JsonResult> GetCiudadesByDepartamento(int departamentoId)
//            {
//                var ciudades = await cuidadRepository.GetAllAsync();
//               var m = ciudades.Where(c => c.DepartamentoId == departamentoId)
//                                               .Select(c => new SelectListItem
//                                               {
//                                                   Value = c.Id.ToString(),
//                                                   Text = c.Nombre
//                                               }).ToList();



//                return Json(m);
//            }
//        }
//    }




