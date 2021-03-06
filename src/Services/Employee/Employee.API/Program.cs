using Employee.API.Extensions;
using Employee.Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.MigrateDatabase<EmployeeContext>(
                (context, services) => {
                    var logger = services.GetService<ILogger<EmployeeContextSeed>>();
                    EmployeeContextSeed.SeedAsync(context, logger).Wait();
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
