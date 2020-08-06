using HT.Extentions.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApp.Application.Interfaces;
using WebApp.Data.Entity.Billing;
using WebApp.Models.Base;
using WebApp.Models.Entities;
using WebApp.Models.Helpers;
using WebApp.Models.Resquests;

namespace WebApp.Controllers {

  [Authorize()]
  public class DayController : Controller {
    private readonly int _tableId = Tables.BiDays;
    private readonly IDayService _service;
    public DayController(IDayService service) {
      _service = service;
    }

    public IActionResult page() {
      return View(new PageResult<BiDays>());
    }

    [HttpPost]
    public async Task<IActionResult> page(string keyword, int page = 1) {
      var models = await _service.GetAllPaging(new CM_CommonRequest {
        Keyword = keyword,
        Page = page,
        PageSize = 10
      });
      return View("_Page", models);
    }

    public async Task<IActionResult> detail(long id) {
      var model = await _service.GetById(id);
      return model == null ? RedirectToAction(nameof(page)) : (IActionResult)View(model);
    }

    public IActionResult create() {
      return View(new BiDays());
    }

    [HttpPost]
    public async Task<IActionResult> create(BiDays model) {
      var response = await _service.CheckModel(model, Actives.Add);
      TempData[Notify.notifyStatus] = response.Status;
      TempData[Notify.notifyMessage] = response.Message;
      if(!response.IsValid)
        return View(model);
      await _service.Insert(model);
      return RedirectToAction(nameof(page));
    }

    public async Task<IActionResult> edit(long id) {
      var model = await _service.GetById(id);
      return model == null ? RedirectToAction(nameof(page)) : (IActionResult)View(model);
    }

    [HttpPost]
    public async Task<IActionResult> edit(BiDays model) {
      var response = await _service.Update(model, _tableId);
      TempData[Notify.notifyStatus] = response.Status;
      TempData[Notify.notifyMessage] = response.Message;
      if(!response.IsValid)
        return View(model);
      return RedirectToAction(nameof(page));
    }

    [HttpPost]
    public async Task<int> delete(long id) {
      await _service.Delete(id);
      return (int)Responses.Susscess;
    }
  }
}