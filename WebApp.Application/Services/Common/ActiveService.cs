using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WebApp.Application.Interfaces;
using WebApp.Data.DBContext;
using WebApp.Models.Base;
using WebApp.Models.Entities;
using WebApp.Models.Helpers;
using WebApp.Models.Resquests;

namespace WebApp.Application.Services {

  public class ActiveService<T> : IActiveService<T> {
    private readonly AppDbContext _context;
    public ActiveService(AppDbContext context) => _context = context;

    public async Task<PageResult<CM_Active>> GetAllPaging(CM_ActiveRequest request) {
      IQueryable<CM_Active> query = _context.Actives;
      if(request.UserId > 0)
        query = query.Where(d => d.UserCreated == request.UserId);
      //query = query.Where(d => d.Status > 0);
      //query = query.OrderByDescending(d => d.Id);
      return await PageResult<CM_Active>.CreateAsync(query.AsNoTracking(), request.Page, request.PageSize);
    }

    private async Task<string> GetNameById(long? id, int tableId) {
      if(id == null)
        return null;
      if(tableId == 0 || tableId == Tables.ED_Class) {
        var model = await _context.Classes.Where(d => d.Id == id).FirstOrDefaultAsync();
        if(model != null)
          return model.ClassName;
      }
      return null;
    }

    public async Task Insert(CM_Active model) {
      model.Title = await GetNameById(model.SourceId, model.TableId);
      await _context.Actives.AddAsync(model);
      await _context.SaveChangesAsync();
    }

    public async Task InsertEdit(T modelOld, T modelNew, string firstActive, int tableId) {
      if(tableId == 0)
        return;
      CM_Active active = new CM_Active { TableId = tableId };
      active.Description = firstActive;
      var properties = TypeDescriptor.GetProperties(typeof(T));
      foreach(PropertyDescriptor property in properties) {
        var oldValue = property.GetValue(modelOld)?.ToString();
        var newValue = property.GetValue(modelNew)?.ToString();
        if(property.Name == "Id") {
          if(property.PropertyType.Name == "Int64")
            active.SourceId = long.Parse(oldValue);
          else active.DetailSourceId = Guid.Parse(oldValue);
        }
        if(oldValue != newValue) {
          MemberInfo pro = typeof(T).GetProperty(property.Name);
          string displayName = null;
          if(pro.GetCustomAttribute(typeof(DisplayAttribute)) is DisplayAttribute attribute)
            displayName = attribute.Name;
          if(property.PropertyType.Name == "Int64") {
            oldValue = oldValue != null ? await GetNameById(long.Parse(oldValue), 0) : "Rỗng";
            newValue = newValue != null ? await GetNameById(long.Parse(newValue), 0) : "Rỗng";
          } else if(property.PropertyType.Name == "DateTime") {
            string emptyTime = " 12:00:00 SA";
            if(oldValue.EndsWith(emptyTime))
              oldValue = oldValue.Substring(0, oldValue.Length - emptyTime.Length);
            if(newValue.EndsWith(emptyTime))
              newValue = newValue.Substring(0, newValue.Length - emptyTime.Length);
          }
          active.Description += "<li>" + (displayName ?? property.DisplayName) + ": " + oldValue + " &rArr; " + newValue + "</li>";
        }
      }
      if(!string.IsNullOrEmpty(active.Description))
        active.Description = "<ul class=\"n-active-list\">" + active.Description + "</ul>";
      await Insert(active);
    }
  }
}