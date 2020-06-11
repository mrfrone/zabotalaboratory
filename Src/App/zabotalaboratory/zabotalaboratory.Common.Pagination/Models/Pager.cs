using System;

namespace zabotalaboratory.Common.Pagination.Models
{
    public class Pager<TResult>
    {
        public int PageNumber { get; private set; }
        public int TotalPages { get; private set; }

        public Pager(int count, int pageNumber, int pageSize, TResult result)
        {
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            PageResult = result;
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageNumber > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageNumber < TotalPages);
            }
        }

        public TResult PageResult { get; private set; }
    }
}
