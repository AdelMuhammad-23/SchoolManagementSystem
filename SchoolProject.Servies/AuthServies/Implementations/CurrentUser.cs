using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Helpers;
using SchoolProject.Servies.AuthServies.Interfaces;

namespace SchoolProject.Servies.AuthServies.Implementations
{
    public class CurrentUser : ICurrentUser
    {

        #region Fields
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UserManager<User> _userManager;
        #endregion

        #region Constructors
        public CurrentUser(IHttpContextAccessor contextAccessor, UserManager<User> userManager)
        {
            _contextAccessor = contextAccessor;
            _userManager = userManager;
        }
        #endregion

        #region Functions 
        public int GetCurrentUserId()
        {
            var userId = _contextAccessor.HttpContext.User.Claims.SingleOrDefault(claim => claim.Type == nameof(UserClaimModel.Id)).Value;
            if (userId == null)
            {
                throw new UnauthorizedAccessException();
            }

            return int.Parse(userId);
        }
        public async Task<User> GetCurrentUserAsync()
        {
            var userId = GetCurrentUserId();
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                throw new UnauthorizedAccessException();
            return user;
        }

        public async Task<List<string>> GetCurrentUserRolesAsync()
        {
            var user = await GetCurrentUserAsync();
            var userRoles = await _userManager.GetRolesAsync(user);
            return userRoles.ToList();
        }
        #endregion



    }
}
