using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Servies.Abstructs
{
    public interface IAuthorizationServies
    {
        public Task<List<Role>> GetRolesListAsync();
        public Task<Role> GetRoleByIdAsync(int id);
        public Task<string> AddRoleAsync(string roleName);
        public Task<string> EditRoleAsync(string oldRole, string newRole);
        public Task<string> DeleteRoleAsync(int id);
        public Task<bool> IsRoleExist(string roleName);
        public Task<bool> IsRoleNameExistExcludeSelf(string roleName, int id);

    }
}
