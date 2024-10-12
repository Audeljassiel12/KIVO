using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using KIVO.Models;
using Microsoft.AspNetCore.Identity;

namespace KIVO.Miiddleware
{public class PhoneNumberVerificationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly string _verificationPath;
    private readonly HashSet<string> _excludedPaths;

    public PhoneNumberVerificationMiddleware(RequestDelegate next, string verificationPath, IEnumerable<string> excludedPaths)
    {
        _next = next;
        _verificationPath = verificationPath;
        _excludedPaths = new HashSet<string>(excludedPaths, StringComparer.OrdinalIgnoreCase);
    }
    

    public async Task InvokeAsync(HttpContext context, UserManager<User> userManager)
    {
        // Si el usuario no está autenticado, continuar con el siguiente middleware
        if (!context.User.Identity.IsAuthenticated)
        {
            await _next(context);
            return;
        }
        

        var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId))
        {
            await _next(context);
            return;
        }

        var user = await userManager.FindByIdAsync(userId);
        if (user == null || user.PhoneNumberConfirmed)
        {
            await _next(context);
            return;
        }

        var currentPath = context.Request.Path;

        // Si la ruta actual está en la lista de exclusión, permitir el acceso
        if (_excludedPaths.Any(path => currentPath.StartsWithSegments(path)))
        {
            await _next(context);
            return;
        }

        // Redirigir a la página de verificación de número si no está en esa página
        if (!currentPath.StartsWithSegments(_verificationPath))
        {
            context.Response.Redirect(_verificationPath);
            return;
        }

        await _next(context);
    }
}

}