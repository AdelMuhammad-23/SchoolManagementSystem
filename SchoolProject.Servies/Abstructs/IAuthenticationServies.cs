using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Helpers;
using System.IdentityModel.Tokens.Jwt;

namespace SchoolProject.Servies.Abstructs
{
    public interface IAuthenticationServies
    {
        public Task<JwtAuthResult> GetJwtToken(User user);
        public JwtSecurityToken ReadJwtToken(string accessToken);
        public Task<(string, DateTime?)> ValidateDetails(JwtSecurityToken jwtToken, string accessToken, string refreshToken);
        public Task<JwtAuthResult> GetNewRefreshToken(User user, JwtSecurityToken jwtToken, DateTime? expiryDate, string refreshToken);
        public Task<string> ValidateToken(string accessToken);
        public Task<string> ConfirmEmailAsync(int userId, string code);
        public Task<string> SendResetPasswordCodeAsync(string email);
        public Task<string> ConfirmResetPasswordAsync(string email, string code);
        public Task<string> ResetPasswordAsync(string email, string Password);
    }
}
