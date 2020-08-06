//using HT.VNTT.TagHelpers;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Threading.Tasks;
//using WebApp.Data.Interfaces;
//using WebApp.Models;

//namespace WebApp.Data.Models {
//  [Table("Categories")]
//  public class Category : DomainEntity, ITracking<Guid>, ISEO {
//    [MaxLength(127)]
//    [Column(TypeName = "varchar(127)")]
//    public string Url { get; set; }
//    public string CategoryName { get; set; }
//    public string Description { get; set; }
//    public string Content { get; set; }
//    public int Type { get; set; }
//    public Guid? ParentId { get; set; }
//    public Guid UserCreated { get; set; }
//    public Guid UserUpdated { get; set; }
//    public DateTime DateCreated { get; set; }
//    public DateTime DateUpdated { get; set; }
//    public Status Status { get; set; }
//    public string metaTitle { get; set; }
//    public string metaDescription { get; set; }
//    public string metaKeywords { get; set; }
//    public List<Topic> Topics { get; set; }
//  }
//}