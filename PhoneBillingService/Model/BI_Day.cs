using HT.Extentions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PhoneBillingService.Model {

  [Table("BI_Days")]
  public class BI_Day : Tracking {
    public int DayCount { get; set; }
    public DateTime DateTime { get; set; }
    public string DayName { get; set; }
  }
}