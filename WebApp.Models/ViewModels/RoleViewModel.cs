using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApp.Models.ViewModels {

  public class RoleViewModel {
    [Display(Name = "Tài khoản đăng nhập")]
    public string UserName { get; set; }
    [Display(Name = "Quyền truy cập")]
    public string RoleName { get; set; }
  }
}