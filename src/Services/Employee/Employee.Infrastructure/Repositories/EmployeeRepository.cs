using Employee.Application.Contracts.Persistence;
using Employee.Domain.Entities;
using Employee.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Infrastructure.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employeee>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeeContext dbContext) : base(dbContext)
        {
            
        }
        public async Task<IEnumerable<Employeee>> GetEmployeeByDepartment(string departmentName)
        {
            var employeeList = await _dbContext.Employees.Where(o => o.Department == departmentName).ToListAsync();
            return employeeList;
        }
    }
}
