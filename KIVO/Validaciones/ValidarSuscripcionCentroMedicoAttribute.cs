namespace KIVO.Validaciones
{
    using KIVO.Models.Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using System;
    using System.Linq;
    using System.Security.Claims;

    public class ValidarSuscripcionFilter : IActionFilter
    {
        private readonly KivoDbContext _context;

        public ValidarSuscripcionFilter(KivoDbContext context)
        {
            _context = context;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var userId = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId != null)
            {
                // Obtener directamente el centro médico y la última suscripción en una sola consulta
                var ultimaSuscripcion = _context.CentroMedicos
                    .Where(cm => cm.Medicos.Any(u => u.Id == userId)) // Filtra el centro médico por usuario
                    .SelectMany(cm => cm.Suscripciones)  // Selecciona todas las suscripciones del centro médico
                    .OrderByDescending(s => s.FechaInicio).
                    Select(a=>new {a.FechaFin})// Ordenar por fecha de inicio para obtener la más reciente
                    .FirstOrDefault();

                // Verificar si la suscripción obtenida es válida (no ha expirado)
                if (ultimaSuscripcion == null || ultimaSuscripcion.FechaFin < DateTime.UtcNow)
                {
                    // Redirigir o mostrar mensaje de suscripción expirada
                    context.Result = new RedirectToActionResult("SuscripcionExpirada", "Cuenta", null);
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // No implementado
        }
    }


}
