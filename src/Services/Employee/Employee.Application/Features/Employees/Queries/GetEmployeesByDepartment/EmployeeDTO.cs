using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.Features.Employees.Queries.GetEmployeesByDepartment
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string EmployeeCode { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Qualification { get; set; }
        public string Department { get; set; }
    }
}
