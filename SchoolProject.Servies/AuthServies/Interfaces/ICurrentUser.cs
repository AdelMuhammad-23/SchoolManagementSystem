using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Servies.AuthServies.Interfaces
{
    public interface ICurrentUser
    {
        public Task<User> GetCurrentUserAsync();
        public Task<List<string>> GetCurrentUserRolesAsync();
        public int GetCurrentUserId();
    }
}
