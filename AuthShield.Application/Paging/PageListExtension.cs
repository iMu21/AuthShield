using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthShield.Persistance.Paging
{
    public static class PageListExtension
    {
        public static IPagedList<T> ToPagedList<T>(this IEnumerable<T> source,
            int pageIndex, int pageSize, int indexFrom = 0)
            where T : class

        {
            var count = source.Count();

            var Items = source.Skip((pageIndex - indexFrom) * pageSize)
                .Take(pageSize)
                .ToList();

            var pagedList = new PagedList<T>()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                IndexFrom = indexFrom,
                TotalCount = count,
                TotalPages = (int)Math.Ceiling(count / (double)pageSize),
                Items = Items
            };

            return pagedList;
        }

        public static IPagedList<T> ToPagedList<T>(this IQueryable<T> source,
           int pageIndex, int pageSize, int indexFrom = 0)
           where T : class

        {

            var count = source.Count();

            var Items = source.Skip((pageIndex - indexFrom) * pageSize)
                .Take(pageSize)
                .ToList();

            var pagedList = new PagedList<T>()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                IndexFrom = indexFrom,
                TotalCount = count,
                TotalPages = (int)Math.Ceiling(count / (double)pageSize),
                Items = Items
            };

            return pagedList;
        }
        public static async Task<IPagedList<T>> ToPagedListAsync<T>(this IQueryable<T> source,
            int pageIndex, int pageSize, int indexFrom = 0, CancellationToken cancellationToken = default)
            where T : class

        {

            var count = await source.CountAsync(cancellationToken)
                .ConfigureAwait(false);

            var Items = await source.Skip((pageIndex - indexFrom) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            var pagedList = new PagedList<T>()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                IndexFrom = indexFrom,
                TotalCount = count,
                TotalPages = (int)Math.Ceiling(count / (double)pageSize),
                Items = Items
            };

            return pagedList;
        }
    }
}
