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
        IRequestHandler<AddUserCommand, Responses<string>>
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
        #endregion

    }
}
