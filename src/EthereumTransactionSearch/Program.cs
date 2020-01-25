using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Extensions.Logging;
using Serilog.Formatting.Json;
using Serilog.Sinks.RollingFileAlternate;
using System.Net;

namespace EthereumTransactionSearch
{
    public class Program
    {
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseStartup<Startup>()
                        .ConfigureAppConfiguration(
                            (hostingContext, config) => config
                                .AddEnvironmentVariables("EthereumTransactionSearch_")
                                .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true)
                                .AddCommandLine(args))
                        .ConfigureLogging((hostingContext, logging) =>
                            logging.AddProvider(CreateLoggerProvider(hostingContext.Configuration)));
                });

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static SerilogLoggerProvider CreateLoggerProvider(IConfiguration configuration)
        {
            LoggerConfiguration logConfig = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("System", LogEventLevel.Warning)
                .WriteTo.RollingFileAlternate(new JsonFormatter(), "./logs", fileSizeLimitBytes: 100000000, retainedFileCountLimit: 30)
                .ReadFrom.Configuration(configuration)
                .Enrich.WithProperty("Hostname", Dns.GetHostName());

            return new SerilogLoggerProvider(logConfig.CreateLogger());
        }
    }
}