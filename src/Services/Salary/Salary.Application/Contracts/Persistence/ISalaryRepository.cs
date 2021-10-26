
using Salary.Application.Contracts.Persistence;
using Salary.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Salary.Application.Contracts.Persistence
{
    public interface ISalaryRepository : IAsyncRepository<Salaryy>
    {
        Task<Salaryy> GetSalaryByEmployeeCode(string employeeCode);
    }
}
