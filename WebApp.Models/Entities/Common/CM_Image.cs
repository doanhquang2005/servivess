using HT.Extentions;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models.Entities {

  [Table("CM_Images")]
  public class CM_Image : Tracking {
    public string Path { get; set; }
    public string ImageName { get; set; }
  }
}