using Microsoft.AspNetCore.Identity;
using ProConsulta.Models;

namespace ProConsulta.Data
{
    public static class SeedIdentityData
    {

        public static async Task SeedUserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {

            var user = await userManager.FindByEmailAsync("proconsulta@gmail.com.br");

            if(user == null)
            {
                var attendant = new Attendant
                {
                    UserName = "proconsulta@gmail.com.br",
                    Email = "proconsulta@gmail.com.br",
                    Name = "Pro Consulta",
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(attendant, "Pa$$word");
                await userManager.AddToRoleAsync(attendant, "Atendente");

            }
        }

    }
}
