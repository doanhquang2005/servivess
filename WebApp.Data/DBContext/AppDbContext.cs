using HT.Extentions;
using HT.Extentions.Enums;
using HT.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using WebApp.Models.Base;
using WebApp.Models.Entities;
using WebApp.Models.Interfaces;

namespace WebApp.Data.DBContext {

  public class AppDbContext : DbContext {
    private readonly IHttpContextAccessor _httpContextAccessor;
    public AppDbContext(DbContextOptions<AppDbContext> options, IHttpContextAccessor httpContextAccessor)
        : base(options) {
      _httpContextAccessor = httpContextAccessor;
    }

    public DbSet<ED_Class> Classes { get; set; }
    public DbSet<CM_Permission> Permissions { get; set; }
    public DbSet<CM_Active> Actives { get; set; }
    public DbSet<CM_Image> Images { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder builder) {
      builder.Entity<CM_Image>().HasIndex(u => u.Path).IsUnique(true);
      //builder.Entity<AA_BillDetail>().Property(x => x.Id).ValueGeneratedOnAdd();

      //builder.Entity<AA_StaffInStores>().HasKey(c => new { c.StaffId, c.StoreId });

      // Add configuration
      //builder.ApplyConfiguration(new CM_CommonConfiguration());

      //Tạo các Bảng Identity mặc định
      //base.OnModelCreating(builder);
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

    //private void TrackingEntry(EntityEntry item) {
    //  string user = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    //  long userId = user == null ? 0 : long.Parse(user);
    //  if(item.Entity is Tracking tracking) {
    //    if(tracking.Id == 0)
    //      tracking.Id = GenerateId.NewLong();
    //    if(item.State == EntityState.Added) {
    //      tracking.DateCreated = DateTime.Now;
    //      tracking.UserCreated = userId;
    //    } else {
    //      base.Entry(tracking).Property(x => x.UserCreated).IsModified = false;
    //      base.Entry(tracking).Property(x => x.DateCreated).IsModified = false;
    //    }
    //    if(tracking.Status == Status.Default)
    //      tracking.Status = Status.Acppect;
    //    tracking.DateUpdated = DateTime.Now;
    //    tracking.UserUpdated = userId;
    //  } else if(item.Entity is DetailTracking detailTracking) {
    //    if(item.State == EntityState.Added) {
    //      detailTracking.DateCreated = DateTime.Now;
    //      detailTracking.UserCreated = userId;
    //    } else {
    //      base.Entry(detailTracking).Property(x => x.DateCreated).IsModified = false;
    //      base.Entry(detailTracking).Property(x => x.UserCreated).IsModified = false;
    //    }
    //    if(detailTracking.Status == Status.Default)
    //      detailTracking.Status = Status.Acppect;
    //    detailTracking.DateUpdated = DateTime.Now;
    //    detailTracking.UserUpdated = userId;
    //  } else if(item.Entity is ITracking<long> itracking) {
    //    if(item.State == EntityState.Added) {
    //      if(itracking.Id == 0)
    //        itracking.Id = GenerateId.NewLong();
    //      itracking.DateCreated = DateTime.Now;
    //      itracking.UserCreated = userId;
    //    } else {
    //      base.Entry(itracking).Property(x => x.UserCreated).IsModified = false;
    //      base.Entry(itracking).Property(x => x.DateCreated).IsModified = false;
    //    }
    //    if(itracking.Status == Status.Default)
    //      itracking.Status = Status.Acppect;
    //    itracking.DateUpdated = DateTime.Now;
    //    itracking.UserUpdated = userId;
    //  }
    //}
  }
}