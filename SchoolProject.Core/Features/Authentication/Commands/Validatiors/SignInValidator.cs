using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Features.Authentication.Commands.Validatiors
{
    internal class SignInValidator : AbstractValidator<SignInCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _stringlocalization;
        #endregion

        #region Constructors

        public SignInValidator(IStringLocalizer<SharedResources> stringlocalization)
        {
            _stringlocalization = stringlocalization;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        #endregion

        #region Handel Functions

        public void ApplyValidationsRules()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage(_stringlocalization[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringlocalization[SharedResourcesKeys.NotNull]);
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(_stringlocalization[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringlocalization[SharedResourcesKeys.NotNull]);
        }

        public void ApplyCustomValidationsRules()
        {

        }
        #endregion
    }
}
