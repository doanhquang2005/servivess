using HT.Extentions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PhoneBillingService.Model {

  [Table("BI_Files")]
  public class BI_File : Tracking {
    public int Type { get; set; }
    public int Count { get; set; }
    public string FileName { get; set; }
    public string Path { get; set; }
    public bool IsSuccess { get; set; }
  }
}