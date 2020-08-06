using HT.Extentions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WebApp.Models.Helpers {

  public class Helper {
    public const string BrandName = "Chicano Salon"; // /images/login.jpg,
    public const string Slogan = "Thay đổi để tận hưởng cuộc sống";
    public const string ImageLogin = "/images/login.jpg";
    public const string ImageRegister = "/images/register.jpg";
    public static int MouthByBirthday(DateTime? birthday) {
      return (int)(DateTime.Now.Subtract((DateTime)birthday).Days / (365.25 / 12) + 0.5);
    }

    public class AllowanceTicket {
      public static string nameActionByTicketType(int ticketType) {
        if(ticketType == Types.AT_OverQuantityTicketType)
          return "overquantity";
        if(ticketType == Types.AT_OvertimeTicketType)
          return "overtime";
        if(ticketType == Types.AT_TransferTicketType)
          return "transfer";
        return "";
      }
    }
  }
}