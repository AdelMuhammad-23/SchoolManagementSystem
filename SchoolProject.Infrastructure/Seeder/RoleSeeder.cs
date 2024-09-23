using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Infrastructure.Seeder
{
    public static class RoleSeeder
    {
        public static async Task SeedAsync(RoleManager<Role> roleManager)
        {
            var roleCount = await roleManager.Roles.CountAsync();
            if (roleCount <= 0)
            {
                var adminRole = new Role { Name = "admin" };
                var userRole = new Role { Name = "user" };

                await roleManager.CreateAsync(adminRole);
                await roleManager.CreateAsync(userRole);

            }
        }
    }
}
