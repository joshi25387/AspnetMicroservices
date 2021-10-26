
using Microsoft.EntityFrameworkCore;
using Salary.Application.Contracts.Persistence;
using Salary.Domain.Entities;
using Salary.Infrastructure.Persistence;
using System.Linq;
using System.Threading.Tasks;

namespace Salary.Infrastructure.Repositories
{
    public class SalaryRepository : RepositoryBase<Salaryy>, ISalaryRepository
    {
        public SalaryRepository(SalaryContext dbContext) : base(dbContext)
        {
            
        }
        public async Task<Salaryy> GetSalaryByEmployeeCode(string employeeCode)
        {
            var employeeSalary = await _dbContext.Salaries.Where(o => o.EmployeeCode == employeeCode).FirstOrDefaultAsync();
            return employeeSalary;
        }
    }
}
