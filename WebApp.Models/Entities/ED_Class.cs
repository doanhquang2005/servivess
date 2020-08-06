using HT.Extentions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models.Entities {

  [Table("ED_Classes")]
  public class ED_Class : Tracking {
    [Display(Name = "Kết thúc?")]
    public bool IsEnd { get; set; }
    [Display(Name = "Hoàn thành chương trình")]
    public bool IsSuccess { get; set; }
    [Display(Name = "Bắt đầu")]
    public DateTime DateStart { get; set; } = DateTime.Now;
    [Display(Name = "Kết thúc")]
    public DateTime? DateEnd { get; set; }
    [Display(Name = "Năm học")]
    public long? YearId { get; set; }
    [Display(Name = "Nhóm lớp")]
    public long? GroupClassId { get; set; }
    [Display(Name = "Nhóm tuổi")]
    public long? GroupOldId { get; set; }
    [Display(Name = "Tên lớp")]
    public string ClassName { get; set; }
    [Display(Name = "Thứ tự")]
    public int Position { get; set; }
    [Display(Name = "Điểm trường")]
    public long? SchoolId { get; set; }
    // Nhóm trẻ ghép
    // Ghép vào lớp
    [Display(Name = "Bán trú")]
    public long? HaftLiveId { get; set; }
    [Display(Name = "Chương trình dạy học")]
    public long? ProgramId { get; set; }
    [Display(Name = "Làm quen ngôn ngữ")]
    public bool IsLanguage { get; set; }
    [Display(Name = "Có trẻ khuyết tật")]
    public bool IsDisability { get; set; }
    [Display(Name = "Học 2 buổi/ngày")]
    public bool IsFullTime { get; set; }
    //public ED_Class Clone() {
    //  return (ED_Class)MemberwiseClone();
    //}
  }
}