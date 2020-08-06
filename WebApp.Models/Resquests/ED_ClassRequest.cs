using System;

namespace WebApp.Models.Resquests {

  public class ED_ClassRequest : BaseRequest {
    public long YearId { get; set; }
    public long GroupClassId { get; set; }
    public long GroupOldId { get; set; }
  }
}