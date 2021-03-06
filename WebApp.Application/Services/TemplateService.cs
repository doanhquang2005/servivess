﻿using HT.Extentions;
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

  public class TemplateService : RepositoryActive<ED_Class>, ITemplateService {
    private readonly AppDbContext _context;

    public TemplateService(AppDbContext context, IActiveService<ED_Class> active) : base(context, active) {
      _context = context;
    }

    public async Task<PageResult<ED_Class>> GetAllPaging(ED_ClassRequest request) {
      IQueryable<ED_Class> query = _context.Classes;
      if(!string.IsNullOrEmpty(request.Keyword))
        query = query.Where(d => d.ClassName.Contains(request.Keyword));
      query = query.Where(d => d.Status > 0);
      //query = query.OrderByDescending(d => d.Id);
      return await PageResult<ED_Class>.CreateAsync(query.AsNoTracking(), request.Page, request.PageSize);
    }

    public async Task<Response> Update(ED_Class model, int tableId) {
      var getModel = await GetById(model.Id);
      if(getModel == null)
        return new Response { Message = Notify.notExist };
      var cloneModel = getModel.CloneModel();
      AutoMap<ED_Class>.Convert(getModel, model);
      var response = await CheckModel(getModel, Actives.Edit);
      if(!response.IsValid) return response;
      await BackupActive(cloneModel, getModel, null, tableId);
      await Update(getModel);
      return response;
    }

    public async Task<Response> CheckModel(ED_Class model, Actives active) {
      if(active == Actives.Add) {
        return new Response { Message = "Nâng lớp không phù hợp" };
      }
      return new Response { Status = Notify.success };
    }
  }
}