using System.Threading.Tasks;
using WebApp.Models.Base;
using WebApp.Models.Entities;
using WebApp.Models.Resquests;

namespace WebApp.Application.Interfaces {
  public interface IActiveService<T> {
    Task<PageResult<CM_Active>> GetAllPaging(CM_ActiveRequest request);

    Task Insert(CM_Active model);

    Task InsertEdit(T modelOld, T modelNew, string firstActive, int tableId);
  }
}