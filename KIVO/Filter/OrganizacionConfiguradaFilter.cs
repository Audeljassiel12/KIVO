using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using KIVO.Models;

namespace KIVO.Filter
{
    public class OrganizacionConfiguradaFilter : IActionFilter
    {
        private readonly UserManager<User> _userManager;

        public OrganizacionConfiguradaFilter(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var userId = _userManager.GetUserId(context.HttpContext.User);
            var user = _userManager.FindByIdAsync(userId).Result;

            if (user != null && user.HaConfiguradoOrganizacion)
            {
                // Redirige a otra página si ya configuró la organización
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
           
        }
    }

}
