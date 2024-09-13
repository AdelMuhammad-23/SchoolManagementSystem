using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.ApplicationUser.Commands.Models;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Features.ApplicationUser.Commands.Validatiors
{
    public class AddUserValidator : AbstractValidator<AddUserCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _stringlocalization;
        #endregion

        #region Constructors

        public AddUserValidator(IStringLocalizer<SharedResources> stringlocalization)
        {
            _stringlocalization = stringlocalization;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        #endregion

        #region Handel Functions

        public void ApplyValidationsRules()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage(_stringlocalization[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringlocalization[SharedResourcesKeys.NotNull])
                .MaximumLength(100).WithMessage(_stringlocalization[SharedResourcesKeys.MaxLenghtis100]);
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(_stringlocalization[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringlocalization[SharedResourcesKeys.NotNull])
                .MaximumLength(100).WithMessage(_stringlocalization[SharedResourcesKeys.MaxLenghtis100]);
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage(_stringlocalization[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringlocalization[SharedResourcesKeys.NotNull])
                .MaximumLength(100).WithMessage(_stringlocalization[SharedResourcesKeys.MaxLenghtis100]);
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(_stringlocalization[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringlocalization[SharedResourcesKeys.NotNull])
                .MaximumLength(100).WithMessage(_stringlocalization[SharedResourcesKeys.MaxLenghtis100]);
            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password).WithMessage(_stringlocalization[SharedResourcesKeys.PasswordNotEqualConfirmPassword]);

        }

        public void ApplyCustomValidationsRules()
        {

        }
        #endregion
    }
}
