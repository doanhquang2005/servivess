using System;
using System.Collections.Generic;
using WebApp.Models.Base;
using WebApp.Models.Entities;

namespace WebApp.Models.ViewModels {

  public class CommonOptionSelect {
    public CommonOptionSelect() {
      Details = new List<CommonOptionSelectDetail>();
    }

    public int Type { get; set; }
    public long ParentId1 { get; set; }
    public long ParentId2 { get; set; }
    public long ParentId3 { get; set; }
    public string Value { get; set; }
    public bool IsRequire { get; set; }
    public bool IsDefault { get; set; }
    public bool IsMultiple { get; set; }
    public bool? IsCheck1 { get; set; }
    public bool? IsCheck2 { get; set; }
    public int? Int1 { get; set; }
    public int? Int2 { get; set; }
    public List<CommonOptionSelectDetail> Details { get; set; }
  }

  public class CommonOptionSelectDetail {
    public string Id { get; set; }
    public string Name { get; set; }
    public string Icon { get; set; }
  }
}