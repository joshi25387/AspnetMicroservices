using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.Features.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
    {
        public UpdateEmployeeCommandValidator()
        {
            RuleFor(p => p.EmployeeCode)
                        .NotEmpty().WithMessage("{EmployeeCode} is required.")
                        .NotNull().WithMessage("{EmployeeCode} is required.")
                        .MaximumLength(20).WithMessage("{EmployeeCode must not exceed 20 characters}");

            RuleFor(p => p.Name)
                        .NotEmpty().WithMessage("{Name} is required.")
                        .NotNull().WithMessage("{Name} is required.");

            RuleFor(p => p.Address)
                        .NotEmpty().WithMessage("{Address} is required.")
                        .NotNull().WithMessage("{Address} is required.");

            RuleFor(p => p.Department)
                        .NotEmpty().WithMessage("{Department} is required.")
                        .NotNull().WithMessage("{Department} is required.");
        }
    }
}
