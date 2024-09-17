using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Helpers;
using SchoolProject.Servies.Abstructs;

namespace SchoolProject.Core.Features.Authentication.Commands
{
    public class AuthenticationCommandHandler : ResponsesHandler,
        IRequestHandler<SignInCommand, Responses<JwtAuthResult>>,
        IRequestHandler<RefreshTokenCommand, Responses<JwtAuthResult>>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IAuthenticationServies _authenticationService;


        #endregion

        #region Constructors
        public AuthenticationCommandHandler(IStringLocalizer<SharedResources> stringLocalizer,
                                            UserManager<User> userManager,
                                            SignInManager<User> signInManager,
                                            IAuthenticationServies authenticationService) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _userManager = userManager;
            _signInManager = signInManager;
            _authenticationService = authenticationService;
        }


        #endregion


        #region Handle Functions
        public async Task<Responses<JwtAuthResult>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            //Check if user is exist or not
            var user = await _userManager.FindByNameAsync(request.UserName);
            //Return The UserName Not Found
            if (user == null) return BadRequest<JwtAuthResult>(_stringLocalizer[SharedResourcesKeys.UserNameIsNotExist]);
            //try To Sign in 
            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            //if Failed Return Passord is wrong
            if (!signInResult.Succeeded) return BadRequest<JwtAuthResult>(_stringLocalizer[SharedResourcesKeys.PasswordIsNotCorrect]);

            //Generate Token
            var result = await _authenticationService.GetJwtToken(user);
            //return Token 
            return Success(result);

        }

        public async Task<Responses<JwtAuthResult>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var result = await _authenticationService.GetNewRefreshToken(request.AccessToken, request.RefreshToken);
            return Success(result);
        }
        #endregion

    }
}
