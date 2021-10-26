using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salary.Application.Features.Salary.Queries.GetSalaryByEmployeeCode
{
    public class SalaryDTO
    {
        public int Id { get; set; }
        public string EmployeeCode { get; set; }
        public decimal BaseSalary { get; set; }
        public decimal HRA { get; set; }
        public decimal Medical { get; set; }
    }
}
