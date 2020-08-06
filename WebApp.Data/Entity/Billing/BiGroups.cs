using HT.Extentions;
using System;
using System.Collections.Generic;

namespace WebApp.Data.Entity.Billing {

  public partial class BiGroups : Tracking {
    public BiGroups() {
      BiCalls = new HashSet<BiCalls>();
    }

    public string GroupName { get; set; }
    public int Priority { get; set; }
    public string Description { get; set; }
    public string Prefix { get; set; }
    public string Infix { get; set; }
    public int Sochar { get; set; }
    public int Minlen { get; set; }
    public int Maxlen { get; set; }
    public long? FromNumber { get; set; }
    public long? EndNumber { get; set; }
    public int? Duration1 { get; set; }
    public double? Price1 { get; set; }
    public int? Duration2 { get; set; }
    public double? Price2 { get; set; }
    public bool IsHot { get; set; }
    public int Type1 { get; set; }
    public string Type2 { get; set; }

    public virtual ICollection<BiCalls> BiCalls { get; set; }
  }
}