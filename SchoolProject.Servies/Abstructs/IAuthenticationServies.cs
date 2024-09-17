using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Servies.Abstructs
{
    public interface IAuthenticationServies
    {
        public Task<JwtAuthResult> GetJwtToken(User user);
        public Task<JwtAuthResult> GetNewRefreshToken(string accessToken, string refreshToken);
        public Task<string> ValidateToken(string accessToken);
    }
}
