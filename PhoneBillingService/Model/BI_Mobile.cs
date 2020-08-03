using HT.Extentions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PhoneBillingService.Model {

  [Table("BI_Mobiles")]
  public class BI_Mobile : Tracking {
    public string PrefixNew { get; set; }
    public string PrefixOld { get; set; }
    public string MobileName { get; set; }
  }
}