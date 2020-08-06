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
  public abstract class RepositoryDetail<T> : IRepositoryDetail<T> where T : class {
    private readonly AppDbContext _context;
    public RepositoryDetail(AppDbContext context) {
      _context = context;
    }

    public async Task<T> GetById(Guid id) {
      return await _context.Set<T>().FindAsync(id);
    }

    public async Task Insert(T model) {
      if(model is DetailTracking tracking) {
        bool IsId = true;
        if(tracking.Id == default)
          IsId = false;
        await _context.Set<T>().AddAsync(model);
        if(!IsId)
          tracking.Id = default;
      } else await _context.Set<T>().AddAsync(model);
      await _context.SaveChangesAsync();
    }

    public async Task Update(T model) {
      _context.Set<T>().Update(model);
      await _context.SaveChangesAsync();
      // Custom Active Backup
    }

    public async Task<bool> Delete(T model) {
      if(model == null)
        return false;
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

    public async Task<bool> Delete(Guid id) {
      return await Delete(await GetById(id));
    }

    public async Task Delete(List<Guid> models) {
      foreach(var item in models)
        await Delete(item);
    }

    public async Task Backup(T modelOld) {
      if(HelperService<T>.Backup(modelOld))
        await Insert(modelOld);
    }
  }
}