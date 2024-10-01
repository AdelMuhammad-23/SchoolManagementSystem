using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Email.Commands.Models;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Features.Email.Commands.Validatiors
{
    public class SendEmailValidator : AbstractValidator<SendEmailCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        #endregion


        #region Constructors
        public SendEmailValidator(IStringLocalizer<SharedResources> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            ApplyValidationsRules();
        }

        #endregion


        #region Handel Functions
        //for Rules in FluentValidation
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull]);
            RuleFor(x => x.Massage)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull]);
        }

        #endregion
    }
}
