//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using WebApp.Data.Extentions;
//using WebApp.Extension.Helpers;
//using WebApp.Extension.Interfaces;
//using WebApp.Extension.Services;
//using WebApp.Models;
//using System.Net.Http;
//using System.Text.Json;
//using WebApp.Data.Models;
//using Newtonsoft.Json;
//using WebApp.Data.Models.API;
//using System.Text;
//using System.Net;
//using System.Collections.Specialized;
//using Microsoft.AspNetCore.Authorization;
//using WebApp.Extension.Services.Customer;
//using WebApp.Models.Request;
//using Microsoft.AspNetCore.Authentication.WsFederation;
//using Microsoft.IdentityModel.Protocols.WsFederation;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.IdentityModel.Web;
//using Microsoft.IdentityModel.Claims;
//using System.Security;
//using WebApp.Extension.Services.Web;

//namespace WebApp.Controllers {
//  [Authorize]
//  public class AdminController : Controller {
//    private readonly IReportService _reportService;
//    private readonly IBillService _billService;

//    public AdminController(IReportService reportService, IBillService billService) {
//      _reportService = reportService;
//      _billService = billService;
//    }

//    public void Random() {
//      string s = HttpContext.User.Identity.Name;
//      Console.WriteLine("fsdfdsf");
//    }

//    public async Task InitDB() {
//      await CuocService.ConvertOld();
//    }

//    public IActionResult RAR() {
//      var model = CuocService.Test();
//      return Content(model.Tien + "");
//    }

//    [HttpPost]
//    public async Task<int> ReportBill(int id) {
//      //if(id >= Helper.DateByDateTime())
//      //  return -1;
//      //if(RecordService.CountByPending(id) > 0)
//      //  return -2;
//      var listCustomers = Helper.GetCustomers();
//      var models = _reportService.GetAllPaging(new ResquestReport { MonthCount = id, PageSize = int.MaxValue });
//      foreach(var item in models) {
//        var customer = listCustomers.Where(d => d.NumPhone == item.NumberPhone).FirstOrDefault(); // OrderBy id pending
//        var bill = new Bill {
//          MonthCount = id,
//          FileType = item.FileType,
//          FileId = item.FileId,
//          Cost = item.Total,
//        };
//        //bill.AddCustomer(customer);
//        await _billService.DeleteAsync(bill.NumberPhone, bill.MonthCount);
//        await _billService.InsertAsync(bill);
//      }
//      await _billService.InsertFinalAsync(id);
//      return 2;
//    }

//    [HttpPost]
//    public async Task<int> ReportFinal(int id) {
//      if(id >= Helper.MonthCountByDateTime())
//        return -1;
//      if(RecordService.CountByPending(id) > 0)
//        return -2;
//      await ProcessBilling(id);
//      var model = _reportService.GetByNumberPhone(Helper.nameReportMonth, id);
//      if(model.IsLock)
//        return 2;
//      model.IsLock = true;
//      _reportService.Update(model);
//      RecordService.LocksByDate(id);
//      return 2;
//    }

//    //[HttpPost]
//    public async Task<int> ProcessBilling(int id, long fileId = 0) {
//      if(id > Helper.MonthCountByDateTime())
//        return -1;
//      var model = _reportService.GetByNumberPhone(Helper.nameReportMonth, id);
//      if(model != null && model.IsLock)
//        return 3;
//      if(model != null) {
//        //if(model.DateUpdated.AddMinutes(5) > DateTime.Now)
//        //  return -2;
//        _reportService.Update(model);
//      }
//      var listCustomers = Helper.GetCustomers(); // Web Services
//      var users = RecordService.GroupByNumberPhone(id, fileId); // All
//      foreach(var item in users) {
//        if(item.AccNumber.Length != 11)
//          continue;
//        var models = RecordService.GetAllByNumberPhone(item.AccNumber, id);
//        var report = await _reportService.InsertAsync(item.AccNumber, id, models);
//        var customer = listCustomers.Where(d => d.NumPhone == report.NumberPhone).FirstOrDefault();
//        if(customer != null) {
//          report.AddCustomer(customer);
//          await _reportService.UpdateAsync(report);
//        }
//      }
//      await _reportService.InsertFinalAsync(id);
//      return 2;
//    }
//  }
//}