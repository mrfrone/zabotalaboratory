namespace zabotalaboratory.Common.Pagination.Datamodel
{
    public class ZabotaPager<TResult>
    {
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }

        public bool HasPreviousPage { get; set; }

        public bool HasNextPage { get; set; }

        public TResult PageResult { get; set; }
    }
}
