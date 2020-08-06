using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Hubs {
  public interface IBillHub {
    Task ReceiveCreateEdit(string billId); // Error if long

    Task ReceiveDelete(string billId); // Error if long
  }
}