using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Servies.Abstructs
{
    public interface IAuthenticationServies
    {
        public Task<JwtAuthResult> GetJwtToken(User user);
    }
}
