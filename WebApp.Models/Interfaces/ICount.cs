using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.Models.Interfaces {
  public interface ICount {
    int CountTotal { get; set; }
    int CountSuccess { get; set; }
    int CountWarning { get; set; }
    int CountDanger { get; set; }
  }
}