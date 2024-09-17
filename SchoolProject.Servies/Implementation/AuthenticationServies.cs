using Microsoft.IdentityModel.Tokens;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Helpers;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Servies.Abstructs;
using System.Collections.Concurrent;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SchoolProject.Servies.Implementation
{
    public class AuthenticationServies : IAuthenticationServies
    {


        #region Fields
        private readonly JwtSettings _jwtSettings;
        private readonly IUserRefreshTokenRepository _userRefreshTokenRepository;
        private readonly ConcurrentDictionary<string, RefreshToken> _userRefreshToken;
        #endregion

        #region Constructors
        public AuthenticationServies(JwtSettings jwtSettings,
                                      IUserRefreshTokenRepository userRefreshTokenRepository)
        {
            _jwtSettings = jwtSettings;
            _userRefreshTokenRepository = userRefreshTokenRepository;
            _userRefreshToken = new ConcurrentDictionary<string, RefreshToken>();
        }

        #endregion


        #region Handle Functions
        public async Task<JwtAuthResult> GetJwtToken(User user)
        {
            var claims = GetClaims(user);
            var jwtToken = new JwtSecurityToken(
              _jwtSettings.Issuer,
              _jwtSettings.Audience,
                claims,
              expires: DateTime.Now.AddMonths(_jwtSettings.AccessTokenExpireDate),
              signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256Signature));
            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            var refreshToken = GetRefreshToken(user.UserName);

            var refreshTokenResult = new UserRefreshToken
            {
                Token = accessToken,
                RefreshToken = refreshToken.TokenString,
                IsRevoked = false,
                IsUsed = false,
                AddedTime = DateTime.Now,
                ExpiryDate = DateTime.Now.AddMonths(_jwtSettings.RefreshTokenExpireDate),
                UserId = user.Id,
                JwtId = jwtToken.Id,
            };
            await _userRefreshTokenRepository.AddAsync(refreshTokenResult);

            var response = new JwtAuthResult();
            response.AccessToken = accessToken;
            response.RefreshToken = refreshToken;
            return response;

        }
        #endregion

        public List<Claim> GetClaims(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(nameof(UserClaimModel.UserName), user.UserName),
                new Claim(nameof(UserClaimModel.Email), user.Email),
                new Claim(nameof(UserClaimModel.PhoneNumber), user.PhoneNumber),

            };
            return claims;
        }
        public RefreshToken GetRefreshToken(string userName)
        {
            var refreshToken = new RefreshToken
            {
                ExpierAt = DateTime.Now.AddMonths(_jwtSettings.RefreshTokenExpireDate),
                TokenString = GeneratRefreshToken(),
                UserName = userName
            };
            _userRefreshToken.AddOrUpdate(refreshToken.TokenString, refreshToken, (s, r) => refreshToken);
            return refreshToken;
        }
        public string GeneratRefreshToken()
        {
            var rondamNumber = new byte[32];
            var rondamNumberGenerated = RandomNumberGenerator.Create();
            rondamNumberGenerated.GetBytes(rondamNumber);
            return Convert.ToBase64String(rondamNumber);
        }

    }
}
