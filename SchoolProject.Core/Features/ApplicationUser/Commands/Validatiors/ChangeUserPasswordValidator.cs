using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.ApplicationUser.Commands.Models;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Features.ApplicationUser.Commands.Validatiors
{
    internal class ChangeUserPasswordValidator : AbstractValidator<ChangeUserPasswordCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _stringlocalization;
        #endregion

        #region Constructors

        public ChangeUserPasswordValidator(IStringLocalizer<SharedResources> stringlocalization)
        {
            _stringlocalization = stringlocalization;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        #endregion

        #region Handel Functions

        public void ApplyValidationsRules()
        {

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(_stringlocalization[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringlocalization[SharedResourcesKeys.NotNull]);
            RuleFor(x => x.CurrentPassword)
                .NotEmpty().WithMessage(_stringlocalization[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringlocalization[SharedResourcesKeys.NotNull]);
            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage(_stringlocalization[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringlocalization[SharedResourcesKeys.NotNull]);
            //RuleFor(x => x.ConfirmPassword)
            //    .Equal(x => x.NewPassword).WithMessage(_stringlocalization[SharedResourcesKeys.PasswordNotEqualConfirmPassword]);

        }

        public void ApplyCustomValidationsRules()
        {

        }
        #endregion
    }
}
