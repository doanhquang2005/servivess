using HT.Extentions;
using HT.Extentions.Enums;
using HT.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Application.Interfaces;
using WebApp.Data.Entity.Billing;
using WebApp.Models.Entities;

namespace WebApp.Application.Repositories {

  public abstract class BillingRepository<T> : IRepository<T> where T : class {
    private readonly BillingDbContext _context;
    public BillingRepository(BillingDbContext context) {
      _context = context;
    }

    public async Task<T> GetById(long id) {
      return await _context.Set<T>().FindAsync(id);
    }

    public async Task Insert(T model) {
      await _context.Set<T>().AddAsync(model);
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
      if(model is Tracking tracking)
        tracking.Status = Status.Delete;
      else if(model is DetailTracking detailTracking)
        detailTracking.Status = Status.Delete;
      else if(model is ITracking<long> itracking)
        itracking.Status = Status.Delete;
      _context.Set<T>().Update(model);
      await _context.SaveChangesAsync();
      return true;
    }

    public virtual async Task<bool> Delete(long id) {
      return await Delete(await GetById(id));
    }

    public async Task Delete(List<long> models) {
      foreach(var item in models)
        await Delete(item);
    }

    public async Task Backup(T modelOld) {
      if(HelperService<T>.Backup(modelOld))
        await Insert(modelOld);
    }
  }
}