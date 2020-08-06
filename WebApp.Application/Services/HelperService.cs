using HT.Extentions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Application.Interfaces;
using WebApp.Data.DBContext;

namespace WebApp.Application.Services {

  public class HelperService : IHelperService {
    private readonly AppDbContext _context;

    public HelperService(AppDbContext context) {
      _context = context;
    }

    public async Task<int> CountDayOfMouth(int mouthCount) {
      DateTime dateStart = mouthCount.ToMonthStart();
      DateTime dateEnd = mouthCount.ToMonthEnd();
      return await CountDayDoing(dateStart, dateEnd);
    }

    public async Task<int> CountDayDoing(DateTime dateStart, DateTime dateEnd) {
      return await CountDayDoing(dateStart, dateEnd, dateStart.ToDayCount(), dateEnd.ToDayCount());
    }

    public async Task<int> CountDayDoing(int countDateStart, int countDateEnd) {
      return await CountDayDoing(countDateStart.ToDateTime(), countDateEnd.ToDateTime(), countDateStart, countDateEnd);
    }

    private async Task<int> CountDayDoing(DateTime dateStart, DateTime dateEnd, int countDateStart, int countDateEnd) {
      return countDateEnd - countDateStart + 1 - dateStart.CountDays(dateEnd, DayOfWeek.Sunday);
    }
  }
}