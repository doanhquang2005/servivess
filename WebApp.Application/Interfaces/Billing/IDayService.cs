using HT.Extentions.Enums;
using HT.Repositories;
using System.Threading.Tasks;
using WebApp.Data.Entity.Billing;
using WebApp.Models.Base;
using WebApp.Models.Resquests;

namespace WebApp.Application.Interfaces {
  public interface IDayService : IRepository<BiDays> {
    Task<PageResult<BiDays>> GetAllPaging(CM_CommonRequest request);

    Task<Response> Update(BiDays model, int tableId);

    Task<Response> CheckModel(BiDays model, Actives active);
  }
}