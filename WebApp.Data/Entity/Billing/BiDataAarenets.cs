using System;
using System.Collections.Generic;

namespace WebApp.Data.Entity.Billing
{
    public partial class BiDataAarenets
    {
        public long Id { get; set; }
        public long UserCreated { get; set; }
        public long UserUpdated { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public int Status { get; set; }
        public long? SourceId { get; set; }
        public long FileId { get; set; }
        public int FileType { get; set; }
        public long CallStartMs { get; set; }
        public string CallStart { get; set; }
        public long CallEndMs { get; set; }
        public string CallEnd { get; set; }
        public double Duration { get; set; }
        public string AccAccountId { get; set; }
        public string AccAddressId { get; set; }
        public string AccTenantId { get; set; }
        public string AccNumber { get; set; }
        public string AccTenant { get; set; }
        public string AccName { get; set; }
        public string AccAddress { get; set; }
        public string AccAddressPublic { get; set; }
        public string AccAddressCombined { get; set; }
        public string OrigNumber { get; set; }
        public string Destination { get; set; }
        public string DestNumber { get; set; }
        public string DestType { get; set; }
        public string DestTenant { get; set; }
        public string DestTenantId { get; set; }
        public string PricelistId { get; set; }
        public string PricelistTable { get; set; }
        public string PricelistVersion { get; set; }
        public string Tariff { get; set; }
        public string PostRating { get; set; }
        public double ChargeAccount { get; set; }
        public double ChargeTenant { get; set; }
        public double ChargeSystem { get; set; }
        public string CallLeg { get; set; }
        public string OrigIp { get; set; }
        public string DestIp { get; set; }
        public string CdrId { get; set; }
        public string CallId { get; set; }
        public double AlertMs { get; set; }
        public double AlertSecond { get; set; }
        public string OrigGateway { get; set; }
        public string DestGateway { get; set; }
        public string PresPreferred { get; set; }
        public string PresAsserted { get; set; }
        public string Cause { get; set; }
        public string Flags { get; set; }
        public string Scope { get; set; }
        public string AccNumberPrivate { get; set; }
        public string CallType { get; set; }
        public string BillingInfo { get; set; }
        public string SipcallId { get; set; }
        public string Q850cause { get; set; }
        public string DestAccId { get; set; }
        public string DestAccName { get; set; }
        public string DestAddrId { get; set; }
        public string DestAddrNumber { get; set; }
        public string OutboundDest { get; set; }
    }
}
