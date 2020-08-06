using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace WebApp.Data.DBContext {

  class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext> {
    private readonly IHttpContextAccessor _httpContextAccessor;
    public AppDbContextFactory() {
    }

    public AppDbContextFactory(IHttpContextAccessor httpContextAccessor) => _httpContextAccessor = httpContextAccessor;

    public AppDbContext CreateDbContext(string[] args) {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
      var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
      optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
      return new AppDbContext(optionsBuilder.Options, _httpContextAccessor);
    }
  }
}