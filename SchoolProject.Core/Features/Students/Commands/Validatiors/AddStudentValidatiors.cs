using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Servies.Abstructs;

namespace SchoolProject.Core.Features.Students.Commands.Validatiors
{
    public class AddStudentValidators : AbstractValidator<AddStudentCommand>
    {
        #region Fields
        private readonly IStudentServies _studentServies;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        #endregion


        #region Constructors
        public AddStudentValidators(IStudentServies studentServies, IStringLocalizer<SharedResources> stringLocalizer)
        {
            _studentServies = studentServies;
            _stringLocalizer = stringLocalizer;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();

        }

        #endregion


        #region Handel Functions
        //for Rules in FluentValidation
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull])
                .MaximumLength(100).WithMessage(_stringLocalizer[SharedResourcesKeys.MaxLenghtis100]);


            RuleFor(x => x.Address)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull])
                .MaximumLength(100).WithMessage(_stringLocalizer[SharedResourcesKeys.MaxLenghtis100]);

        }


        //for Custom Rules in FluentValidation
        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.Name)
                .MustAsync(async (Key, CancellationToken) => !await _studentServies.IsNameExist(Key))
                .WithMessage(_stringLocalizer[SharedResourcesKeys.IsExist]);
        }

        #endregion

    }
}
