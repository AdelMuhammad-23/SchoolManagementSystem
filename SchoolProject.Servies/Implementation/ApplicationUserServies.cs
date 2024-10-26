using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Helpers;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Servies.Abstructs;

namespace SchoolProject.Servies.Implementation
{
    public class ApplicationUserServies : IApplicationUserServies
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUrlHelper _urlHelper;
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        private readonly IEmailServies _emailServies;
        public ApplicationUserServies(IHttpContextAccessor contextAccessor,
                                      IUrlHelper urlHelper,
                                      ApplicationDbContext dbContext,
                                      UserManager<User> userManager,
                                      IEmailServies emailServies)
        {
            _contextAccessor = contextAccessor;
            _urlHelper = urlHelper;
            _dbContext = dbContext;
            _userManager = userManager;
            _emailServies = emailServies;
        }
        public async Task<string> AddUserAsync(User user, string password)
        {
            var Transact = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                // Find User Email
                var emailUser = await _userManager.FindByEmailAsync(user.Email);
                //Email is or not exist
                if (emailUser != null) return "EmailIsExist";
                //Find User Name
                var userName = await _userManager.FindByNameAsync(user.UserName);
                //UserName is or not exist
                if (userName != null) return "UserNameIsExist";
                // Create User
                var createUser = await _userManager.CreateAsync(user, password);

                if (!createUser.Succeeded)
                    return createUser.Errors.FirstOrDefault().Description;

                await _userManager.AddToRoleAsync(user, DefaultRoles.User);

                //Send Confirm Email
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var resquestAccessor = _contextAccessor.HttpContext.Request;
                var returnUrl = resquestAccessor.Scheme + "://" + resquestAccessor.Host + _urlHelper.Action("ConfirmEmail", "Authentication", new { userId = user.Id, code = code });
                var message = $"To Confirm Email Click Link: <a href='{returnUrl}'>Link Of Confirmation</a>";

                //message or body
                await _emailServies.SendEmailAsync(user.Email, message, "ConFirm Email");

                await Transact.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                await Transact.RollbackAsync();
                return "Failed";

            }
        }
    }
}
