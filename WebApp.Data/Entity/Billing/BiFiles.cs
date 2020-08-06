using HT.Extentions;
using System;
using System.Collections.Generic;

namespace WebApp.Data.Entity.Billing {

  public partial class BiFiles : Tracking {
    public int FileType { get; set; }
    public string FileName { get; set; }
    public int RowCount { get; set; }
    public string Path { get; set; }
    public bool IsSuccess { get; set; }
  }
}