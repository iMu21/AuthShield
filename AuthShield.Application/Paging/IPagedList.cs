using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthShield.Persistance.Paging
{
    public interface IPagedList<T> where T : class
    {
        int PageIndex {  get; }
        int PageSize {  get; }
        int TotalCount { get; }

        int TotalPages { get; }

        int IndexFrom { get; }

        IList<T> Items { get; }

        bool HasPreviousPage { get; }
        bool HasNextPage { get; }

    }
}
