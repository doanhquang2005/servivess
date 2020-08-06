using HT.Extentions;
using HT.Extentions.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Application.Interfaces;
using WebApp.Application.Repositories;
using WebApp.Data.DBContext;
using WebApp.Models.Base;
using WebApp.Models.Entities;
using WebApp.Models.Helpers;
using WebApp.Models.Resquests;

namespace WebApp.Application.Services {

  public class ImageService : RepositoryActive<CM_Image>, IImageService {
    private readonly AppDbContext _context;

    public ImageService(AppDbContext context, IActiveService<CM_Image> active) : base(context, active) {
      _context = context;
    }

    public async Task<PageResult<CM_Image>> GetAllPaging(CM_CommonRequest request) {
      IQueryable<CM_Image> query = _context.Images;
      if(!string.IsNullOrEmpty(request.Keyword))
        query = query.Where(d => d.ImageName.Contains(request.Keyword));
      //query = query.Where(d => d.Status > 0);
      //query = query.OrderByDescending(d => d.Id);
      return await PageResult<CM_Image>.CreateAsync(query.AsNoTracking(), request.Page, request.PageSize);
    }

    public async Task<CM_Image> GetByPath(string path) {
      return await _context.Images.Where(d => d.Path == path).FirstOrDefaultAsync();
    }

    public async Task<Response> Update(CM_Image model, int tableId) {
      var getModel = await GetById(model.Id);
      if(getModel == null)
        return new Response { Message = Notify.notExist };
      var cloneModel = getModel.CloneModel();
      AutoMap<CM_Image>.Convert(getModel, model);
      var response = await CheckModel(getModel, Actives.Edit);
      if(!response.IsValid) return response;
      await BackupActive(cloneModel, getModel, null, tableId);
      await Update(getModel);
      return response;
    }

    public async Task<Response> CheckModel(CM_Image model, Actives active) {
      if(active == Actives.Add) {
      }
      return new Response { Status = Notify.success };
    }
  }
}