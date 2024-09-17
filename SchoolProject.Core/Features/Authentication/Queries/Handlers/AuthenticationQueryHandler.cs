using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authentication.Queries.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Servies.Abstructs;

namespace SchoolProject.Core.Features.Authentication.Queries.Handlers
{
    public class AuthenticationQueryHandler : ResponsesHandler,
        IRequestHandler<AuthorizeUserQuery, Responses<string>>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly UserManager<User> _userManager;
        private readonly IAuthenticationServies _authenticationService;


        #endregion

        #region Constructors
        public AuthenticationQueryHandler(IStringLocalizer<SharedResources> stringLocalizer,
                                            UserManager<User> userManager,
                                            IAuthenticationServies authenticationService) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _userManager = userManager;
            _authenticationService = authenticationService;
        }


        #endregion


        #region Handle Functions

        public async Task<Responses<string>> Handle(AuthorizeUserQuery request, CancellationToken cancellationToken)
        {
            var response = await _authenticationService.ValidateToken(request.Accesstoken);
            if (response == "NotExpired")
                return Success(response);

            return BadRequest<string>("Expired");
        }


        #endregion

    }
}
