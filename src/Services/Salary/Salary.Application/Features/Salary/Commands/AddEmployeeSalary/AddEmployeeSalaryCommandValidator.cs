using FluentValidation;


namespace Salary.Application.Features.Salary.Commands.AddEmployee
{
    public class AddEmployeeSalaryCommandValidator : AbstractValidator<AddEmployeeSalaryCommand>
    {
        public AddEmployeeSalaryCommandValidator()
        {
            RuleFor(p => p.EmployeeCode)
                        .NotEmpty().WithMessage("{EmployeeCode} is required.")
                        .NotNull().WithMessage("{EmployeeCode} is required.")
                        .MaximumLength(20).WithMessage("{EmployeeCode must not exceed 20 characters}");

            RuleFor(p => p.BaseSalary)
                        .GreaterThan(0).WithMessage("{BaseSalary} is required.")
                        .NotNull().WithMessage("{BaseSalary} is required.");

            RuleFor(p => p.HRA)
                        .GreaterThan(0).WithMessage("{HRA} is required.")
                        .NotNull().WithMessage("{HRA} is required.");

            RuleFor(p => p.Medical)
                        .GreaterThan(0).WithMessage("{Medical} is required.")
                        .NotNull().WithMessage("{Medical} is required.");
        }
    }
}
