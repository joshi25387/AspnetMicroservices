using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Employee.Application.Features.Employees.Queries.GetEmployeesByDepartment
{
    public class GetEmployeesByDepartmentQuery : IRequest<List<EmployeeDTO>>
    {
        public string DepartmentName { get; set; }

        public GetEmployeesByDepartmentQuery(string departmentName)
        {
            DepartmentName = departmentName;
        }
    }
}
