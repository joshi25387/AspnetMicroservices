using Employee.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee.Application.Contracts.Persistence
{
    public interface IEmployeeRepository : IAsyncRepository<Employeee>
    {
        Task<IEnumerable<Employeee>> GetEmployeeByDepartment(string DepartmentName);
    }
}
