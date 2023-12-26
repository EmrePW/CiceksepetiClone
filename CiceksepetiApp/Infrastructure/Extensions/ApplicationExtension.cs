using Microsoft.AspNetCore.Identity;

namespace CiceksepetiApp.Infrastructure.Extensions
{
    public static class ApplicationExtension
    {
        public static async void AddDefaultAdmin(this IApplicationBuilder app)
        {
            const string adminUser = "Admin";
            const string adminPassword = "Admin+123456";

            UserManager<IdentityUser> userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            RoleManager<IdentityRole> roleManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            IdentityUser user = await userManager.FindByNameAsync(adminUser);
            if (user is null)
            {
                user = new IdentityUser()
                {
                    Email = "emreeyahya@gmail.com",
                    PhoneNumber = "5538254461",
                    UserName = adminUser
                };

                var result = await userManager.CreateAsync(user, adminPassword);
                if (!result.Succeeded)
                {
                    throw new Exception("Default admin couldn't be created ConfigureDefaultAdmin");
                }

                var roleResult = await userManager.AddToRolesAsync(user, roleManager.Roles.Select(role => role.Name).ToList());

                if (!roleResult.Succeeded)
                {
                    throw new Exception("Default Admin User Role Problem");
                }
            }
            // Anti migration curse
            if (await userManager.GetRolesAsync(user) is null)
            {
                var MigrationroleResult = await userManager.AddToRolesAsync(user, roleManager.Roles.Select(role => role.Name).ToList());
                if (!MigrationroleResult.Succeeded)
                {
                    throw new Exception("Default Admin User Role Problem");
                }
            }
        }

    }
}