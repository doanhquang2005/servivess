//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using WebApp.Application.Interfaces;
//using WebApp.Data.Entity.Billing;
//using WebApp.Models;
//using WebApp.Models.Resquests;

//namespace WebApp.Controllers {
//  [Authorize]
//  public class DayController : Controller {
//    private readonly IDayService dayService;
//    public DayController(IDayService dayService) {
//      this.dayService = dayService;
//    }

//    public async Task<IActionResult> Page(int id = 1) {
//      var models = await dayService.GetAllPaging(new CM_CommonRequest {
//        Page = id,
//        PageSize = 10
//      });
//      return View(models);
//    }

//    public IActionResult Create() {
//      return View(new BiDays {
//        DateTime = DateTime.Now
//      });
//    }

//    [HttpPost]
//    public async Task<IActionResult> Create(BiDays model) {
//      await dayService.Insert(model, 0);
//      return RedirectToAction("page");
//    }

//    public async Task<IActionResult> Edit(int id) {
//      var model = await dayService.GetById(id);
//      if(model == null)
//        return RedirectToAction("page");
//      return View(model);
//    }

//    [HttpPost]
//    public async Task<IActionResult> Edit(BiDays model) {
//      await dayService.Update(model);
//      return RedirectToAction("page");
//    }

//    [HttpPost]
//    public async Task<IActionResult> Delete(int id) {
//      await dayService.Delete(id);
//      return RedirectToAction("page");
//    }
//  }
//}