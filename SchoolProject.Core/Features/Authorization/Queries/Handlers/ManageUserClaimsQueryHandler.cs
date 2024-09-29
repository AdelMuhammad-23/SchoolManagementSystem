using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authorization.Queries.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Helpers;
using SchoolProject.Servies.Abstructs;

namespace SchoolProject.Core.Features.Authorization.Queries.Handlers
{
    public class ManageUserClaimsQueryHandler : ResponsesHandler,
        IRequestHandler<ManageUserClaimsQuery, Responses<ManageUserClaimsResponse>>


    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IAuthorizationServies _authorizationServies;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        #endregion
        #region Constructors
        public ManageUserClaimsQueryHandler(IStringLocalizer<SharedResources> stringLocalizer,
                                         IAuthorizationServies authorizationServies,
                                         IMapper mapper,
                                         UserManager<User> userManager) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _authorizationServies = authorizationServies;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<Responses<ManageUserClaimsResponse>> Handle(ManageUserClaimsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            if (user == null)
                return NotFound<ManageUserClaimsResponse>(_stringLocalizer[SharedResourcesKeys.UserIsNotFound]);

            var ManageUserClaims = await _authorizationServies.ManageUserClaims(user);

            return Success(ManageUserClaims);
        }


        #endregion
        #region Handle Functions 



        #endregion
    }
}
