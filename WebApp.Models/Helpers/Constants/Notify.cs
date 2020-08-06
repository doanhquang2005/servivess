namespace WebApp.Models.Helpers {

  public class Notify {
    public const string notifyStatus = "notifyStatus";
    public const string notifyMessage = "notifyMessage";

    public const int danger = 0;
    public const int warning = 1;
    public const int success = 2;

    public const string createSuccess = "Đã tạo thành công ";
    public const string editSuccess = "Đã sửa thành công ";
    public const string useSuccess = "Thao tác thành công ";

    public const string permissionFail = "Dữ liệu không thể thay đổi ";
    public const string validateFail = "Dữ liệu chưa chính xác ";
    public const string notExist = "Dữ liệu không tồn tại ";
    public const string fileNotExist = "File không tồn tại trên hệ thống ";
    public const string lockData = "Dữ liệu đã bị khóa ";
  }
}