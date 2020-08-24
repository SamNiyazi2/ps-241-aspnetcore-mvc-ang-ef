using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ps_DutchTreat
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>

            // 08/24/2020 02:27 pm - SSN - [20200824-1416] - [002] - M07-04 - Using configuration
            // AppConfig.json is the default file.
            // Adding ConfigureAppConfiguration to customize.

            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(setupConfiguration)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void setupConfiguration(HostBuilderContext ctx, IConfigurationBuilder builder)
        {
            builder.Sources.Clear();
            // Order matters.  Last entry wins.
            builder.AddJsonFile("config_20200824.json", false, true)
                .AddXmlFile("Config_20200824.xml", true)
                .AddEnvironmentVariables();
        }
    }
}
