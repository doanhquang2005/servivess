//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Threading.Tasks;
//using WebApp.Data.Enums;
//using WebApp.Data.Interfaces;
//using WebApp.Models;

//namespace WebApp.Data.Models {
//  [Table("Topics")]
//  public class Topic : DomainEntity, ISEO, IRate, ITracking<Guid> {
//    [MaxLength(127)]
//    [Column(TypeName = "varchar(127)")]
//    public string Url { get; set; }
//    public Guid CategoryId { get; set; }
//    public string TopicName { get; set; }
//    public string Description { get; set; }
//    public string Image { get; set; }
//    public string Content { get; set; }
//    public bool IsAnonymous { get; set; }
//    public int Type { get; set; }
//    public int Mark { get; set; }
//    public int RateCount { get; set; }
//    public double RateValue { get; set; }
//    public string metaTitle { get; set; }
//    public string metaDescription { get; set; }
//    public string metaKeywords { get; set; }
//    public virtual Category Category { get; set; }
//    public DateTime DateCreated { get; set; }
//    public DateTime DateUpdated { get; set; }
//    public Status Status { get; set; }
//    public Guid UserCreated { get; set; }
//    public Guid UserUpdated { get; set; }
//    Status ITracking<Guid>.Status { get; set; }
//    public List<Comment> Comments { get; set; }
//  }
//}