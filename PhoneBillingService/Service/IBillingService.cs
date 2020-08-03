using PhoneBillingService.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBillingService.Service {
  public interface IBillingService {
    Task<List<BI_Mobile>> GetMobiles();

    Task<List<BI_Landline>> GetLandlines();

    Task<BI_Landline> GetLandlineByPrefixOld(string prefixOld);

    Task<List<BI_Day>> GetDays();

    Task<BI_Group> GetGroupByRange(long value);

    Task<BI_Group> GetGroupByPrefix(string value, int type1);

    Task<BI_Group> GetGroupByInfix(string value);

    Task InsertFile(BI_File model);

    Task InsertDataAarenet(BI_DataAarenet model);

    Task InsertRecord(BI_Record model);

    Task Init();
  }
}