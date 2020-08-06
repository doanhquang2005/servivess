using HT.Extentions;
using HT.Extentions.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Models.Interfaces;

namespace WebApp.Models.Base {

  [Table("US_Roles")]
  public class US_Role : IdentityRole<long> {
  }

  [Table("US_Users")]
  public class US_User : IdentityUser<long>, ITracking<long> {
    [StringLength(127)]
    [Display(Name = "Họ và tên")]
    public string FullName { get; set; }
    [Display(Name = "Hình đại diện")]
    public string Avatar { get; set; }
    [Display(Name = "Ngày sinh")]
    public DateTime Birthday { get; set; }
    [Display(Name = "Nam")]
    public bool IsMale { get; set; }
    public long UserCreated { get; set; }
    public long UserUpdated { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }
    public Status Status { get; set; }
    public long? SourceId { get; set; }
  }
}