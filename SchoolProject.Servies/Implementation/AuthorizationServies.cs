using Microsoft.AspNetCore.Identity;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Servies.Abstructs;

namespace SchoolProject.Servies.Implementation
{
    public class AuthorizationServies : IAuthorizationServies
    {
        #region Fields
        private readonly RoleManager<Role> _roleManager;
        #endregion

        #region Constructos
        public AuthorizationServies(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        #endregion

        #region Handle Functions
        public async Task<string> AddRoleAsync(string roleName)
        {
            var identityRole = new Role();
            identityRole.Name = roleName;
            var identityResult = await _roleManager.CreateAsync(identityRole);
            if (identityResult.Succeeded)
                return "Success";
            else
                return "Failed";
        }

        public async Task<bool> IsRoleExist(string roleName)
        {
            return await _roleManager.RoleExistsAsync(roleName);
        }

        #endregion

    }
}
