using System;

namespace WebApp.Models.Resquests {

  public class CM_PermissionRequest : BaseRequest {
    public long ParentId { get; set; }
    public int Block { get; set; }
    public int TableId { get; set; }
  }
}