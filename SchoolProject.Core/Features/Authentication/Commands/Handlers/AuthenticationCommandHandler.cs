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
        IRequestHandler<RefreshTokenCommand, Responses<JwtAuthResult>>,
        IRequestHandler<ConfirmEmailCommand, Responses<string>>,
        IRequestHandler<ResetPasswordCommand, Responses<string>>
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

            //email confirmed
            if (!user.EmailConfirmed)
                return BadRequest<JwtAuthResult>(_stringLocalizer[SharedResourcesKeys.EmailIsNotConfirmed]);
            //Generate Token
            var result = await _authenticationService.GetJwtToken(user);
            //return Token 
            return Success(result);

        }

        public async Task<Responses<JwtAuthResult>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var jwtToken = _authenticationService.ReadJwtToken(request.AccessToken);
            var userIdAndExpireDate = await _authenticationService.ValidateDetails(jwtToken, request.AccessToken, request.RefreshToken);
            switch (userIdAndExpireDate)
            {
                case ("Algorithms is not correct", null):
                    return Unauthorized<JwtAuthResult>(_stringLocalizer[SharedResourcesKeys.AlgorithmsIsNotCorrect]);
                case (("Token is not expired", null)):
                    return BadRequest<JwtAuthResult>(_stringLocalizer[SharedResourcesKeys.TokenIsNotExpired]);
                case ("Refresh Token is Not Found", null):
                    return NotFound<JwtAuthResult>(_stringLocalizer[SharedResourcesKeys.RefreshTokenIsNotFound]);
                case ("Refresh Token is expired", null):
                    return Unauthorized<JwtAuthResult>(_stringLocalizer[SharedResourcesKeys.RefreshTokenIsExpired]);

            }

            var (userId, expiryDate) = userIdAndExpireDate;
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound<JwtAuthResult>();
            }
            var result = await _authenticationService.GetNewRefreshToken(user, jwtToken, expiryDate, request.RefreshToken);
            return Success(result);
        }

        public async Task<Responses<string>> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            var confirmEmail = await _authenticationService.ConfirmEmailAsync(request.userId, request.Code);
            switch (confirmEmail)
            {
                case "Invalid UserId Or Code":
                    return UnprocessableEntity<string>(_stringLocalizer[SharedResourcesKeys.UnprocessableEntity]);
                case "Error When Confirm Email":
                    return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.BadRequest]);
                default:
                    return Success<string>(_stringLocalizer[SharedResourcesKeys.Success]);
            }

        }

        public async Task<Responses<string>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var resetPassword = await _authenticationService.ResetPasswordAsync(request.Email, request.Password);
            switch (resetPassword)
            {
                case "User is not found ":
                    return NotFound<string>(_stringLocalizer[SharedResourcesKeys.UserIsNotFound]);
                case "Failed":
                    return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.BadRequest]);
                default:
                    return Success<string>(_stringLocalizer[SharedResourcesKeys.Success]);
            }
        }
        #endregion

    }
}
