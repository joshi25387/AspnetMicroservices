using MediatR;

namespace Salary.Application.Features.Salary.Commands.AddEmployee
{
    public class AddEmployeeSalaryCommand : IRequest<int>
    {
        public string EmployeeCode { get; set; }
        public decimal BaseSalary { get; set; }
        public decimal HRA { get; set; }
        public decimal Medical { get; set; }
    }
}
