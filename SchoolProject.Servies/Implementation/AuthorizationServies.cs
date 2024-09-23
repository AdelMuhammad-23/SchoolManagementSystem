﻿using Microsoft.AspNetCore.Identity;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Servies.Abstructs;

namespace SchoolProject.Servies.Implementation
{
    public class AuthorizationServies : IAuthorizationServies
    {
        #region Fields
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        #endregion

        #region Constructos
        public AuthorizationServies(RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
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

        public async Task<string> DeleteRoleAsync(int id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            if (role == null) return "this role is not Found";
            var users = await _userManager.GetUsersInRoleAsync(role.Name);
            if (users != null && users.Count() > 0) return "Used";
            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
                return "Success";
            var errors = string.Join(", ", result.Errors);
            return errors;

        }

        public async Task<string> EditRoleAsync(string oldRole, string newRole)
        {
            var role = await _roleManager.FindByNameAsync(oldRole);
            if (role == null)
                return "this role is not Found";
            role.Name = newRole;
            var result = await _roleManager.UpdateAsync(role);
            if (result.Succeeded)
                return "Success";
            var errors = string.Join(", ", result.Errors);
            return errors;
        }


        public async Task<bool> IsRoleExist(string roleName)
        {
            return await _roleManager.RoleExistsAsync(roleName);
        }

        public async Task<bool> IsRoleNameExistExcludeSelf(string roleName, int id)
        {
            var role = _roleManager.Roles.Where(x => x.Name == roleName && x.Id == id).FirstOrDefault();
            if (role == null) return false;
            return true;

        }

        #endregion

    }
}
