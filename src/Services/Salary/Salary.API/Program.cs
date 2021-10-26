using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Salary.API.Extensions;
using Salary.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Salary.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.MigrateDatabase<SalaryContext>(
                (context, services) => {
                    var logger = services.GetService<ILogger<SalaryContextSeed>>();
                    SalaryContextSeed.SeedAsync(context, logger).Wait();
                });
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
