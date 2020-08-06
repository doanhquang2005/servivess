using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApp.Models.Base;

namespace WebApp.Extentions {

  public static class IdentityExtensions {
    public static long GetUserId(this ClaimsPrincipal claimsPrincipal) {
      var claim = ((ClaimsIdentity)claimsPrincipal.Identity).Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault();
      return long.Parse(claim.Value);
    }

    public static string GetSpecificClaim(this ClaimsPrincipal claimsPrincipal, string claimType) {
      var claim = claimsPrincipal.Claims.FirstOrDefault(x => x.Type == claimType);
      return (claim != null) ? claim.Value : string.Empty;
    }
  }

  public class CustomClaimsPrincipalFactory : UserClaimsPrincipalFactory<US_User, US_Role> {
    UserManager<US_User> _userManger;

    public CustomClaimsPrincipalFactory(UserManager<US_User> userManager, RoleManager<US_Role> roleManager, IOptions<IdentityOptions> options)
        : base(userManager, roleManager, options) {
      _userManger = userManager;
    }

    public async override Task<ClaimsPrincipal> CreateAsync(US_User user) {
      var principal = await base.CreateAsync(user);
      var roles = await _userManger.GetRolesAsync(user);
      ((ClaimsIdentity)principal.Identity).AddClaims(new[] {
                new Claim(ClaimTypes.NameIdentifier,user.UserName),
                new Claim("FullName",user.FullName?? "/account/claim"),
                new Claim("Avatar",user.Avatar??"/account/claim"),
                new Claim("Roles",string.Join(";",roles)),
            });
      return principal;
    }
  }

  //public class ClaimTypes {
  //  public const string FullName = "FullName";
  //}
}