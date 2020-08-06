using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Application.Repositories;
using WebApp.Models.Base;
using WebApp.Models.Entities;
using WebApp.Models.Resquests;
using WebApp.Models.ViewModels;

namespace WebApp.Application.Interfaces {
  public interface ICommonService {
    Task GetAllOptionSelect(CommonOptionSelect model);

    Task<string> GetNameById(long id, int tableId);

    Task<List<CommonListName>> GetListName(List<long> models, int type);
  }
}