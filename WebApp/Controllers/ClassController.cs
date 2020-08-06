using HT.Extentions.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApp.Application.Interfaces;
using WebApp.Models.Base;
using WebApp.Models.Entities;
using WebApp.Models.Helpers;
using WebApp.Models.Resquests;

namespace WebApp.Controllers {

  [Authorize]
  public class ClassController : Controller {
    private readonly int _tableId = Tables.ED_Class;
    private readonly IClassService _service;

    public ClassController(IClassService service) {
      _service = service;
    }

    public IActionResult Page() {
      return View(new PageResult<ED_Class>());
    }

    [HttpPost]
    public async Task<IActionResult> page(long yearId, long groupClassId, long groupOldId, string keyword) {
      var request = new ED_ClassRequest { Keyword = keyword };
      if(string.IsNullOrEmpty(request.Keyword)) {
        request.YearId = yearId;
        request.GroupClassId = groupClassId;
        request.GroupOldId = groupOldId;
      }
      var models = await _service.GetAllPaging(request);
      return View("_Page", models);
    }

    public async Task<IActionResult> detail(long id) {
      var model = await _service.GetById(id);
      return model == null ? RedirectToAction(nameof(page)) : (IActionResult)View(model);
    }

    public async Task<IActionResult> create(long? id) {
      return View(new ED_Class { SourceId = id, DateCreated = DateTime.Now });  // Requie becasue lock select
    }

    [HttpPost]
    public async Task<IActionResult> create(ED_Class model) {
      // Check Role
      var response = await _service.CheckModel(model, Actives.Add);
      TempData[Notify.notifyStatus] = response.Status;
      TempData[Notify.notifyMessage] = response.Message;
      if(!response.IsValid)
        return View(model);
      await _service.Insert(model, _tableId);
      TempData[Notify.notifyMessage] = Notify.createSuccess + model.ClassName;
      return RedirectToAction(nameof(page));
    }

    public async Task<IActionResult> edit(long id) {
      var model = await _service.GetById(id);
      return model == null ? RedirectToAction(nameof(page)) : (IActionResult)View(model);
    }

    [HttpPost]
    public async Task<IActionResult> edit(ED_Class model) {
      // Check Role
      var response = await _service.Update(model, _tableId);
      TempData[Notify.notifyStatus] = response.Status;
      TempData[Notify.notifyMessage] = response.Message;
      if(!response.IsValid)
        return View(model);
      return RedirectToAction(nameof(page));
    }

    [HttpPost]
    public async Task<int> delete(long id) {
      // Check role
      await _service.Delete(id, _tableId);
      return (int)Responses.Susscess;
    }
  }
}