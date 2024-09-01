using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Servies.Abstructs;

namespace SchoolProject.Core.Features.Students.Commands.Validatiors
{
    public class EditStudentValidator : AbstractValidator<EditStudentCommand>
    {
        #region Fields
        private readonly IStudentServies _studentServies;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        #endregion


        #region Constructors
        public EditStudentValidator(IStudentServies studentServies, IStringLocalizer<SharedResources> stringLocalizer)
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
            RuleFor(x => x.NameInArbic)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull])
                .MaximumLength(100).WithMessage(_stringLocalizer[SharedResourcesKeys.MaxLenghtis100]);
            RuleFor(x => x.NameInEnglish)
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
            RuleFor(x => x.NameInArbic)
    .MustAsync(async (Model, Key, CancellationToken) => !await _studentServies.IsNameExistExcludeSelf(Key, Model.Id))
                .WithMessage(_stringLocalizer[SharedResourcesKeys.IsExist]);

            RuleFor(x => x.NameInEnglish)
                .MustAsync(async (Model, Key, CancellationToken) => !await _studentServies.IsNameExistExcludeSelf(Key, Model.Id))
                .WithMessage(_stringLocalizer[SharedResourcesKeys.IsExist]);
        }


        #endregion

    }
}