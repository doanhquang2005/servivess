using HT.Extentions;
using HT.Extentions.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Application.Interfaces;
using WebApp.Application.Repositories;
using WebApp.Data.DBContext;
using WebApp.Data.Entity.Billing;
using WebApp.Models.Base;
using WebApp.Models.Entities;
using WebApp.Models.Helpers;
using WebApp.Models.Resquests;

namespace WebApp.Application.Services {

  public class DayService : BaseRepository<BiDays>, IDayService {
    private readonly IDbContext _context;

    public DayService(IDbContext context) : base(context) {
      _context = context;
    }

    public async Task<PageResult<BiDays>> GetAllPaging(CM_CommonRequest request) {
      return new PageResult<BiDays>();
      //IQueryable<BiDays> query = _context.BiDays;
      //if(!string.IsNullOrEmpty(request.Keyword))
      //  query = query.Where(d => d.DayName.Contains(request.Keyword));
      //query = query.Where(d => d.Status > 0);
      //query = query.OrderByDescending(d => d.DayCount);
      //return await PageResult<BiDays>.CreateAsync(query.AsNoTracking(), request.Page, request.PageSize);
    }

    public async Task<Response> Update(BiDays model, int tableId) {
      var getModel = await GetById(model.Id);
      if(getModel == null)
        return new Response { Message = Notify.notExist };
      AutoMap<BiDays>.Convert(getModel, model);
      var response = await CheckModel(getModel, Actives.Edit);
      if(!response.IsValid) return response;
      await Update(getModel);
      return response;
    }

    public async Task<Response> CheckModel(BiDays model, Actives active) {
      if(active == Actives.Add) {
        //return new Response { Message = "Nâng lớp không phù hợp" };
      }
      model.DayCount = model.DateTime.ToDayCount();
      return new Response { Status = Notify.success };
    }
  }
}