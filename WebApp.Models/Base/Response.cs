using System;
using System.Collections.Generic;
using System.Text;
using WebApp.Models.Helpers;

namespace WebApp.Models.Base {

  public class Response {
    public int Status { get; set; } = Notify.warning;
    public string Message { get; set; } = Notify.useSuccess;
    public bool IsValid => Status == Notify.success;
  }
}