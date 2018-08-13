using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MyMovieDb.Models;

namespace MyMovieDb.App.Common
{
    public static class ApplicationBuilderAuthExtensions
    {
        private const string DefaultAdminPassword = "admin123@";
        private const string DefaultModPassword = "mod123@";

        private static readonly IdentityRole[] roles =
        {
            new IdentityRole("Admin"),
            new IdentityRole("Moderator"), 
        };

        public static async void SeedDatabase(this IApplicationBuilder app)
        {
            var serviceFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            var scope = serviceFactory.CreateScope();
            using (scope)
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role.Name))
                    {
                        await roleManager.CreateAsync(role);
                    }
                }

                var adminUser = await userManager.FindByNameAsync("admin");
                if (adminUser == null)
                {
                    adminUser = new User()
                    {
                        UserName = "admin",
                        Email = "admin@example.com",
                        SecurityStamp = DateTime.Now.ToString()
                    };

                    await userManager.CreateAsync(adminUser, DefaultAdminPassword);
                    await userManager.AddToRoleAsync(adminUser, roles[0].Name);
                }

                var modUser = await userManager.FindByNameAsync("mod");
                if (modUser == null)
                {
                    modUser = new User()
                    {
                        UserName = "mod",
                        Email = "mod@example.com",
                        SecurityStamp = DateTime.Now.ToString()
                    };

                    await userManager.CreateAsync(modUser, DefaultModPassword);
                    await userManager.AddToRoleAsync(modUser, roles[1].Name);
                }
            }
        }
    }
}
