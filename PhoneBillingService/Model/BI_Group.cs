using HT.Extentions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PhoneBillingService.Model {

  [Table("BI_Groups")]
  public class BI_Group : Tracking, IPrice {
    public string GroupName { get; set; }
    public int Priority { get; set; }
    public string Description { get; set; } // Mô tả thêm gói cước
    public string Prefix { get; set; }
    public string Infix { get; set; }
    public int Sochar { get; set; }
    public int Minlen { get; set; }
    public int Maxlen { get; set; }
    public long? FromNumber { get; set; }
    public long? EndNumber { get; set; }
    public virtual List<BI_Record> Records { get; set; }
    public int? Duration1 { get; set; }
    public double? Price1 { get; set; }
    public int? Duration2 { get; set; }
    public double? Price2 { get; set; }
    public bool IsHot { get; set; } // Xét giờ cao điểm
    public int Type1 { get; set; }
    public string Type2 { get; set; }
  }
}