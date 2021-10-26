using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.Features.Employees.Commands.AddEmployee
{
    public class AddEmployeeCommand : IRequest<int>
    {
        public string EmployeeCode { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Qualification { get; set; }
        public string Department { get; set; }
    }
}
