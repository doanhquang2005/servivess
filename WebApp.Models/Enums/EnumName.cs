using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.Models.Enums {

  public class EnumName {
    public static string PermissionLevel(EN_PermissionLevel model) {
      if(model == EN_PermissionLevel.Disallow)
        return "Không được phép";
      if(model == EN_PermissionLevel.Allow)
        return "Được phép";
      if(model == EN_PermissionLevel.SuperAll)
        return "Quyền cao nhất";
      return "";
    }
  }
}