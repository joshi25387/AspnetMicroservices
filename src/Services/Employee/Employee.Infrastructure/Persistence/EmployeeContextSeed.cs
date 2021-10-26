using Employee.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Infrastructure.Persistence
{
    public class EmployeeContextSeed
    {
        public static async Task SeedAsync(EmployeeContext employeeContext, ILogger<EmployeeContextSeed> logger)
        {
            if (!employeeContext.Employees.Any())
            {
                employeeContext.Employees.AddRange(GetEmployeesSeedData());
                await employeeContext.SaveChangesAsync();
                logger.LogInformation("Inserted seeded data into the database");
            }
        }

        private static IEnumerable<Employeee> GetEmployeesSeedData()
        {
            return new List<Employeee>
            {
                new Employeee()
                { 
                    EmployeeCode = "EMP001",
                    Name = "Suresh Kumar", 
                    Address = "New Delhi", 
                    Department = "IT",
                    Qualification = "MCA"                   
                }
            };
        }
    }
}
