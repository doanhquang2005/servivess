using HT.Extentions;
using System;
using System.Collections.Generic;

namespace WebApp.Data.Entity.Billing {

  public partial class BiCalls : Tracking {
    public string RecordName { get; set; }
    public DateTime DateCalled { get; set; }
    public long FileId { get; set; }
    public int FileType { get; set; }
    public double Duration { get; set; }
    public string DestNumber { get; set; }
    public string DestNumberGroup { get; set; }
    public string DestNumberOld { get; set; }
    public string AccNumber { get; set; }
    public long? GroupId { get; set; }
    public double? Price { get; set; }
    public double? PriceOld { get; set; }
    public double? PricePartner { get; set; }
    public int? Duration1 { get; set; }
    public double? Price1 { get; set; }
    public int? Duration2 { get; set; }
    public double? Price2 { get; set; }
    public int MonthCount { get; set; }
    public int DayCount { get; set; }
    public int Type1 { get; set; }
    public string Type2 { get; set; }
    public bool IsAddBill { get; set; }
    public bool IsProcess { get; set; }
    public long? BiGroupId { get; set; }

    public virtual BiGroups BiGroup { get; set; }
  }
}