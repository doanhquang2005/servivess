//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using WebApp.Models.Entities;

//namespace WebApp.Data.Configurations {
//  public class CM_CommonConfiguration : IEntityTypeConfiguration<CM_Common> {
//    public void Configure(EntityTypeBuilder<CM_Common> builder) {
//      builder.ToTable("CM_Commons");
//      builder.HasKey(x => x.Id);
//      builder.Property(x => x.Code).IsUnicode(false).HasMaxLength(15);
//      builder.Property(x => x.Name).HasMaxLength(127);
//      builder.Property(x => x.Description).HasMaxLength(255);
//      builder.Property(x => x.LevelName).HasMaxLength(63);
//      builder.Property(x => x.ParentCode).IsUnicode(false).HasMaxLength(15);
//    }
//  }
//}