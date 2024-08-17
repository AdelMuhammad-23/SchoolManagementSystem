using FluentValidation;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Servies.Abstructs;

namespace SchoolProject.Core.Features.Students.Commands.Validatiors
{
    public class AddStudentValidators : AbstractValidator<AddStudentCommand>
    {
        #region Fields
        private readonly IStudentServies _studentServies;
        #endregion


        #region Constructors
        public AddStudentValidators(IStudentServies studentServies)
        {
            _studentServies = studentServies;
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
                .MaximumLength(10).WithMessage("Name must be Max lenght 10 ");


            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("{PropertyName}Name must be not empty")
                .NotNull().WithMessage("{PropertyValue}Name must be not Null")
                .MaximumLength(10).WithMessage("Name must be Max lenght 10 ");

        }


        //for Custom Rules in FluentValidation
        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.Name)
                .MustAsync(async (Key, CancellationToken) => !await _studentServies.IsNameExist(Key))
                .WithMessage("Name is Exist");
        }

        #endregion

    }
}
