using HT.Extentions.Enums;
using HT.Repositories;
using System.Threading.Tasks;
using WebApp.Models.Base;
using WebApp.Models.Entities;
using WebApp.Models.Resquests;

namespace WebApp.Application.Interfaces {
  public interface IPermissionService : IRepositoryActive<CM_Permission> {
    Task<PageResult<CM_Permission>> GetAllPaging(CM_PermissionRequest request);

    Task<Response> Update(CM_Permission model, int tableId);

    Task InsertDelete(CM_Permission model, int tableId);

    Task<Response> CheckModel(CM_Permission model, Actives active);
  }
}