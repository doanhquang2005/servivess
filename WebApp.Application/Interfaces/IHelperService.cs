using System;
using System.Threading.Tasks;

namespace WebApp.Application.Interfaces {
  public interface IHelperService {
    Task<int> CountDayDoing(DateTime dateStart, DateTime dateEnd);

    Task<int> CountDayDoing(int countDateStart, int countDateEnd);

    Task<int> CountDayOfMouth(int mouthCount);
  }
}