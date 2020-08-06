namespace WebApp.Models.Resquests {

  public abstract class BaseRequest {
    public string Keyword { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = int.MaxValue;
  }
}