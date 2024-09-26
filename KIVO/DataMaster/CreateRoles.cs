using KIVO.Models;
using Microsoft.AspNetCore.Identity;

namespace KIVO.DataMaster
{
    public class CreateRoles
    {
        public static async Task CreateRolesData(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

            string[] roleNames = { "Admin", "Medico", "Paciente", "MINSA", "SubAdmin" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    // Crear el rol si no existe
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

          
        }
    }
}
