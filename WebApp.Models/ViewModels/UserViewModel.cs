using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.ViewModels {

  public class LoginViewModel {
    public string UserName { get; set; }
    public string Password { get; set; }
    public bool RememberMe { get; set; } = true;
  }

  public class ChangePasswordViewModel {
    public long Id { get; set; }

    [Display(Name = "Mật khẩu cũ")]
    public string OldPassword { get; set; }
    [Display(Name = "Mật khẩu mới")]
    public string NewPassword { get; set; }
    [Display(Name = "Nhập lại mật khẩu")]
    public string ConfirmPassword { get; set; }
  }

  public class RegisterViewModel {
    [Display(Name = "Tài khoản")]
    public string UserName { get; set; }
    [Display(Name = "Họ và tên")]
    public string FullName { set; get; }
    [Display(Name = "Ngày sinh")]
    public DateTime Birthday { set; get; }
    [Display(Name = "Số di động")]
    public string PhoneNumber { set; get; }
    [Display(Name = "Hình đại diện")]
    public string Avatar { get; set; }
    [Display(Name = "Mật khẩu")]
    public string Password { get; set; }
    [Display(Name = "Nhập lại mật khẩu")]
    public string ConfirmPassword { get; set; }
    [Display(Name = "Nam")]
    public bool IsMale { get; set; } = true;
    [Display(Name = "Mã đăng ký")]
    public string Code { get; set; }
  }
}