using Microsoft.EntityFrameworkCore;

namespace DistributedSystem.Contract.Abstractions.Shared
{
    public class PageResult<T>
    {
        public const int UpperPageSize = 100;
        public const int DefaultPageSize = 10;
        public const int DefaultPageIndex = 1;
        public PageResult(List<T> items, int pageIndex, int pageSize, int totalCount)
        {

        }
        public List<T> Items { get; private set; }
        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public bool HasNextPage => PageIndex * PageSize < TotalCount;
        public bool HasPreviousPage => PageSize > 1;
        public static async Task<PageResult<T>> CreateAsync(IQueryable<T> query, int pageIndex, int pageSize)
        {
            pageIndex = pageIndex <= 0 ? DefaultPageIndex : pageIndex;
            pageSize = pageSize <= 0 ? DefaultPageSize : pageSize > UpperPageSize ? UpperPageSize : pageSize;

            var totalCount = await query.CountAsync();
            var items = await query.Skip((pageIndex - 1)).Take(pageSize).ToListAsync();
            return new(items, pageIndex, pageSize, totalCount);
        }
        public static PageResult<T> Create(List<T> items, int pageIndex, int pageSize, int totalCount) => new(items, pageIndex, pageSize, totalCount);
    }
}
