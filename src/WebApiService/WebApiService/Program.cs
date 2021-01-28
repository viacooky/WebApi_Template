using System;
using System.IO;
using DoItLess.AspNetCore.Kit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;

namespace WebApiService
{
    public class Program
    {
        // ��־Ŀ¼
        private static readonly string LogFilePath = $"{Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs")}/.log";

        // ��־���ģ��
        private static readonly string OutputTemplate = "[{Level:u3} {Timestamp:HH:mm:ss.fff}]  {SourceContext:l}{Message:lj}{NewLine}{Exception}";

        public static IConfiguration Configuration = new ConfigurationBuilder()
                                                    .SetBasePath(Directory.GetCurrentDirectory())
                                                    .AddJsonFile("appsettings.json", false, true)
                                                    .AddEnvironmentVariables()
                                                    .Build();


        public static void Main(string[] args)
        {
            var loggerConfiguration = new LoggerConfiguration();
            SetLoggerConfiguration(loggerConfiguration);
            Log.Logger = loggerConfiguration.CreateLogger();

            try
            {
                Log.Information("Web Host ����...");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Web Host �����쳣");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder2(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                       .UseSwagger(options =>
                        {
                            options.SwaggerUiPath = "";
                        });
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                       .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); })
                       .UseSerilog((context, loggerConfiguration) => { SetLoggerConfiguration(loggerConfiguration); });
        }

        private static void SetLoggerConfiguration(LoggerConfiguration configuration)
        {
            configuration.ReadFrom.Configuration(Configuration)
                         .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                         .Enrich.FromLogContext()
                         .WriteTo.Console(outputTemplate: OutputTemplate)
                         .WriteTo.File(new CompactJsonFormatter(),
                                       path: LogFilePath,
                                       fileSizeLimitBytes: 1_000_000,
                                       rollOnFileSizeLimit: true,
                                       rollingInterval: RollingInterval.Day,
                                       shared: true,
                                       flushToDiskInterval: TimeSpan.FromSeconds(3));
        }
    }
}