using HT.Extentions;
using HT.Extentions.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Models.Interfaces;

namespace WebApp.Models.Entities {

  [Table("CM_Actives")]
  public class CM_Active : Tracking {
    public Actives Active { get; set; } = Actives.Edit;
    public int TableId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Path { get; set; }
    public Guid? DetailSourceId { get; set; }
  }
}