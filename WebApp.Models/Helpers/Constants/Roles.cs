using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.Models.Helpers {

  public class Roles {
    public const string Admin = "admin";
    public const string Manager = "mamager";
    public const string Staff = "staff";

    public const int OnlyFieldBlock = 1;
    public const int AllChildsBlock = 2;
  }
}