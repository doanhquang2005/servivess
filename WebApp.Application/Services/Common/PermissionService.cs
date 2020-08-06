using HT.Extentions;
using HT.Extentions.Enums;
using Microsoft.AspNetCore.Identity;
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
using WebApp.Models.ViewModels;

namespace WebApp.Application.Services {

  public class PermissionService : RepositoryActive<CM_Permission>, IPermissionService {
    private readonly AppDbContext _context;

    //private readonly UserManager<US_User> _userManager;

    public PermissionService(AppDbContext context, IActiveService<CM_Permission> active) : base(context, active) {
      _context = context;
    }

    public async Task<PageResult<CM_Permission>> GetAllPaging(CM_PermissionRequest request) {
      IQueryable<CM_Permission> query = _context.Permissions;
      if(request.ParentId > 0)
        query = query.Where(d => d.ParentId == request.ParentId);
      if(request.Block != 0)
        query = query.Where(d => d.Block == request.Block);
      query = query.Where(d => d.Status > 0).OrderByDescending(d => d.DateUpdated);
      return await PageResult<CM_Permission>.CreateAsync(query.AsNoTracking(), request.Page, request.PageSize);
    }

    public async Task<Response> Update(CM_Permission model, int tableId) {
      var getModel = await GetById(model.Id);
      if(getModel == null)
        return new Response { Message = Notify.notExist };
      var cloneModel = getModel.CloneModel();
      AutoMap<CM_Permission>.Convert(getModel, model);
      var response = await CheckModel(getModel, Actives.Edit);
      if(!response.IsValid) return response;
      await BackupActive(cloneModel, getModel, null, tableId);
      await Update(getModel);
      return response;
    }

    public async Task InsertDelete(CM_Permission model, int tableId) {
      await _context.Permissions.Where(d => d.UserId == model.UserId && d.ParentId == model.ParentId &&
      d.Block == model.Block && d.Status > 0).ForEachAsync(d => d.Status = Status.Delete);
      await _context.SaveChangesAsync();
      await Insert(model, tableId);
    }

    public async Task<Response> CheckModel(CM_Permission model, Actives active) {
      if(active == Actives.Add) {
        //var user = await _context.Users.Where(d => d.NormalizedUserName == model.UserName.ToUpper()).FirstOrDefaultAsync();
        //if(user == null)
        //  return new Response { Message = "Tài khoản không tồn tại" };
        //model.UserId = user.Id;
      }
      return new Response { Status = Notify.success };
    }
  }
}