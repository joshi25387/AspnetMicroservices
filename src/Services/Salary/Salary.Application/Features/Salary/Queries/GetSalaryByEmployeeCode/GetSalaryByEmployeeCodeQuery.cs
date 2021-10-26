using System.Collections.Generic;
using MediatR;
using Salary.Application.Features.Salary.Queries.GetSalaryByEmployeeCode;

namespace Salary.Application.Features.Salary.Queries.GetEmployeesByDepartment
{
    public class GetSalaryByEmployeeCodeQuery : IRequest<SalaryDTO>
    {
        public string EmployeeCode { get; set; }

        public GetSalaryByEmployeeCodeQuery(string employeeCode)
        {
            EmployeeCode = employeeCode;
        }
    }
}
