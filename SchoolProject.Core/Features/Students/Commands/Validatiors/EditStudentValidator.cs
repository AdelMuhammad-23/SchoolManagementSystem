using FluentValidation;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Servies.Abstructs;

namespace SchoolProject.Core.Features.Students.Commands.Validatiors
{
    public class EditStudentValidator : AbstractValidator<EditStudentCommand>
    {
        #region Fields
        private readonly IStudentServies _studentService;
        #endregion

        #region Constructors
        public EditStudentValidator(IStudentServies studentService)
        {
            _studentService = studentService;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        #endregion

        #region Handel Functions
        //for Rules in FluentValidation
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name must be not empty")
                .NotNull().WithMessage("Name must be not Null")
                .MaximumLength(100).WithMessage("Name must be Max lenght 10 ");


            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("{PropertyName} must be not empty")
                .NotNull().WithMessage("{PropertyValue} must be not Null")
                .MaximumLength(100).WithMessage("Name must be Max lenght 10 ");

        }


        //for Custom Rules in FluentValidation
        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.Name)
                .MustAsync(async (model, Key, CancellationToken) => !await _studentService.IsNameExistExcludeSelf(Key, model.Id))
                .WithMessage("Name is Exist");
        }

        #endregion

    }
}