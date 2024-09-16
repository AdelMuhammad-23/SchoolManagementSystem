using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Servies.Abstructs
{
    public interface IAuthenticationServies
    {
        public Task<string> GetJwtToken(User user);
    }
}
