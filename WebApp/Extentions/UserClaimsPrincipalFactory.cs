using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApp.Models.Base;
using WebApp.Models.Helpers;

namespace WebApp.Extentions {

  public class UserClaimsPrincipalFactory : UserClaimsPrincipalFactory<US_User> {
    UserManager<US_User> _userManger;

    public UserClaimsPrincipalFactory(UserManager<US_User> userManager, IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor) {
      _userManger = userManager;
    }

    protected override async Task<ClaimsIdentity> GenerateClaimsAsync(US_User user) {
      var identity = await base.GenerateClaimsAsync(user);
      var roles = await _userManger.GetRolesAsync(user);
      identity.AddClaim(new Claim(ClaimType.FullName, user.FullName ?? "/account/claim"));
      identity.AddClaim(new Claim(ClaimType.Avatar, user.Avatar ?? "/account/claim"));
      identity.AddClaim(new Claim(ClaimType.IsMale, user.IsMale ? "1" : "0"));
      foreach(var item in roles)
        identity.AddClaim(new Claim(ClaimTypes.Role, item));
      return identity;
    }
  }
}