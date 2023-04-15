using Microsoft.AspNetCore.Identity;
using Phoenix.TicketManagement.Identity.Models;

namespace Phoenix.TicketManagement.Identity.Seeds
{
    public static class AddUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            var applicationUser = new ApplicationUser
            {
                FirstName = "James",
                LastName = "Doe",
                UserName = "JamesDoe",
                Email = "JamesD@test.com",
                EmailConfirmed = true
            };

            var user = await userManager.FindByEmailAsync(applicationUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(applicationUser, "James@100100");
            }
        }
    }
}
