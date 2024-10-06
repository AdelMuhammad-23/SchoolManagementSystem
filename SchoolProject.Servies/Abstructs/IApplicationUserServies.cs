using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Servies.Abstructs
{
    public interface IApplicationUserServies
    {
        public Task<string> AddUserAsync(User user, string password);
    }
}
