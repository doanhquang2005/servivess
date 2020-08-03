using HT.Extentions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PhoneBillingService.Model {

  [Table("BI_Landlines")]
  public class BI_Landline : Tracking {
    public string PrefixNew { get; set; }
    public string PrefixOld { get; set; }
    public string LandlineName { get; set; }
  }
}