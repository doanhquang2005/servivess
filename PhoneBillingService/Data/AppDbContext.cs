using HT.Extentions;
using HT.Extentions.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PhoneBillingService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneBillingService.Data {

  public class AppDbContext : DbContext {
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) {
    }

    public DbSet<BI_File> Files { get; set; }
    public DbSet<BI_Record> Records { get; set; }
    public DbSet<BI_DataAarenet> DataAarenets { get; set; }
    public virtual DbSet<BI_Group> Groups { get; set; }
    public DbSet<BI_Mobile> Mobiles { get; set; }
    public DbSet<BI_Landline> Landlines { get; set; }
    public DbSet<BI_Day> Days { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      modelBuilder.Entity<BI_Day>().HasIndex(d => d.DayCount).IsUnique();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      base.OnConfiguring(optionsBuilder);
    }

    public override int SaveChanges() {
      var modified = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);
      foreach(EntityEntry item in modified)
        TrackingEntry(item);
      return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) {
      var modified = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);
      foreach(EntityEntry item in modified)
        TrackingEntry(item);
      return await base.SaveChangesAsync();
    }

    private void TrackingEntry(EntityEntry item) {
      long userId = 0;
      if(item.Entity is Tracking tracking) {
        if(tracking.Id == 0)
          tracking.Id = GenerateId.NewLong();
        if(item.State == EntityState.Added) {
          tracking.DateCreated = DateTime.Now;
          tracking.UserCreated = userId;
        } else {
          base.Entry(tracking).Property(x => x.UserCreated).IsModified = false;
          base.Entry(tracking).Property(x => x.DateCreated).IsModified = false;
        }
        if(tracking.Status == Status.Default)
          tracking.Status = Status.Acppect;
        tracking.DateUpdated = DateTime.Now;
        tracking.UserUpdated = userId;
      }
    }
  }
}