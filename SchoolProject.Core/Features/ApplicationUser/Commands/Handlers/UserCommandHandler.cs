using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.ApplicationUser.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Core.Features.ApplicationUser.Commands.Handlers
{
    public class UserCommandHandler : ResponsesHandler,
        IRequestHandler<AddUserCommand, Responses<string>>,
        IRequestHandler<EditUserCommand, Responses<string>>

    {
        #region fields
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion
        #region Constructors
        public UserCommandHandler(IStringLocalizer<SharedResources> stringLocalizer,
                                  IMapper mapper,
                                  UserManager<User> userManager) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
            _userManager = userManager;
        }


        #endregion
        #region Handle Functions 
        public async Task<Responses<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            // Find User Email
            var emailUser = await _userManager.FindByEmailAsync(request.Email);
            //Email is or not exist
            if (emailUser != null) return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.EmailIsExist]);
            //Find User Name
            var userName = await _userManager.FindByNameAsync(request.UserName);
            //UserName is or not exist
            if (userName != null) return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.UserNameIsExist]);
            //Mapping User 
            var UserMapping = _mapper.Map<User>(request);
            // Create User
            var createUser = await _userManager.CreateAsync(UserMapping, request.Password);

            if (!createUser.Succeeded)
                return BadRequest<string>(createUser.Errors.FirstOrDefault().Description);

            return Created("");
        }

        public async Task<Responses<string>> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id.ToString());

            if (user == null)
                return NotFound<string>(_stringLocalizer[SharedResourcesKeys.NotFound]);


            var userMapping = _mapper.Map(request, user);
            var userUpdated = await _userManager.UpdateAsync(userMapping);

            if (!userUpdated.Succeeded)
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FaildToUpdatedUser]);

            return Success((string)_stringLocalizer[SharedResourcesKeys.Updated]);

        }
        #endregion

    }
}
