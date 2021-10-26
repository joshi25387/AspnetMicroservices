using Salary.Domain.Entities;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salary.Infrastructure.Persistence
{
    public class SalaryContextSeed
    {
        public static async Task SeedAsync(SalaryContext salaryContext, ILogger<SalaryContextSeed> logger)
        {
            if (!salaryContext.Salaries.Any())
            {
                salaryContext.Salaries.AddRange(GetEmployeesSalarySeedData());
                await salaryContext.SaveChangesAsync();
                logger.LogInformation("Inserted seeded data into the database");
            }
        }

        private static IEnumerable<Salaryy> GetEmployeesSalarySeedData()
        {
            return new List<Salaryy>
            {
                new Salaryy()
                { 
                    EmployeeCode = "EMP001",
                    BaseSalary = 25000,
                    HRA = 10000,
                    Medical = 5000   
                }
            };
        }
    }
}
