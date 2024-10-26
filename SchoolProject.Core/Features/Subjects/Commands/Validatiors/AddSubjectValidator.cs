using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Subjects.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Servies.Abstructs;

namespace SchoolProject.Core.Features.Subjects.Commands.Validatiors
{
    public class AddSubjectValidator : AbstractValidator<AddSubjectCommand>
    {
        #region Fields
        private readonly ISubjectServies _subjectServies;
        private readonly IDepartmentServies _departmentServies;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        #endregion


        #region Constructors
        public AddSubjectValidator(ISubjectServies subjectServies,
            IStringLocalizer<SharedResources> stringLocalizer,
            IDepartmentServies departmentServies)
        {
            _subjectServies = subjectServies;
            _stringLocalizer = stringLocalizer;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
            _departmentServies = departmentServies;
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

        }


        //for Custom Rules in FluentValidation
        public void ApplyCustomValidationsRules()
        {



        }

        #endregion

    }
}