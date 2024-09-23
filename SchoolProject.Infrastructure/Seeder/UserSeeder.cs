using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Infrastructure.Seeder
{
    public static class UserSeeder
    {
        public static async Task SeedAsync(UserManager<User> userManager)
        {
            var usersCount = await userManager.Users.CountAsync();

            if (usersCount <= 0)
            {
                var defaultUser = new User()
                {
                    UserName = "admin",
                    Email = "admin@project.com",
                    FullName = "CollageProject",
                    Country = "Egypt",
                    Address = "Egypt",
                    PhoneNumber = "1234567890",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                };
                await userManager.CreateAsync(defaultUser, "Dd2003#");
                await userManager.AddToRoleAsync(defaultUser, DefaultRoles.Admin);
            }
        }
    }
}
