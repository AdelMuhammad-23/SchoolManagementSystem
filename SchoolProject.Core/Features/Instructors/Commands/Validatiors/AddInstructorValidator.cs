using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Instructors.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Servies.Abstructs;

namespace SchoolProject.Core.Features.Instructors.Commands.Validatiors
{
    public class AddInstructorValidator : AbstractValidator<AddInstructorCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IDepartmentServies _departmentService;
        private readonly IInstructorServies _instructorService;
        #endregion

        #region Constructors
        public AddInstructorValidator(IStringLocalizer<SharedResources> localizer,
                                      IDepartmentServies departmentService,
                                      IInstructorServies instructorService)
        {
            _localizer = localizer;
            _instructorService = instructorService;
            _departmentService = departmentService;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();

        }
        #endregion

        #region Actions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.NameAR)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);

            RuleFor(x => x.NameEr)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);

            RuleFor(x => x.DID)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
        }

        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.NameAR)
                .MustAsync(async (Key, CancellationToken) => !await _instructorService.IsNameArExist(Key))
                .WithMessage(_localizer[SharedResourcesKeys.IsExist]);
            RuleFor(x => x.NameEr)
               .MustAsync(async (Key, CancellationToken) => !await _instructorService.IsNameEnExist(Key))
               .WithMessage(_localizer[SharedResourcesKeys.IsExist]);

            RuleFor(x => x.DID)
           .MustAsync(async (Key, CancellationToken) => await _departmentService.IsDepartmentIdExist(Key))
           .WithMessage("Not Exist");

        }

        #endregion

    }
}