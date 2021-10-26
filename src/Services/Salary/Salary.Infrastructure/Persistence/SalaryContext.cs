
using Microsoft.EntityFrameworkCore;
using Salary.Domain.Common;
using Salary.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Salary.Infrastructure.Persistence
{
    public class SalaryContext : DbContext
    {
        public SalaryContext(DbContextOptions<SalaryContext> options) : base(options)
        {

        }

        public DbSet<Salaryy> Salaries { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "System";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "System";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
