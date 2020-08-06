using HT.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebApp.Data.Entity.Billing {

  public partial class BillingDbContext : DbContext {
    private readonly IHttpContextAccessor _httpContextAccessor;
    public BillingDbContext(DbContextOptions<BillingDbContext> options, IHttpContextAccessor httpContextAccessor)
        : base(options) {
      _httpContextAccessor = httpContextAccessor;
    }

    public override int SaveChanges() {
      var modified = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);
      string user = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      long.TryParse(user, out long userId);
      foreach(EntityEntry item in modified)
        this.TrackingEntity(item, userId);
      return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) {
      var modified = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);
      string user = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      long.TryParse(user, out long userId);
      foreach(EntityEntry item in modified)
        this.TrackingEntity(item, userId);
      return await base.SaveChangesAsync();
    }
  }
}