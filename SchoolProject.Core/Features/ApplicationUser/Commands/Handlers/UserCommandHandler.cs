using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.ApplicationUser.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Core.Features.ApplicationUser.Commands.Handlers
{
    public class UserCommandHandler : ResponsesHandler,
        IRequestHandler<AddUserCommand, Responses<string>>,
        IRequestHandler<EditUserCommand, Responses<string>>,
        IRequestHandler<DeleteUserCommand, Responses<string>>,
        IRequestHandler<ChangeUserPasswordCommand, Responses<string>>

    {
        #region fields
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly RoleManager<Role> _identityRole;
        #endregion
        #region Constructors
        public UserCommandHandler(IStringLocalizer<SharedResources> stringLocalizer,
                                  IMapper mapper,
                                  UserManager<User> userManager,
                                  RoleManager<Role> identityRole) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
            _userManager = userManager;
            _identityRole = identityRole;
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
            var users = await _userManager.Users.ToListAsync();

            await _userManager.AddToRoleAsync(UserMapping, DefaultRoles.User);

            return Created("");
        }

        public async Task<Responses<string>> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id.ToString());

            if (user == null)
                return NotFound<string>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            //Find User Name
            var userName = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == user.UserName && x.Id != user.Id);
            //UserName is or not exist
            if (userName != null) return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.UserNameIsExist]);


            var userMapping = _mapper.Map(request, user);
            var userUpdated = await _userManager.UpdateAsync(userMapping);

            if (!userUpdated.Succeeded)
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FaildToUpdatedUser]);

            return Success((string)_stringLocalizer[SharedResourcesKeys.Updated]);

        }

        public async Task<Responses<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            //Check if the Id is Exist Or not
            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            //return NotFound
            if (user == null) return NotFound<string>();
            //Call service that make Delete
            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
                return BadRequest<string>();

            return Success((string)_stringLocalizer[SharedResourcesKeys.Deleted]);
        }

        public async Task<Responses<string>> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            //Check if the Id is Exist Or not
            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            //return NotFound
            if (user == null)
                return NotFound<string>();
            var newUser = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);

            if (request.NewPassword != request.ConfirmPassword)
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.PasswordNotEqualConfirmPassword]);

            if (!newUser.Succeeded)
                return BadRequest<string>(newUser.Errors.FirstOrDefault().Description);

            return Success((string)_stringLocalizer[SharedResourcesKeys.Success]);




        }
        #endregion

    }
}
