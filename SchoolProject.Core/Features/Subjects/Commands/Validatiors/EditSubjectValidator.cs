using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Subjects.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Servies.Abstructs;

namespace SchoolProject.Core.Features.Subjects.Commands.Validatiors
{
    public class EditSubjectValidator : AbstractValidator<EditSubjectCommand>
    {
        #region Fields
        private readonly ISubjectServies _subjectServies;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        #endregion


        #region Constructors
        public EditSubjectValidator(ISubjectServies subjectServies,
            IStringLocalizer<SharedResources> stringLocalizer)
        {
            _subjectServies = subjectServies;
            _stringLocalizer = stringLocalizer;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }

        #endregion


        #region Handel Functions
        //for Rules in FluentValidation
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.SubjectNameAR)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull])
                .MaximumLength(100).WithMessage(_stringLocalizer[SharedResourcesKeys.MaxLenghtis100]);
            RuleFor(x => x.SubjectNameEn)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull])
                .MaximumLength(100).WithMessage(_stringLocalizer[SharedResourcesKeys.MaxLenghtis100]);
            RuleFor(x => x.Period)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull]);

        }


        //for Custom Rules in FluentValidation
        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.SubjectNameAR)
                .MustAsync(async (Model, Key, CancellationToken) => !await _subjectServies.IsNameArabicExistExcludeSelf(Key, Model.Id))
                .WithMessage(_stringLocalizer[SharedResourcesKeys.IsExist]);
            RuleFor(x => x.SubjectNameEn)
                .MustAsync(async (Model, Key, CancellationToken) => !await _subjectServies.IsNameEnglishExistExcludeSelf(Key, Model.Id))
                .WithMessage(_stringLocalizer[SharedResourcesKeys.IsExist]);
        }

        #endregion

    }
}