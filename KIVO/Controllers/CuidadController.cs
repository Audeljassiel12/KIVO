using KIVO.Models.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KIVO.Controllers
{
    public class CuidadController : Controller
    {
        private readonly ICuidadRepository cuidadRepository;

        public CuidadController(ICuidadRepository cuidadRepository)
        {
            this.cuidadRepository = cuidadRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> GetCiudadesByDepartamento(int departamentoId)
        {
            var ciudades = await cuidadRepository.GetAllAsync();
            var m = ciudades.Where(c => c.DepartamentoId == departamentoId)
                                            .Select(c => new SelectListItem
                                            {
                                                Value = c.Id.ToString(),
                                                Text = c.Nombre
                                            }).ToList();



            return Json(m);
        }
    }
}
