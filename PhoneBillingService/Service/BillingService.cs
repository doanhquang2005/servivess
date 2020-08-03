using Microsoft.EntityFrameworkCore;
using PhoneBillingService.Data;
using PhoneBillingService.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBillingService.Service {

  public class BillingService : IBillingService {
    private readonly AppDbContext context;
    public BillingService(AppDbContext context) {
      this.context = context;
    }

    public async Task<List<BI_Mobile>> GetMobiles() {
      return await context.Mobiles.AsNoTracking().ToListAsync();
    }

    public async Task<List<BI_Landline>> GetLandlines() {
      return await context.Landlines.AsNoTracking().ToListAsync();
    }

    public async Task<BI_Landline> GetLandlineByPrefixOld(string prefixOld) {
      return await context.Landlines.Where(d => d.PrefixOld == prefixOld).FirstOrDefaultAsync();
    }

    public async Task<List<BI_Day>> GetDays() {
      return await context.Days.AsNoTracking().ToListAsync();
    }

    public async Task<BI_Group> GetGroupByRange(long value) {
      return await context.Groups.Where(d => d.FromNumber <= value && d.EndNumber >= value && d.Status > 0)
        .FirstOrDefaultAsync();
    }

    public async Task<BI_Group> GetGroupByPrefix(string value, int type1) {
      var query = context.Groups.Where(d => d.Prefix == value && d.Status > 0);
      if(type1 > 0) query = query.Where(d => d.Type1 == type1);
      return await query.OrderByDescending(d => d.Id).FirstOrDefaultAsync();
    }

    public async Task<BI_Group> GetGroupByInfix(string value) {
      return await context.Groups.Where(d => d.Infix == value && d.Status > 0).FirstOrDefaultAsync();
    }

    public async Task InsertFile(BI_File model) {
      await context.Files.AddAsync(model);
      await context.SaveChangesAsync();
    }

    public async Task InsertDataAarenet(BI_DataAarenet model) {
      await context.DataAarenets.AddAsync(model);
      await context.SaveChangesAsync();
    }

    public async Task InsertRecord(BI_Record model) {
      await context.Records.AddAsync(model);
      await context.SaveChangesAsync();
    }

    public async Task Init() {
      var listMobiles = new List<BI_Mobile>();
      listMobiles.Add(new BI_Mobile { PrefixNew = "086", PrefixOld = "086", MobileName = "Viettel" });
      listMobiles.Add(new BI_Mobile { PrefixNew = "096", PrefixOld = "096", MobileName = "Viettel" });
      listMobiles.Add(new BI_Mobile { PrefixNew = "097", PrefixOld = "097", MobileName = "Viettel" });
      listMobiles.Add(new BI_Mobile { PrefixNew = "098", PrefixOld = "098", MobileName = "Viettel" });
      listMobiles.Add(new BI_Mobile { PrefixNew = "032", PrefixOld = "0162", MobileName = "Viettel" });
      listMobiles.Add(new BI_Mobile { PrefixNew = "033", PrefixOld = "0163", MobileName = "Viettel" });
      listMobiles.Add(new BI_Mobile { PrefixNew = "034", PrefixOld = "0164", MobileName = "Viettel" });
      listMobiles.Add(new BI_Mobile { PrefixNew = "035", PrefixOld = "0165", MobileName = "Viettel" });
      listMobiles.Add(new BI_Mobile { PrefixNew = "036", PrefixOld = "0166", MobileName = "Viettel" });
      listMobiles.Add(new BI_Mobile { PrefixNew = "037", PrefixOld = "0167", MobileName = "Viettel" });
      listMobiles.Add(new BI_Mobile { PrefixNew = "038", PrefixOld = "0168", MobileName = "Viettel" });
      listMobiles.Add(new BI_Mobile { PrefixNew = "039", PrefixOld = "0169", MobileName = "Viettel" });
      listMobiles.Add(new BI_Mobile { PrefixNew = "088", PrefixOld = "088", MobileName = "Vinaphone" });
      listMobiles.Add(new BI_Mobile { PrefixNew = "091", PrefixOld = "091", MobileName = "Vinaphone" });
      listMobiles.Add(new BI_Mobile { PrefixNew = "094", PrefixOld = "094", MobileName = "Vinaphone" });
      listMobiles.Add(new BI_Mobile { PrefixNew = "083", PrefixOld = "0123", MobileName = "Vinaphone" });
      listMobiles.Add(new BI_Mobile { PrefixNew = "084", PrefixOld = "0124", MobileName = "Vinaphone" });
      listMobiles.Add(new BI_Mobile { PrefixNew = "085", PrefixOld = "0125", MobileName = "Vinaphone" });
      listMobiles.Add(new BI_Mobile { PrefixNew = "081", PrefixOld = "0127", MobileName = "Vinaphone" });
      listMobiles.Add(new BI_Mobile { PrefixNew = "082", PrefixOld = "0129", MobileName = "Vinaphone" });
      listMobiles.Add(new BI_Mobile { PrefixNew = "089", PrefixOld = "089", MobileName = "Mobifone" });
      listMobiles.Add(new BI_Mobile { PrefixNew = "090", PrefixOld = "090", MobileName = "Mobifone" });
      listMobiles.Add(new BI_Mobile { PrefixNew = "093", PrefixOld = "093", MobileName = "Mobifone" });
      listMobiles.Add(new BI_Mobile { PrefixNew = "070", PrefixOld = "0120", MobileName = "Mobifone" });
      listMobiles.Add(new BI_Mobile { PrefixNew = "079", PrefixOld = "0121", MobileName = "Mobifone" });
      listMobiles.Add(new BI_Mobile { PrefixNew = "077", PrefixOld = "0122", MobileName = "Mobifone" });
      listMobiles.Add(new BI_Mobile { PrefixNew = "076", PrefixOld = "0126", MobileName = "Mobifone" });
      listMobiles.Add(new BI_Mobile { PrefixNew = "078", PrefixOld = "0128", MobileName = "Mobifone" });
      listMobiles.Add(new BI_Mobile { PrefixNew = "092", PrefixOld = "092", MobileName = "Vietnamobile" });
      listMobiles.Add(new BI_Mobile { PrefixNew = "056", PrefixOld = "056", MobileName = "Vietnamobile" });
      listMobiles.Add(new BI_Mobile { PrefixNew = "052", PrefixOld = "052", MobileName = "Vietnamobile" });
      listMobiles.Add(new BI_Mobile { PrefixNew = "058", PrefixOld = "058", MobileName = "Vietnamobile" });
      listMobiles.Add(new BI_Mobile { PrefixNew = "099", PrefixOld = "099", MobileName = "Gmobile" });
      listMobiles.Add(new BI_Mobile { PrefixNew = "059", PrefixOld = "0199", MobileName = "Gmobile" });
      var groupMobile = new BI_Group {
        Type1 = Helper.mobileType1,
        Type2 = "DD",
        Duration1 = 6,
        Duration2 = 1,
        IsHot = true,
      };
      foreach(var item in listMobiles) {
        if(await context.Mobiles.Where(d => d.PrefixNew == item.PrefixNew).FirstOrDefaultAsync() == null) {
          await context.Mobiles.AddAsync(item);
          await context.SaveChangesAsync();
        }
        if(await context.Groups.Where(d => d.Prefix == item.PrefixNew).FirstOrDefaultAsync() == null) {
          if(item.PrefixNew == "096") {
            groupMobile.Price1 = 90.90;
            groupMobile.Price2 = 15.15;
            groupMobile.GroupName = "Di động EVN";
          } else {
            groupMobile.Price1 = 107.27;
            groupMobile.Price2 = 17.88;
            groupMobile.GroupName = item.MobileName + " " + item.PrefixNew;
          }
          groupMobile.Prefix = item.PrefixNew;
          groupMobile.Id = 0;
          context.Groups.Add(groupMobile);
          context.SaveChanges();
        }
      }

      var listLandlines = new List<BI_Landline>();
      listLandlines.Add(new BI_Landline { PrefixNew = "0296", PrefixOld = "076", LandlineName = "An Giang" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0254", PrefixOld = "064", LandlineName = "Bà Rịa - Vũng Tàu" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0209", PrefixOld = "0281", LandlineName = "Bắc Cạn" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0204", PrefixOld = "0240", LandlineName = "Bắc Giang" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0291", PrefixOld = "0781", LandlineName = "Bạc Liêu" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0222", PrefixOld = "0241", LandlineName = "Bắc Ninh" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0275", PrefixOld = "075", LandlineName = "Bến Tre" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0256", PrefixOld = "056", LandlineName = "Bình Định" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0274", PrefixOld = "0650", LandlineName = "Bình Dương" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0271", PrefixOld = "0651", LandlineName = "Bình Phước" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0252", PrefixOld = "062", LandlineName = "Bình Thuận" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0290", PrefixOld = "0780", LandlineName = "Cà Mau" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0292", PrefixOld = "0710", LandlineName = "Cần Thơ" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0206", PrefixOld = "026", LandlineName = "Cao Bằng" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0236", PrefixOld = "0511", LandlineName = "Đà Nẵng" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0262", PrefixOld = "0500", LandlineName = "Đắk Lắk" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0261", PrefixOld = "0501", LandlineName = "Đắk Nông" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0215", PrefixOld = "0230", LandlineName = "Điện Biên" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0251", PrefixOld = "061", LandlineName = "Đồng Nai" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0277", PrefixOld = "067", LandlineName = "Đồng Tháp" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0269", PrefixOld = "059", LandlineName = "Gia Lai" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0219", PrefixOld = "0219", LandlineName = "Hà Giang" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0226", PrefixOld = "0351", LandlineName = "Hà Nam" });
      listLandlines.Add(new BI_Landline { PrefixNew = "024", PrefixOld = "04", LandlineName = "Hà Nội" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0239", PrefixOld = "039", LandlineName = "Hà Tĩnh" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0220", PrefixOld = "0320", LandlineName = "Hải Dương" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0225", PrefixOld = "031", LandlineName = "Hải Phòng" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0293", PrefixOld = "0711", LandlineName = "Hậu Giang" });
      listLandlines.Add(new BI_Landline { PrefixNew = "028", PrefixOld = "08", LandlineName = "Hồ Chí Minh" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0218", PrefixOld = "0218", LandlineName = "Hòa Bình" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0221", PrefixOld = "0321", LandlineName = "Hưng Yên" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0258", PrefixOld = "08", LandlineName = "Khánh Hoà" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0297", PrefixOld = "077", LandlineName = "Kiên Giang" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0260", PrefixOld = "060", LandlineName = "Kon Tum" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0213", PrefixOld = "0231", LandlineName = "Lai Châu" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0263", PrefixOld = "063", LandlineName = "Lâm Đồng" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0205", PrefixOld = "025", LandlineName = "Lạng Sơn" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0214", PrefixOld = "020", LandlineName = "Lào Cai" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0272", PrefixOld = "072", LandlineName = "Long An" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0228", PrefixOld = "0350", LandlineName = "Nam Định" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0238", PrefixOld = "038", LandlineName = "Nghệ An" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0229", PrefixOld = "030", LandlineName = "Ninh Bình" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0259", PrefixOld = "068", LandlineName = "Ninh Thuận" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0210", PrefixOld = "0210", LandlineName = "Phú Thọ" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0257", PrefixOld = "057", LandlineName = "Phú Yên" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0232", PrefixOld = "052", LandlineName = "Quảng Bình" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0235", PrefixOld = "0510", LandlineName = "Quảng Nam" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0255", PrefixOld = "055", LandlineName = "Quảng Ngãi" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0203", PrefixOld = "033", LandlineName = "Quảng Ninh" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0233", PrefixOld = "053", LandlineName = "Quảng Trị" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0299", PrefixOld = "079", LandlineName = "Sóc Trăng" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0212", PrefixOld = "022", LandlineName = "Sơn La" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0276", PrefixOld = "066", LandlineName = "Tây Ninh" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0227", PrefixOld = "036", LandlineName = "Thái Bình" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0208", PrefixOld = "0280", LandlineName = "Thái Nguyên" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0237", PrefixOld = "037", LandlineName = "Thanh Hóa" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0234", PrefixOld = "054", LandlineName = "Thừa Thiên - Huế" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0273", PrefixOld = "073", LandlineName = "Tiền Giang" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0294", PrefixOld = "074", LandlineName = "Trà Vinh" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0207", PrefixOld = "027", LandlineName = "Tuyên Quang" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0270", PrefixOld = "070", LandlineName = "Vĩnh Long" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0211", PrefixOld = "0211", LandlineName = "Vĩnh Phúc" });
      listLandlines.Add(new BI_Landline { PrefixNew = "0216", PrefixOld = "029", LandlineName = "Yên Bái" });
      foreach(var item in listLandlines) {
        if(context.Landlines.Where(d => d.PrefixNew == item.PrefixNew).FirstOrDefault() == null) {
          context.Landlines.Add(item);
          context.SaveChanges();
        }
      }
    }
  }
}