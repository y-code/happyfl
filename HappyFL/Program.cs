using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;

namespace HappyFL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
                configBuilder.AddJsonFile("appsettings.Development.json", false);

            CreateWebHostBuilder(args)
                .UseConfiguration(configBuilder.Build())
                .Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
				.UseSerilog((webHostBuilderContext, loggerConfiguration) =>
				{
					loggerConfiguration
						.ReadFrom.Configuration(webHostBuilderContext.Configuration);
				});
    }
}