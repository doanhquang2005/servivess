using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PhoneBillingService.Data;
using PhoneBillingService.Service;

namespace PhoneBillingService {

  public class Program {
    public static void Main(string[] args) {
      CreateHostBuilder(args).Build().Run();
    }

    public static IConfigurationRoot Configuration { get; set; }
    public static IHostBuilder CreateHostBuilder(string[] args) {
      var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
      Configuration = builder.Build();
      return Host.CreateDefaultBuilder(args)
          .UseWindowsService().ConfigureServices((hostContext, services) => {
            services.AddDbContext<AppDbContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IBillingService, BillingService>();
            services.AddHostedService<Worker>();
          });
    }
  }
}