using Newtonsoft.Json.Serialization;
using WebApp.Models.ViewModels;

namespace WebApp.Models.Helpers {

  public class LayoutMenu {
    public const int Statistical = 21;
    public const int Billing = 22;
    public const int Service = 23;
    public const int Report = 24;
    public const int Data = 25;

    public const int Account = 0;
    public const int Home = 1;
    public const int Day = 2;

    public const int Active = 10;

    public static LayoutPartMenu Get(int part) {
      if(part == Statistical)
        return new LayoutPartMenu {
          Icon = "fa fa-home",
          Name = "Thống kê",
          Path = "/"
        };
      if(part == Billing)
        return new LayoutPartMenu {
          Icon = "fa fa-home",
          Name = "Quản lý giá cước",
          Path = "/"
        };
      if(part == Service)
        return new LayoutPartMenu {
          Icon = "fa fa-home",
          Name = "Quản lý Service",
          Path = "/"
        };
      if(part == Report)
        return new LayoutPartMenu {
          Icon = "fa fa-home",
          Name = "Tổng hợp báo cáo",
          Path = "/"
        };
      if(part == Data)
        return new LayoutPartMenu {
          Icon = "fa fa-home",
          Name = "Quản lý dữ liệu",
          Path = "/"
        };

      if(part == Account)
        return new LayoutPartMenu {
          Icon = "fa fa-home",
          Name = "Tài khoản",
          Path = "/"
        };
      if(part == Home)
        return new LayoutPartMenu {
          Icon = "fa fa-home",
          Name = "Trang chủ",
          Path = "/"
        };
      if(part == Day)
        return new LayoutPartMenu {
          Icon = "fa fa-home",
          Name = "Quản lý",
          Path = "#"
        };

      if(part == Active)
        return new LayoutPartMenu {
          Icon = "fa fa-home",
          Name = "Nhật ký",
          Path = "/"
        };
      return new LayoutPartMenu();
    }
  }
}