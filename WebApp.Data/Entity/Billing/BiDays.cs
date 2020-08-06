using HT.Extentions;
using System;
using System.Collections.Generic;

namespace WebApp.Data.Entity.Billing {

  public partial class BiDays : Tracking {
    public int DayCount { get; set; }
    public DateTime DateTime { get; set; }
    public string DayName { get; set; }
  }
}