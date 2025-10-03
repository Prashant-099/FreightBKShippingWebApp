namespace FreightBKShippingWebApp.Model
{
    
        public class PagedResponseDto<T>
        {
            public PaginationInfo Pagination { get; set; }
            public List<T> Data { get; set; } = new();
        }

        public class PaginationInfo
        {
            public int Page { get; set; }
            public int PageSize { get; set; }
            public int TotalRecords { get; set; }
            public int TotalPages { get; set; }
       }
    

}
