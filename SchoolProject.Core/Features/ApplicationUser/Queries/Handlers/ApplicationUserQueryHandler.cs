using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.ApplicationUser.Queries.Models;
using SchoolProject.Core.Features.ApplicationUser.Queries.Response;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Servies.Abstructs;

namespace SchoolProject.Core.Features.ApplicationUser.Queries.Handlers
{
    public class ApplicationUserQueryHandler : ResponsesHandler,
        IRequestHandler<GetUserPaginatedListQuery, PaginatedResult<GetUserPaginatedListResponse>>,
        IRequestHandler<GetUserByIdQuery, Responses<GetUserByIdResponse>>,
        IRequestHandler<ConfirmResetPasswordQuery, Responses<string>>
    {

        #region Fields
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IAuthenticationServies _authenticationServies;

        #endregion

        #region
        public ApplicationUserQueryHandler(IStringLocalizer<SharedResources> stringLocalizer,
                                            IMapper mapper,
                                            UserManager<User> userManager,
                                            IAuthenticationServies authenticationServies) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
            _userManager = userManager;
            _authenticationServies = authenticationServies;
        }
        #endregion

        #region

        public async Task<PaginatedResult<GetUserPaginatedListResponse>> Handle(GetUserPaginatedListQuery request, CancellationToken cancellationToken)
        {
            //Get Users
            var users = _userManager.Users.AsQueryable();
            //Map Users
            var usersMapping = await _mapper.ProjectTo<GetUserPaginatedListResponse>(users)
                                       .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return usersMapping;
        }

        public async Task<Responses<GetUserByIdResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id.ToString());

            if (user == null)
                return NotFound<GetUserByIdResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]);

            var userMapping = _mapper.Map<GetUserByIdResponse>(user);
            return Success(userMapping);
        }

        public async Task<Responses<string>> Handle(ConfirmResetPasswordQuery request, CancellationToken cancellationToken)
        {
            var resetPassword = await _authenticationServies.ConfirmResetPasswordAsync(request.Email, request.Code);
            switch (resetPassword)
            {
                case ("User is not found "):
                    return NotFound<string>(_stringLocalizer[SharedResourcesKeys.UserIsNotFound]);
                case ("Invalid Code"):
                    return BadRequest<string>("Invalid Code");
                case ("Success"):
                    return Success<string>(_stringLocalizer[SharedResourcesKeys.Success]);
                default:
                    return BadRequest<string>();

            }
            throw new NotImplementedException();
        }




        #endregion
    }
}
