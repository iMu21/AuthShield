using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthShield.Persistance.Paging
{
    public class PagedList<T> : IPagedList<T> where T : class
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public int TotalPages { get; set; }

        /// <summary>
        /// Useful when the don't start from 0 index
        /// </summary>
        public int IndexFrom { get; set; }

        public IList<T> Items { get; set; }

        public bool HasPreviousPage => ((PageIndex - IndexFrom) > 0);
        public bool HasNextPage => (TotalPages > (PageIndex - IndexFrom) + 1);

        internal PagedList(IEnumerable<T> source, int pageIndex, int pageSize, int indexFrom)
        {

            if (source is IQueryable<T> queryable)
            {
                PageIndex = pageIndex;
                PageSize = pageSize;
                IndexFrom = indexFrom;

                TotalCount = queryable.Count();
                TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);

                Items = queryable.Skip((PageIndex - IndexFrom) * PageSize).Take(PageSize).ToList();
            }
            else
            {
                PageIndex = pageIndex;
                PageSize = pageSize;
                IndexFrom = indexFrom;

                TotalCount = source.Count();
                TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);

                Items = source.Skip((PageIndex - IndexFrom) * PageSize).Take(PageSize).ToList();
            }
        }
   
        internal PagedList() => Items = new T[0];
    
    }
}
