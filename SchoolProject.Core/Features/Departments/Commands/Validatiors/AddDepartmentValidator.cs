using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Departments.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Servies.Abstructs;

namespace SchoolProject.Core.Features.Departments.Commands.Validatiors
{
    public class AddDepartmentValidator : AbstractValidator<AddDepartmentCommand>
    {

        #region Fields
        private readonly IDepartmentServies _departmentServies;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        #endregion


        #region Constructors
        public AddDepartmentValidator(IStringLocalizer<SharedResources> stringLocalizer,
            IDepartmentServies departmentServies)
        {
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
            RuleFor(x => x.DNameAr)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull])
                .MaximumLength(100).WithMessage(_stringLocalizer[SharedResourcesKeys.MaxLenghtis100]);
            RuleFor(x => x.DNameEn)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull])
                .MaximumLength(100).WithMessage(_stringLocalizer[SharedResourcesKeys.MaxLenghtis100]);


        }


        //for Custom Rules in FluentValidation
        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.DNameAr)
                .MustAsync(async (Key, CancellationToken) => !await _departmentServies.IsDepartmentNameArabicIsExist(Key))
                .WithMessage(_stringLocalizer[SharedResourcesKeys.IsDepartmentExist]);
            RuleFor(x => x.DNameEn)
                .MustAsync(async (Key, CancellationToken) => !await _departmentServies.IsDepartmentNameEnglishIsExist(Key))
                .WithMessage(_stringLocalizer[SharedResourcesKeys.IsDepartmentExist]);
        }

        #endregion

    }
}