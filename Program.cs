using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ps_DutchTreat.Data;
using Microsoft.Extensions.DependencyInjection;

namespace ps_DutchTreat
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            RunSeeding(host);

            host.Run();

        }

        // 08/25/2020 07:23 am - SSN - [20200825-0651] - [002] - M07-06 - Seeding the database 
        private static void RunSeeding(IHost host)
        {
            var scopeFactory = host.Services.GetService<IServiceScopeFactory>();

            using var scope = scopeFactory.CreateScope();

            // using Microsoft.Extensions.DependencyInjection;
            // var seeder = host.Services.GetService<DutchSeeder>();
            var seeder = scope.ServiceProvider.GetService<DutchSeeder>();
            seeder.SeedAsync().Wait();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>

            // 08/24/2020 02:27 pm - SSN - [20200824-1416] - [002] - M07-04 - Using configuration
            // AppConfig.json is the default file.
            // Adding ConfigureAppConfiguration to customize.

            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(SetupConfiguration)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void SetupConfiguration(HostBuilderContext ctx, IConfigurationBuilder builder)
        {
            builder.Sources.Clear();
            // Order matters.  Last entry wins.
            builder.AddJsonFile("config_20200824.json", false, true)
                .AddXmlFile("Config_20200824.xml", true)
                .AddEnvironmentVariables();
        }
    }
}
