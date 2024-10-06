using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Features.Authentication.Commands.Validatiors
{
    public class ConfirmEmailValidator : AbstractValidator<ConfirmEmailCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _stringlocalization;
        #endregion

        #region Constructors

        public ConfirmEmailValidator(IStringLocalizer<SharedResources> stringlocalization)
        {
            _stringlocalization = stringlocalization;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        #endregion

        #region Handel Functions

        public void ApplyValidationsRules()
        {
            RuleFor(x => x.userId)
                .NotEmpty().WithMessage(_stringlocalization[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringlocalization[SharedResourcesKeys.NotNull]);
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage(_stringlocalization[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringlocalization[SharedResourcesKeys.NotNull]);
        }

        public void ApplyCustomValidationsRules()
        {

        }
        #endregion
    }
}
