using Microsoft.EntityFrameworkCore; // Bị ngay chỗ này
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models.Base {

  public class PageResult<T> : List<T> {
    public int CurrentPage { get; private set; }
    public int PageSize { get; set; }
    public int RowCount { get; private set; }
    public string PagePath { get; set; }
    public string Path { get; set; }
    public long Id { get; set; }
    public PageResult() {
    }

    public PageResult(List<T> items, int count, int pageIndex, int pageSize) {
      CurrentPage = pageIndex;
      //TotalPages = (int)Math.Ceiling(count / (double)pageSize);
      PageSize = pageSize;
      RowCount = count;
      AddRange(items);
    }

    //public bool HasPreviousPage {
    //  get {
    //    return (CurrentPage > 1);
    //  }
    //}

    //public bool HasNextPage {
    //  get {
    //    return (CurrentPage < TotalPages);
    //  }
    //}

    public int FirstRowOnPage {
      get {
        return (CurrentPage - 1) * PageSize + 1;
      }
    }

    public static PageResult<T> Create(IQueryable<T> source, int pageIndex, int pageSize) {
      if(pageIndex < 1)
        return new PageResult<T>(null, 0, 0, pageSize);
      var count = source.Count();
      var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
      if(items.Count == 0 && pageIndex > 1)
        pageIndex = 0;
      return new PageResult<T>(items, count, pageIndex, pageSize);
    }

    public static async Task<PageResult<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize) {
      if(pageIndex < 1)
        return new PageResult<T>(null, 0, 0, pageSize);
      var count = await source.CountAsync();
      var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
      if(items.Count == 0 && pageIndex > 1)
        pageIndex = 0;
      return new PageResult<T>(items, count, pageIndex, pageSize);
    }

    public static PageResult<T> Sort(PageResult<T> source, IEnumerable<T> keySelector) {
      return new PageResult<T>(keySelector.ToList(), source.Count, source.CurrentPage, source.PageSize);
    }
  }
}