using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Helpers;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Servies.Abstructs;

namespace SchoolProject.Servies.Implementation
{
    public class AuthorizationServies : IAuthorizationServies
    {
        #region Fields
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _dbContext;
        #endregion

        #region Constructos
        public AuthorizationServies(RoleManager<Role> roleManager, UserManager<User> userManager, ApplicationDbContext dbContext)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _dbContext = dbContext;
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

        public async Task<string> EditUserRoleAsync(EditUserRole editUserRole)
        {
            var trancat = _dbContext.Database.BeginTransaction();
            try
            {
                var user = await _userManager.FindByIdAsync(editUserRole.UserId.ToString());
                if (user == null) return "User Not Found";
                var oldUserRolesList = await _userManager.GetRolesAsync(user);
                var deleteOldUserRoleList = await _userManager.RemoveFromRolesAsync(user, oldUserRolesList);
                if (!deleteOldUserRoleList.Succeeded)
                    return "Failed to remove old UserRoles";

                var newRoles = editUserRole.Roles.Where(x => x.HasRole == true).Select(x => x.Name);
                var newUserRolesList = await _userManager.AddToRolesAsync(user, newRoles);
                if (!newUserRolesList.Succeeded)
                    return "Failed to Add New UserRoles";
                await trancat.CommitAsync();

                return "Success";
            }
            catch (Exception ex)
            {
                await trancat.RollbackAsync();
                return "Failed to Update UserRoles";
            }
        }

        public async Task<ManageUserRoleResponse> GetManageUserRoleResponse(User user)
        {
            var response = new ManageUserRoleResponse();
            var rolesListModel = new List<UserRoles>();
            var userRoles = await _userManager.GetRolesAsync(user);
            var roles = await _roleManager.Roles.ToListAsync();
            response.UserId = user.Id;
            foreach (var role in roles)
            {
                var rolesModel = new UserRoles();
                rolesModel.Id = role.Id;
                rolesModel.Name = role.Name;
                if (userRoles.Contains(role.Name))
                    rolesModel.HasRole = true;
                rolesListModel.Add(rolesModel);
            }
            response.Roles = rolesListModel;
            return response;
        }

        public async Task<Role> GetRoleByIdAsync(int id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            return role;
        }

        public async Task<List<Role>> GetRolesListAsync()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return roles;
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
