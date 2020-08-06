using HT.Extentions;
using LazZiya.ImageResize;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using WebApp.Application.Interfaces;
using WebApp.Models.Entities;
using WebApp.Models.ViewModels;

namespace WebApp.Controllers {

  [Authorize]
  public class CommonController : Controller {
    private readonly ICommonService _service;
    private readonly IImageService _imageService;
    private static string _pathRoot;
    private int _month = DateTime.Now.Month;
    public CommonController(ICommonService service, IImageService imageService) {
      _service = service;
      _imageService = imageService;
    }

    [HttpPost]
    public async Task<IActionResult> optionselect(CommonOptionSelect model) {
      await _service.GetAllOptionSelect(model);
      return View(model);
    }

    [HttpPost]
    public async Task<List<CommonListName>> listname(List<long> models, int type = 0) {
      return await _service.GetListName(models, type);
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<JsonResult> image(long id, IFormFile upload, int width = 0, int height = 0, bool isCrop = true) {
      return new JsonResult(new {
        url = await UpImageAsync(id, upload, width, height, isCrop)
      });
    }

    //[HttpPost]
    //public async Task<double> Rating(long id, int value) {
    //  var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
    //  var model = new Rate {
    //    RateId = id,
    //    Value = value,
    //    IP = ip
    //  };
    //  return await _rateService.InsertAsync(model);
    //}

    private void CheckPath() {
      if(_month <= DateTime.Now.Month) {
        _pathRoot = @"wwwroot/uploads/" + DateTime.Now.ToString("MMyyyy") + "/";
        if(!Directory.Exists(_pathRoot))
          Directory.CreateDirectory(_pathRoot);
        _month = DateTime.Now.Month + 1;
      }
    }

    private async Task<string> UpImageAsync(long id, IFormFile file, int width, int height, bool isCrop) {
      CheckPath();
      using var memoryStream = new MemoryStream();
      await file.CopyToAsync(memoryStream);
      using var img = Image.FromStream(memoryStream);
      Image scaleImage;
      if(width == 0) width = img.Width;
      if(height == 0) height = img.Height;
      if(width > 1028) {
        width = 1028;
        height = img.Height * 1028 / img.Width;
      }
      if(height > 1028) {
        height = 1028;
        width = img.Width * 1028 / img.Height;
      }
      if(isCrop) scaleImage = ImageResize.ScaleAndCrop(img, width, height);
      else scaleImage = ImageResize.Scale(img, width, height);
      var fileName = file.FileName.ToFileName();
      scaleImage.SaveAs(_pathRoot + fileName);
      await _imageService.Insert(new CM_Image { SourceId = id, Path = _pathRoot.Substring(7) + fileName, ImageName = fileName }, 0);
      return _pathRoot.Substring(7) + fileName;
    }
  }
}