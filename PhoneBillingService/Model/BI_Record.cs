using HT.Extentions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PhoneBillingService.Model {

  [Table("BI_Records")]
  public class BI_Record : Tracking, IPrice {
    public string RecordName { get; set; }
    public long FileId { get; set; }
    public int FileType { get; set; }
    public double Duration { get; set; }
    [Column(TypeName = "varchar(20)")]
    public string DestNumber { get; set; }
    [Column(TypeName = "varchar(20)")]
    public string AccNumber { get; set; }
    public long? GroupId { get; set; }
    public double? Price { get; set; }
    public double? PriceOld { get; set; }
    public double? PricePartner { get; set; }
    public string DestNumberGroup { get; set; }
    public string DestNumberOld { get; set; }
    public int? Duration1 { get; set; }
    public double? Price1 { get; set; }
    public int? Duration2 { get; set; }
    public double? Price2 { get; set; }
    public int MonthCount { get; set; } // Year * 12 + Month
    public int DayCount { get; set; } // (Year * 12 + Month) * 31 + Day
    public int Type1 { get; set; }
    public string Type2 { get; set; }
    public bool IsLock { get; set; } // Không cho phép thay đổi
    public bool IsAddBill { get; set; }
  }
}