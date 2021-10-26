using MediatR;

namespace Salary.Application.Features.Salary.Commands.UpdateEmployee
{
    public class UpdateEmployeeSalaryCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string EmployeeCode { get; set; }
        public decimal BaseSalary { get; set; }
        public decimal HRA { get; set; }
        public decimal Medical { get; set; }
    }
}
