using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using KIVO.Models;

public class VerificarEstadoUsuarioAttribute : ActionFilterAttribute
{
    private readonly UserManager<User> _userManager;

    public VerificarEstadoUsuarioAttribute(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var user = _userManager.GetUserAsync(context.HttpContext.User).Result; // Usa .Result para obtener el usuario

        if (user != null) 
        {
            var result = _userManager.IsInRoleAsync(user, "Admin").Result;
            if (result)
            {
                // Obtener el controlador y la acción actuales
                var currentController = context.RouteData.Values["controller"]?.ToString();
                var currentAction = context.RouteData.Values["action"]?.ToString();
                
                // Verificar si el número de teléfono no está confirmado
                if (!user.PhoneNumberConfirmed && (currentController != "Account" || currentAction != "VerificarNumero"))
                {
                    context.Result = new RedirectToActionResult("VerificarNumero", "Account", null);
                }
              
            }
        }

        base.OnActionExecuting(context); // Llama al método base
    }
}
