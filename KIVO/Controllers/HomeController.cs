using Microsoft.AspNetCore.Mvc;

namespace KIVO.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index2() 
        {
           return View();
        }
    }
}
