using System;
using System.Collections.Generic; 

namespace Common.Pagination
{
    public class PaginatedResponse<T> where T : class
    {
        public IEnumerable<T> Items { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public int TotalPages => (int)Math.Ceiling(this.Count / (double)this.PageSize);
    }
}
