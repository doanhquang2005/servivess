using HT.Extentions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PhoneBillingService.Model {

  [Table("BI_DataAarenets")]
  public class BI_DataAarenet : Tracking {
    public long FileId { get; set; }
    public int FileType { get; set; }
    // Các trường mặc định lấy từ File
    public long CallStartMS { get; set; }
    public string CallStart { get; set; }
    public long CallEndMS { get; set; }
    public string CallEnd { get; set; }
    public double Duration { get; set; } // Thời gian gọi theo ms
    public string AccAccountID { get; set; }
    public string AccAddressID { get; set; }
    public string AccTenantID { get; set; }
    public string AccNumber { get; set; }
    public string AccTenant { get; set; } //10
    public string AccName { get; set; }
    public string AccAddress { get; set; }
    public string AccAddressPublic { get; set; }
    public string AccAddressCombined { get; set; }
    public string OrigNumber { get; set; }
    public string Destination { get; set; } // Destination
    public string DestNumber { get; set; }
    public string DestType { get; set; }
    public string DestTenant { get; set; }
    public string DestTenantID { get; set; } //20
    public string PricelistID { get; set; }
    public string PricelistTable { get; set; }
    public string PricelistVersion { get; set; } // +1
    public string Tariff { get; set; }
    public string PostRating { get; set; }
    public double ChargeAccount { get; set; }
    public double ChargeTenant { get; set; }
    public double ChargeSystem { get; set; }
    public string CallLeg { get; set; }
    public string OrigIP { get; set; } //30
    public string DestIP { get; set; }
    public string CdrID { get; set; }
    public string CallID { get; set; }
    public double AlertMS { get; set; }
    public double AlertSecond { get; set; }
    public string OrigGateway { get; set; }
    public string DestGateway { get; set; }
    public string PresPreferred { get; set; }
    public string PresAsserted { get; set; }
    public string Cause { get; set; } // 40
    public string Flags { get; set; }
    public string Scope { get; set; }
    public string AccNumberPrivate { get; set; }
    public string CallType { get; set; }
    public string BillingInfo { get; set; }
    public string SIPCallID { get; set; }
    public string Q850Cause { get; set; }
    public string DestAccID { get; set; }
    public string DestAccName { get; set; }
    public string DestAddrID { get; set; } //50
    public string DestAddrNumber { get; set; }
    public string OutboundDest { get; set; }
  }
}