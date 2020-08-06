using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApp.Application.Interfaces;
using WebApp.Models.Entities;
using WebApp.Models.Helpers;
using WebApp.Models.Resquests;

namespace WebApp.Controllers {

  [Authorize(Roles = Roles.Admin)]
  public class ActiveController : Controller {
    private readonly IActiveService<CM_Active> _service;
    public ActiveController(IActiveService<CM_Active> service) => _service = service;

    public async Task<IActionResult> page(long id, int page = 1) {
      var models = await _service.GetAllPaging(new CM_ActiveRequest { UserId = id, Page = page, PageSize = 20 });
      return View(models);
    }
  }
}