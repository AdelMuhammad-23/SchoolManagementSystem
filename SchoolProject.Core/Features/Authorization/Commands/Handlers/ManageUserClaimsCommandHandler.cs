using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authorization.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Servies.Abstructs;

namespace SchoolProject.Core.Features.Authorization.Commands.Handlers
{
    public class ManageUserClaimsCommandHandler : ResponsesHandler,
        IRequestHandler<EditUserClaimsCommand, Responses<string>>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IAuthorizationServies _authorizationServies;
        #endregion
        #region Constructors
        public ManageUserClaimsCommandHandler(IStringLocalizer<SharedResources> stringLocalizer,
                                  IAuthorizationServies authorizationServies) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _authorizationServies = authorizationServies;
        }


        #endregion
        #region Handle Functions 

        public async Task<Responses<string>> Handle(EditUserClaimsCommand request, CancellationToken cancellationToken)
        {
            var editUserRoleCommand = await _authorizationServies.EditUserClaimsAsync(request);
            switch (editUserRoleCommand)
            {
                case "User Not Found": return NotFound<string>(_stringLocalizer[SharedResourcesKeys.UserIsNotFound]);
                case "Failed to remove old UserClaims": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FailedToRemoveOldRoles]);
                case "Failed to Add New UserClaims": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FailedToAddNewRoles]);
                case "Failed to Edit  UserClaims": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FailedToUpdateUserRoles]);
            }
            return Success<string>(_stringLocalizer[SharedResourcesKeys.Success]);
        }

        #endregion
    }
}
