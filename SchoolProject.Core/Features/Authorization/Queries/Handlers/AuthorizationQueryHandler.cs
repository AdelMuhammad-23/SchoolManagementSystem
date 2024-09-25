using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authorization.Queries.Models;
using SchoolProject.Core.Features.Authorization.Queries.Response;
using SchoolProject.Core.Resources;
using SchoolProject.Servies.Abstructs;

namespace SchoolProject.Core.Features.Authorization.Queries.Handlers
{
    public class AuthorizationQueryHandler : ResponsesHandler,
        IRequestHandler<GetRoleListQuery, Responses<List<GetRolesListResponse>>>,
        IRequestHandler<GetRoleByIdQuery, Responses<GetRoleByIdResponse>>

    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IAuthorizationServies _authorizationServies;
        private readonly IMapper _mapper;
        #endregion
        #region Constructors
        public AuthorizationQueryHandler(IStringLocalizer<SharedResources> stringLocalizer,
                                         IAuthorizationServies authorizationServies,
                                         IMapper mapper) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _authorizationServies = authorizationServies;
            _mapper = mapper;
        }


        #endregion
        #region Handle Functions 
        public async Task<Responses<List<GetRolesListResponse>>> Handle(GetRoleListQuery request, CancellationToken cancellationToken)
        {
            var roles = await _authorizationServies.GetRolesListAsync();
            if (roles == null)
                return BadRequest<List<GetRolesListResponse>>("No Roles Found");
            var RolesMapping = _mapper.Map<List<GetRolesListResponse>>(roles);
            return Success(RolesMapping);
        }

        public async Task<Responses<GetRoleByIdResponse>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var role = await _authorizationServies.GetRoleByIdAsync(request.Id);
            if (role == null)
                return BadRequest<GetRoleByIdResponse>(_stringLocalizer[SharedResourcesKeys.RoleIsNotFound]);
            var roleMapping = _mapper.Map<GetRoleByIdResponse>(role);
            return Success(roleMapping);
        }
        #endregion
    }
}
