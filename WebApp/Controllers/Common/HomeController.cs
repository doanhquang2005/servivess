using HT.Extentions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApp.Application.Interfaces;
using WebApp.Extentions;
using WebApp.Models.Base;
using WebApp.Models.Entities;
using WebApp.Models.Resquests;
using WebApp.Models.ViewModels;

namespace WebApp.Controllers {

  [Authorize]
  public class HomeController : Controller {
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger) {
      _logger = logger;
    }

    public IActionResult index() {
      //return Redirect("/class/page");

      string Id = User.FindFirstValue(ClaimTypes.NameIdentifier);
      return View();
    }

    public Guid test() {
      return GenerateId.NewGuid();
    }

    //public async Task<IActionResult> Test() {
    //  for(int i = 1; i < 50; i++)
    //    await _billDetailService.Insert(new AA_BillDetail {
    //      StaffId = i,
    //    }, 0);
    //  var models = await _billDetailService.GetAllPaging(new AA_BillDetailRequest());
    //  return View(models);
    //}

    public IActionResult privacy() {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult error() {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}