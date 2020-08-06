//using HT.NTagHelpers.Enum;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Threading.Tasks;
//using WebApp.Data.Interfaces;
//using WebApp.Models;

//namespace WebApp.Data.Models {
//  [Table("Comments")]
//  public class Comment : DomainEntity, IRate, ITracking<Guid> {
//    public Guid TopicId { get; set; }
//    public string Content { get; set; }
//    public bool IsAnonymous { get; set; }
//    public int RateCount { get; set; }
//    public double RateValue { get; set; }
//    public Guid UserCreated { get; set; }
//    public Guid UserUpdated { get; set; }
//    public DateTime DateCreated { get; set; }
//    public DateTime DateUpdated { get; set; }
//    public Status Status { get; set; }
//    public Guid? SourceId { get; set; }
//  }
//}