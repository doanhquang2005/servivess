using HT.Extentions.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
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

  public class CommonService : ICommonService {
    private readonly AppDbContext _context;
    public CommonService(AppDbContext context) {
      _context = context;
    }

    public async Task GetAllOptionSelect(CommonOptionSelect model) {
      //if(model.Type == Types.Store) {
      //  IQueryable<AA_Store> query = _context.Stores;
      //  if(model.ParentId1 > 0)
      //    query = query.Where(d => _context.Permissions.Where(e => e.UserId == model.ParentId1
      //    && e.TableId == Tables.Store && e.Block == Roles.OnlyFieldBlock && d.Status > 0).Select(j => j.ParentId)
      //      .Contains(d.Id));
      //  query = query.Where(d => d.Status == Status.Acppect).OrderBy(d => d.Position);
      //  model.Details = await query.OrderBy(d => d.Position).Select(d => new CommonOptionSelectDetail { Id = d.Id.ToString(), Name = d.StoreName }).ToListAsync();
      //} else if(model.Type == Types.Service) {
      //  IQueryable<AA_Service> query = _context.Services.Where(d => d.Status == Status.Acppect);
      //  if(model.IsCheck1 != null)
      //    query = query.Where(d => d.IsCombo == model.IsCheck1);
      //  model.Details = await query.OrderBy(d => d.Position).Select(d => new CommonOptionSelectDetail { Id = d.Id.ToString(), Name = d.ServiceName, Icon = d.Avatar }).ToListAsync();
      //} else if(model.Type == Types.Staff) {
      //  IQueryable<AA_Staff> query = _context.Staffs;
      //  if(model.ParentId2 > 0)
      //    query = query.Where(d => _context.StaffInStores.Where(e => e.StoreId == model.ParentId2).Select(
      //      e => e.StaffId).Contains(d.Id));
      //  if(model.ParentId1 > 0)
      //    query = query.Where(d => _context.Permissions.Where(e => e.UserId == model.ParentId1
      //    && e.TableId == Tables.Staff && e.Block == Roles.OnlyFieldBlock && d.Status > 0).Select(j => j.ParentId)
      //      .Contains(d.Id));
      //  query = query.Where(d => d.Status > 0);
      //  model.Details = await query.OrderBy(d => d.Position).Select(d => new CommonOptionSelectDetail { Id = d.Id.ToString(), Name = (d.Code ?? "---") + ": " + d.StaffName, Icon = d.Avatar }).ToListAsync();
      //} else if(model.Type == Types.User) {
      //  IQueryable<US_User> query = _context.Users.Where(d => d.Status > 0);
      //  model.Details = await query.Select(d => new CommonOptionSelectDetail { Id = d.Id.ToString(), Name = d.FullName, Icon = d.Avatar }).ToListAsync();
      //}
    }

    public async Task<string> GetNameById(long id, int tableId) {
      //if(tableId == Tables.Staff) {
      //  var model = await _context.Staffs.Where(d => d.Id == id).FirstOrDefaultAsync();
      //  return model?.StaffName;
      //} else if(tableId == Tables.Store) {
      //  var model = await _context.Stores.Where(d => d.Id == id).FirstOrDefaultAsync();
      //  return model?.StoreName;
      //}
      return null;
    }

    public async Task<List<CommonListName>> GetListName(List<long> models, int type) {
      //if(type == Types.StoreAddress) {
      //  return await _context.Stores.Where(d => models.Contains(d.Id))
      //    .Select(d => new CommonListName { Id = d.Id, Name = d.Adress }).ToListAsync();
      //}
      //if(type == Types.Staff)
      //  return await _context.Staffs.Where(d => models.Contains(d.Id))
      //    .Select(d => new CommonListName { Id = d.Id, Name = d.StaffName }).ToListAsync();
      //if(type == Types.User)
      //  return await _context.Users.Where(d => models.Contains(d.Id))
      //    .Select(d => new CommonListName { Id = d.Id, Name = d.FullName }).ToListAsync();
      //if(type == Types.Store)
      //  return await _context.Stores.Where(d => models.Contains(d.Id))
      //    .Select(d => new CommonListName { Id = d.Id, Name = d.StoreName }).ToListAsync();
      //if(type == Types.Service)
      //  return await _context.Services.Where(d => models.Contains(d.Id))
      //    .Select(d => new CommonListName { Id = d.Id, Name = d.ServiceName }).ToListAsync();
      //if(type == Types.ED_Class)
      //  return await _context.Classes.Where(d => models.Contains(d.Id))
      //    .Select(d => new CommonListName { Id = d.Id, Name = d.ClassName }).ToListAsync();
      return null;
    }
  }
}