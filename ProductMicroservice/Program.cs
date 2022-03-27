using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ProductMicroservice.Logging;
using Serilog;

namespace ProductMicroservice
{
  public class Program
  {
    public static void Main(string[] args)
    {
      string? environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
      string appSettingFile = string.IsNullOrEmpty(environment)?$"appsettings.json" : $"{Directory.GetCurrentDirectory()}/appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json";
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile(appSettingFile).Build();
      ConfigureLogging(configuration);
      Log.Information("Application starting");
      CreateWebHostBuilder(args,configuration).Build().Run();
    }

    private static void ConfigureLogging(IConfigurationRoot configuration)
    {
      
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
            Pms.Core.Logging.Log.Construct(new SerilogLogger(Log.Logger));
            
    }

    public static IWebHostBuilder CreateWebHostBuilder(string[] args,IConfigurationRoot configuration)
      {
        return WebHost.CreateDefaultBuilder(args)
        .UseConfiguration(configuration)
            .UseStartup<Startup>();
      }
  }
}
