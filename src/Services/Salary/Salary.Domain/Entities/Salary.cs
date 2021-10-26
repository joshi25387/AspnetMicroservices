using Salary.Domain.Common;

namespace Salary.Domain.Entities
{
    public class Salaryy : EntityBase
    {
        public string EmployeeCode { get; set; }
        public decimal BaseSalary { get; set; }
        public decimal HRA { get; set; }
        public decimal Medical { get; set; }
    }
}
