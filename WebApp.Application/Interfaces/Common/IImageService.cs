using HT.Extentions.Enums;
using HT.Repositories;
using System.Threading.Tasks;
using WebApp.Models.Base;
using WebApp.Models.Entities;
using WebApp.Models.Resquests;

namespace WebApp.Application.Interfaces {
  public interface IImageService : IRepositoryActive<CM_Image> {
    Task<PageResult<CM_Image>> GetAllPaging(CM_CommonRequest request);

    Task<CM_Image> GetByPath(string path);

    Task<Response> Update(CM_Image model, int tableId);

    Task<Response> CheckModel(CM_Image model, Actives active);
  }
}