using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Authorization.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Servies.Abstructs;

namespace SchoolProject.Core.Features.Authorization.Commands.Validatiors
{
    public class EditRoleValidatior : AbstractValidator<EditRoleCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IAuthorizationServies _authorizationServies;
        #endregion
        #region Constructors
        public EditRoleValidatior(IStringLocalizer<SharedResources> stringLocalizer, IAuthorizationServies authorizationServies)
        {
            _stringLocalizer = stringLocalizer;
            _authorizationServies = authorizationServies;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        #endregion
        #region Handle Functions

        //for Rules in FluentValidation
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull]);
            RuleFor(x => x.oldRole)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull]);
            RuleFor(x => x.newRole)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull]);
        }


        //for Custom Rules in FluentValidation
        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.newRole)
                .MustAsync(async (Model, Key, CancellationToken) => !await _authorizationServies.IsRoleNameExistExcludeSelf(Key, Model.Id))
                .WithMessage(_stringLocalizer[SharedResourcesKeys.IsExist]);


        }

        #endregion
    }
}
