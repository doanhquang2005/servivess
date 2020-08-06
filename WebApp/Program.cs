using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace WebApp {

  public class Program {
    public static void Main(string[] args) {
      var host = CreateHostBuilder(args).Build();
      using var scope = host.Services.CreateScope();
      var services = scope.ServiceProvider;
      try {
        //var dbIntializer = services.GetService<USInitializer>();
        //dbIntializer.Seed().Wait();
      } catch(Exception ex) {
        var logger = services.GetService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the datebase");
      }
      host.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => {
              webBuilder.UseStartup<Startup>();
            });
  }
}