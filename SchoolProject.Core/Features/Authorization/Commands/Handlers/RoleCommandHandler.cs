using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authorization.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Servies.Abstructs;

namespace SchoolProject.Core.Features.Authorization.Commands.Handlers
{
    public class RoleCommandHandler : ResponsesHandler,
        IRequestHandler<AddRoleCommand, Responses<string>>,
        IRequestHandler<EditRoleCommand, Responses<string>>,
        IRequestHandler<DeleteRoleCommand, Responses<string>>,
        IRequestHandler<EditUserRoleCommand, Responses<string>>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IAuthorizationServies _authorizationServies;
        #endregion
        #region Constructors
        public RoleCommandHandler(IStringLocalizer<SharedResources> stringLocalizer,
                                  IAuthorizationServies authorizationServies) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _authorizationServies = authorizationServies;
        }
        #endregion
        #region Handle Functions 
        public async Task<Responses<string>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationServies.AddRoleAsync(request.RoleName);
            if (result == "Success")
                return Success("");
            else
                return BadRequest<string>("");

        }

        public async Task<Responses<string>> Handle(EditRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationServies.EditRoleAsync(request.oldRole, request.newRole);
            if (result == "this role is not Found")
                return NotFound<string>(_stringLocalizer[SharedResourcesKeys.RoleIsNotFound]);
            else if (result == "Success")
                return Success<string>(_stringLocalizer[SharedResourcesKeys.Success]);
            else
                return BadRequest<string>(result);
        }

        public async Task<Responses<string>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationServies.DeleteRoleAsync(request.Id);
            if (result == "this role is not Found")
                return NotFound<string>(_stringLocalizer[SharedResourcesKeys.RoleIsNotFound]);
            else if (result == "Used")
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.RoleIsUsed]);
            else if (result == "Success")
                return Deleted<string>(_stringLocalizer[SharedResourcesKeys.Deleted]);
            else
                return BadRequest<string>(result);
        }

        public async Task<Responses<string>> Handle(EditUserRoleCommand request, CancellationToken cancellationToken)
        {
            var editUserRoleCommand = await _authorizationServies.EditUserRoleAsync(request);
            switch (editUserRoleCommand)
            {
                case "User Not Found": return NotFound<string>(_stringLocalizer[SharedResourcesKeys.UserIsNotFound]);
                case "Failed to remove old UserRoles": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FailedToRemoveOldRoles]);
                case "Failed to Add New UserRoles": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FailedToAddNewRoles]);
                case "Failed to Update UserRoles": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FailedToUpdateUserRoles]);
            }
            return Success<string>(_stringLocalizer[SharedResourcesKeys.Success]);
        }

        #endregion
    }
}
