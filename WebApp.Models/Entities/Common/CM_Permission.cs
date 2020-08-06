using HT.Extentions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebApp.Models.Entities {

  [Table("CM_Permissions")]
  public class CM_Permission : Tracking {
    [NoMap]
    public long ParentId { get; set; }
    [NoMap]
    public int TableId { get; set; }
    [NoMap]
    public long UserId { get; set; }
    [NoMap]
    [Display(Name = "Tài khoản")]
    public string UserName { get; set; }
    [Display(Name = "Quyền xem")]
    public int Detail { get; set; }
    [Display(Name = "Quyền tạo")]
    public int Create { get; set; }
    [Display(Name = "Quyền sửa")]
    public int Edit { get; set; }
    [Display(Name = "Quyền xóa")]
    public int Delete { get; set; }
    [Display(Name = "Quyền duyệt")]
    public int Approval { get; set; }
    [NoMap]
    public int Block { get; set; }
  }
}