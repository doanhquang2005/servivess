using HT.Extentions;
using HT.Extentions.Enums;
using HT.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Application.Interfaces;
using WebApp.Data.DBContext;
using WebApp.Models.Entities;

namespace WebApp.Application.Repositories {

  public abstract class RepositoryDetailActive<T> : IRepositoryDetailActive<T> where T : class {
    private readonly AppDbContext _context;
    private readonly IActiveService<T> _active;
    public RepositoryDetailActive(AppDbContext context, IActiveService<T> active) {
      _context = context;
      _active = active;
    }

    public async Task<T> GetById(Guid id) {
      return await _context.Set<T>().FindAsync(id);
    }

    public async Task Insert(T model, int tableId) {
      if(model is DetailTracking tracking) {
        bool IsId = true;
        if(tracking.Id == default)
          IsId = false;
        await _context.Set<T>().AddAsync(model);
        if(!IsId)
          tracking.Id = default;
      } else await _context.Set<T>().AddAsync(model);
      await _context.SaveChangesAsync();
      await Active(model, Actives.Add, tableId);
    }

    public async Task Update(T model) {
      _context.Set<T>().Update(model);
      await _context.SaveChangesAsync();
      // Custom Active Backup
    }

    public async Task<bool> Delete(T model, int tableId) {
      if(model == null)
        return false;
      await Active(model, Actives.Delete, tableId);
      if(model is DetailTracking detailTracking)
        detailTracking.Status = Status.Delete;
      else if(model is Tracking tracking)
        tracking.Status = Status.Delete;
      else if(model is ITracking<long> itracking)
        itracking.Status = Status.Delete;
      _context.Set<T>().Update(model);
      await _context.SaveChangesAsync();
      return true;
    }

    public async Task<bool> Delete(Guid id, int tableId) {
      return await Delete(await GetById(id), tableId);
    }

    public async Task Delete(List<Guid> models, int tableId) {
      foreach(var item in models)
        await Delete(item, tableId);
    }

    public async Task BackupActive(T modelOld, T modelNew, string firstActive, int tableId) {
      await _active.InsertEdit(modelOld, modelNew, firstActive, tableId);
      if(HelperService<T>.Backup(modelOld))
        await Insert(modelOld, tableId);
    }

    public async Task Active(T model, Actives active, int tableId) {
      if(tableId == 0)
        return;
      var mdActive = new CM_Active { Active = active, TableId = tableId };
      if(model is Tracking tracking)
        mdActive.SourceId = tracking.Id;
      else if(model is DetailTracking detailTracking)
        mdActive.DetailSourceId = detailTracking.Id;
      else if(model is ITracking<long> itracking)
        mdActive.SourceId = itracking.Id;
      await _active.Insert(mdActive);
    }
  }
}