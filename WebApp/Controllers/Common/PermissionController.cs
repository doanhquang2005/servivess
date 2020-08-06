using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HT.Extentions.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Application.Interfaces;
using WebApp.Models.Base;
using WebApp.Models.Entities;
using WebApp.Models.Helpers;
using WebApp.Models.Resquests;

namespace WebApp.Controllers {

  public class PermissionController : Controller {
    private readonly int _tableId = Tables.Permission;
    private readonly IPermissionService _service;
    private readonly UserManager<US_User> _userManager;
    private readonly RoleManager<US_Role> _roleManager;
    public PermissionController(IPermissionService service) {
      _service = service;
    }

    public async Task<IActionResult> page(int id = 1) {
      var models = await _service.GetAllPaging(new CM_PermissionRequest { Page = id, PageSize = 20 });
      return View(models);
    }

    [HttpPost]
    public async Task<IActionResult> page(string keyword, long parentId, int tableId, int block, int page = 1) {
      // Check Role dựa vào tableId
      //if(parentId <= 0 && tableId <= 0 && !User.IsInRole(Roles.Admin))
      //  return View("_Page", new PageResult<CM_Permission>());
      var request = new CM_PermissionRequest {
        ParentId = parentId,
        TableId = tableId,
        Block = block,
        Page = page,
        PageSize = 15
      };
      if(!string.IsNullOrEmpty(keyword))
        request = new CM_PermissionRequest {
          Keyword = keyword
        };
      var models = await _service.GetAllPaging(request);
      return View("_Page", models);
    }

    [Authorize(Roles = Roles.Admin)]
    public IActionResult create(long id, int tableid, int block, string username) {
      return View(new CM_Permission {
        ParentId = id,
        TableId = tableid,
        Block = block,
        UserName = username
      });
    }

    [HttpPost]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> create(CM_Permission model) {
      var response = await _service.CheckModel(model, Actives.Add);
      TempData[Notify.notifyStatus] = response.Status;
      TempData[Notify.notifyMessage] = response.Message;
      if(!response.IsValid)
        return View(model);
      await _service.InsertDelete(model, _tableId);
      return RedirectToAction(nameof(page));
    }

    [HttpPost]
    [Authorize(Roles = Roles.Admin)]
    public async Task<int> createjs(CM_Permission model) {
      var response = await _service.CheckModel(model, Actives.Add);
      if(!response.IsValid)
        return (int)Responses.Deny;
      await _service.InsertDelete(model, 0);
      return (int)Responses.Susscess;
    }

    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> edit(long id) {
      var model = await _service.GetById(id);
      return model == null ? RedirectToAction(nameof(page)) : (IActionResult)View(model);
    }

    [HttpPost]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> edit(CM_Permission model) {
      // Check Role
      var response = await _service.Update(model, _tableId);
      TempData[Notify.notifyStatus] = response.Status;
      TempData[Notify.notifyMessage] = response.Message;
      if(!response.IsValid)
        return View(model);
      return RedirectToAction(nameof(page));
    }

    [HttpPost]
    [Authorize(Roles = Roles.Admin)]
    public async Task<int> delete(long id) {
      // Check role
      await _service.Delete(id, _tableId);
      return (int)Responses.Susscess;
    }
  }
}