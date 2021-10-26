
using Salary.Application.Contracts.Persistence;
using Salary.Infrastructure.Persistence;
using Salary.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Salary.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SalaryContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("EmployeeSalaryConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<ISalaryRepository, SalaryRepository>();

            return services;
        }
    }
}
