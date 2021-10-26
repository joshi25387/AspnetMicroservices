using Employee.Domain.Common;

namespace Employee.Domain.Entities
{
    public class Employeee : EntityBase
    {
        public string EmployeeCode { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Qualification { get; set; }
        public string Department { get; set; }
    }
}
