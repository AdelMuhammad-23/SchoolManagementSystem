using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        private readonly UserManager<User> _userManager;
        private readonly IUserRefreshTokenRepository _refreshTokenRepository;

        #endregion

        #region Constructors
        public AuthenticationServies(JwtSettings jwtSettings,
                                     IUserRefreshTokenRepository userRefreshTokenRepository,
                                     UserManager<User> userManager,
                                     IUserRefreshTokenRepository refreshTokenRepository)
        {
            _jwtSettings = jwtSettings;
            _userRefreshTokenRepository = userRefreshTokenRepository;
            _userRefreshToken = new ConcurrentDictionary<string, RefreshToken>();
            _userManager = userManager;
            _refreshTokenRepository = refreshTokenRepository;
        }

        #endregion

        #region Handle Functions
        public async Task<JwtAuthResult> GetJwtToken(User user)
        {
            var (jwtToken, accessToken) = GetJWTToken(user);
            var refreshToken = GetRefreshToken(user.UserName);

            var refreshTokenResult = new UserRefreshToken
            {
                Token = accessToken,
                RefreshToken = refreshToken.TokenString,
                IsRevoked = false,
                IsUsed = true,
                AddedTime = DateTime.Now,
                ExpiryDate = DateTime.Now.AddDays(_jwtSettings.RefreshTokenExpireDate),
                UserId = user.Id,
                JwtId = jwtToken.Id,
            };

            //add this data in UserRefreshTokenTable in database
            await _userRefreshTokenRepository.AddAsync(refreshTokenResult);

            var response = new JwtAuthResult();
            response.AccessToken = accessToken;
            response.RefreshToken = refreshToken;
            return response;

        }
        public async Task<JwtAuthResult> GetNewRefreshToken(User user, JwtSecurityToken jwtToken, DateTime? expiryDate, string refreshToken)
        {

            var (jwtSecurityToken, newToken) = GetJWTToken(user);
            #region Generate New Refresh Token
            var response = new JwtAuthResult();
            //new AccessToken
            response.AccessToken = newToken;
            //new Refresh Token
            var refreshTokenResult = new RefreshToken();
            refreshTokenResult.UserName = jwtToken.Claims.FirstOrDefault(x => x.Type == nameof(UserClaimModel.UserName)).Value;
            refreshTokenResult.TokenString = refreshToken;
            refreshTokenResult.ExpierAt = (DateTime)expiryDate;
            response.RefreshToken = refreshTokenResult;

            return response;
            #endregion
        }
        public async Task<string> ValidateToken(string accessToken)
        {

            var handler = new JwtSecurityTokenHandler();
            var parameterHandler = new TokenValidationParameters
            {
                ValidateIssuer = _jwtSettings.ValidateIssuer,
                ValidIssuers = new[] { _jwtSettings.Issuer },
                ValidateIssuerSigningKey = _jwtSettings.ValidateIssuerSigningKey,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)),
                ValidAudience = _jwtSettings.Audience,
                ValidateAudience = _jwtSettings.ValidateAudience,
                ValidateLifetime = _jwtSettings.ValidateLifeTime,
            };

            try
            {
                var validator = handler.ValidateToken(accessToken, parameterHandler, out SecurityToken validatedToken);

                if (validatedToken == null)
                {
                    return "InvalidToken";
                }
                return "NotExpired";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }





        #endregion

        #region Claims Functions
        private List<Claim> GetClaims(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(nameof(UserClaimModel.UserName), user.UserName),
                new Claim(nameof(UserClaimModel.Email), user.Email),
                new Claim(nameof(UserClaimModel.PhoneNumber), user.PhoneNumber),
                new Claim(nameof(UserClaimModel.Id), user.Id.ToString()),

            };
            return claims;
        }
        #endregion

        #region JWT Token Functions  For Help
        // using tabel to retern more than one of types like string and JwtSecurityToken
        private (JwtSecurityToken, string) GetJWTToken(User user)
        {
            var claims = GetClaims(user);
            var jwtToken = new JwtSecurityToken(
              _jwtSettings.Issuer,
              _jwtSettings.Audience,
                claims,
              expires: DateTime.Now.AddDays(_jwtSettings.AccessTokenExpireDate),
              signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256Signature));
            //token
            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return (jwtToken, accessToken);
        }

        public JwtSecurityToken ReadJwtToken(string accessToken)
        {
            if (String.IsNullOrEmpty(accessToken))
                throw new ArgumentNullException(nameof(accessToken));

            var handler = new JwtSecurityTokenHandler();

            var response = handler.ReadJwtToken(accessToken);
            return response;

        }
        #endregion

        #region Refresh Token Functions for Help
        private RefreshToken GetRefreshToken(string userName)
        {
            var refreshToken = new RefreshToken
            {
                ExpierAt = DateTime.Now.AddMonths(_jwtSettings.RefreshTokenExpireDate),
                TokenString = GeneratRefreshToken(),
                UserName = userName
            };
            //if refreshtoken is exist => update if not Add
            _userRefreshToken.AddOrUpdate(refreshToken.TokenString, refreshToken, (s, r) => refreshToken);
            return refreshToken;
        }
        private string GeneratRefreshToken()
        {
            var rondamNumber = new byte[32];
            var rondamNumberGenerated = RandomNumberGenerator.Create();
            rondamNumberGenerated.GetBytes(rondamNumber);
            return Convert.ToBase64String(rondamNumber);
        }

        public async Task<(string, DateTime?)> ValidateDetails(JwtSecurityToken jwtToken, string accessToken, string refreshToken)
        {
            if (jwtToken == null || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature))
            {
                return ("Algorithms is not correct", null);
            }
            // validate Token
            if (jwtToken.ValidTo > DateTime.UtcNow)
            {
                return ("Token is not expired", null);
            }

            //Get User Id
            var userId = jwtToken.Claims.FirstOrDefault(x => x.Type == nameof(UserClaimModel.Id)).Value;
            //Get User
            var userRefreshToken = await _refreshTokenRepository.GetTableNoTracking()
                                             .FirstOrDefaultAsync(x => x.Token == accessToken &&
                                                                     x.RefreshToken == refreshToken &&
                                                                     x.UserId == int.Parse(userId));

            if (userRefreshToken == null)
            {
                return ("Refresh Token is Not Found", null);
            }

            // validate Refresh Token
            if (userRefreshToken.ExpiryDate < DateTime.UtcNow)
            {
                userRefreshToken.IsRevoked = true;
                userRefreshToken.IsUsed = false;
                await _refreshTokenRepository.UpdateAsync(userRefreshToken);
                return ("Refresh Token is expired", null);
            }
            var expirydate = userRefreshToken.ExpiryDate;
            return (userId, expirydate);
        }
        #endregion






    }
}
