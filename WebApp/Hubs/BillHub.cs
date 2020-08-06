using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Hubs {

  public class BillHub : Hub<IBillHub> {
    public async Task SendCreateEdit(string billId) {
      await Clients.All.ReceiveCreateEdit(billId);
    }

    public async Task SendDelete(string billId) {
      await Clients.All.ReceiveDelete(billId);
    }
  }
}