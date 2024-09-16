using Microsoft.IdentityModel.Tokens;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Helpers;
using SchoolProject.Servies.Abstructs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SchoolProject.Servies.Implementation
{
    public class AuthenticationServies : IAuthenticationServies
    {


        #region Fields
        private readonly JwtSettings _jwtSettings;
        #endregion

        #region Constructors
        public AuthenticationServies(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        #endregion


        #region Handle Functions
        public async Task<string> GetJwtToken(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(nameof(UserClaimModel.UserName), user.UserName),
                new Claim(nameof(UserClaimModel.Email), user.Email),
                new Claim(nameof(UserClaimModel.PhoneNumber), user.PhoneNumber),

            };
            var jwtToken = new JwtSecurityToken(
              _jwtSettings.Issuer,
              _jwtSettings.Audience,
                claims,
              expires: DateTime.Now.AddMinutes(2),
              signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256Signature));
            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return (accessToken);

        }
        #endregion

    }
}
