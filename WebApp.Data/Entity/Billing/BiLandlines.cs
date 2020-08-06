using HT.Extentions;
using System;
using System.Collections.Generic;

namespace WebApp.Data.Entity.Billing {

  public partial class BiLandlines : Tracking {
    public string PrefixNew { get; set; }
    public string PrefixOld { get; set; }
    public string LandlineName { get; set; }
  }
}