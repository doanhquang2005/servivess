using HT.Extentions.Enums;
using HT.Repositories;
using System.Threading.Tasks;
using WebApp.Models.Base;
using WebApp.Models.Entities;
using WebApp.Models.Resquests;

namespace WebApp.Application.Interfaces {
  public interface ITemplateService : IRepositoryActive<ED_Class> {
    Task<PageResult<ED_Class>> GetAllPaging(ED_ClassRequest request);

    Task<Response> Update(ED_Class model, int tableId);

    Task<Response> CheckModel(ED_Class model, Actives active);
  }
}