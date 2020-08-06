using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.WsFederation;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers {

  public class AccountController : Controller {
    //private readonly IPermissionsService _permissionsService;
    //public AccountController(IPermissionsService permissionsService) {
    //  _permissionsService = permissionsService;
    //}

    public IActionResult SignOut() {
      //await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
      //await HttpContext.SignOutAsync(WsFederationDefaults.AuthenticationScheme);
      var callbackUrl = Url.Action("A", "Account", values: null, protocol: Request.Scheme);
      return SignOut(
          new AuthenticationProperties { RedirectUri = callbackUrl, AllowRefresh = true },
          CookieAuthenticationDefaults.AuthenticationScheme,
          WsFederationDefaults.AuthenticationScheme);
    }

    //public void Roles() {
    //  if(User != null && User.Identity.IsAuthenticated) {
    //    string userName = User.Claims.Where(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").Select(x => x.Value).FirstOrDefault();
    //    HttpContext.User.Claims.Where(x => x.Type == "Permissions").Reverse();
    //    var claims = new List<Claim>();
    //    foreach(var item in _permissionsService.GetPermissions(userName)) {
    //      claims.Add(new Claim("Permissions", item.Role));
    //    }
    //    var appIdentity = new ClaimsIdentity(claims);
    //    HttpContext.User.AddIdentity(appIdentity);
    //  }
    //  //return Redirect("/");
    //}
  }
}