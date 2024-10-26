using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Features.Authentication.Commands.Validatiors
{
    public class ResetPasswordValidator : AbstractValidator<ResetPasswordCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _stringlocalization;
        #endregion

        #region Constructors

        public ResetPasswordValidator(IStringLocalizer<SharedResources> stringlocalization)
        {
            _stringlocalization = stringlocalization;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        #endregion

        #region Handel Functions

        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(_stringlocalization[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringlocalization[SharedResourcesKeys.NotNull]);
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(_stringlocalization[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringlocalization[SharedResourcesKeys.NotNull]);
            RuleFor(x => x.confirmPassword)
                .NotEmpty().WithMessage(_stringlocalization[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringlocalization[SharedResourcesKeys.NotNull])
                .Equal(x => x.Password).WithMessage(_stringlocalization[SharedResourcesKeys.PasswordNotEqualConfirmPassword]);
        }

        public void ApplyCustomValidationsRules()
        {

        }
        #endregion
    }
}
