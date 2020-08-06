using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApp.Data.Entity.Billing {

  public partial class BillingDbContext : DbContext {
    public BillingDbContext() {
    }

    public BillingDbContext(DbContextOptions<BillingDbContext> options)
        : base(options) {
    }

    public virtual DbSet<BiCalls> BiCalls { get; set; }
    public virtual DbSet<BiDataAarenets> BiDataAarenets { get; set; }
    public virtual DbSet<BiDays> BiDays { get; set; }
    public virtual DbSet<BiFiles> BiFiles { get; set; }
    public virtual DbSet<BiGroups> BiGroups { get; set; }
    public virtual DbSet<BiLandlines> BiLandlines { get; set; }
    public virtual DbSet<BiMobiles> BiMobiles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      if(!optionsBuilder.IsConfigured) {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        optionsBuilder.UseSqlServer("Data Source=database.vntt.com.vn;Initial Catalog=VNTT_Billing_v2;Persist Security Info=True;User ID=namhh1;Password=namhh@vntt");
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      modelBuilder.Entity<BiCalls>(entity => {
        entity.ToTable("BI_Calls");

        entity.HasIndex(e => e.BiGroupId);

        entity.Property(e => e.Id).ValueGeneratedNever();

        entity.Property(e => e.AccNumber)
            .HasMaxLength(20)
            .IsUnicode(false);

        entity.Property(e => e.BiGroupId).HasColumnName("BI_GroupId");

        entity.Property(e => e.DestNumber)
            .HasMaxLength(20)
            .IsUnicode(false);

        entity.HasOne(d => d.BiGroup)
            .WithMany(p => p.BiCalls)
            .HasForeignKey(d => d.BiGroupId);
      });

      modelBuilder.Entity<BiDataAarenets>(entity => {
        entity.ToTable("BI_DataAarenets");

        entity.Property(e => e.Id).ValueGeneratedNever();

        entity.Property(e => e.AccAccountId).HasColumnName("AccAccountID");

        entity.Property(e => e.AccAddressId).HasColumnName("AccAddressID");

        entity.Property(e => e.AccTenantId).HasColumnName("AccTenantID");

        entity.Property(e => e.AlertMs).HasColumnName("AlertMS");

        entity.Property(e => e.CallEndMs).HasColumnName("CallEndMS");

        entity.Property(e => e.CallId).HasColumnName("CallID");

        entity.Property(e => e.CallStartMs).HasColumnName("CallStartMS");

        entity.Property(e => e.CdrId).HasColumnName("CdrID");

        entity.Property(e => e.DestAccId).HasColumnName("DestAccID");

        entity.Property(e => e.DestAddrId).HasColumnName("DestAddrID");

        entity.Property(e => e.DestIp).HasColumnName("DestIP");

        entity.Property(e => e.DestTenantId).HasColumnName("DestTenantID");

        entity.Property(e => e.OrigIp).HasColumnName("OrigIP");

        entity.Property(e => e.PricelistId).HasColumnName("PricelistID");

        entity.Property(e => e.Q850cause).HasColumnName("Q850Cause");

        entity.Property(e => e.SipcallId).HasColumnName("SIPCallID");
      });

      modelBuilder.Entity<BiDays>(entity => {
        entity.ToTable("BI_Days");

        entity.HasIndex(e => e.DayCount)
            .IsUnique();

        entity.Property(e => e.Id).ValueGeneratedNever();
      });

      modelBuilder.Entity<BiFiles>(entity => {
        entity.ToTable("BI_Files");

        entity.Property(e => e.Id).ValueGeneratedNever();
      });

      modelBuilder.Entity<BiGroups>(entity => {
        entity.ToTable("BI_Groups");

        entity.Property(e => e.Id).ValueGeneratedNever();
      });

      modelBuilder.Entity<BiLandlines>(entity => {
        entity.ToTable("BI_Landlines");

        entity.Property(e => e.Id).ValueGeneratedNever();
      });

      modelBuilder.Entity<BiMobiles>(entity => {
        entity.ToTable("BI_Mobiles");

        entity.Property(e => e.Id).ValueGeneratedNever();
      });

      OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
  }
}