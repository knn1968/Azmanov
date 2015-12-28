using System.Collections.Generic;

namespace Core.Paging
{
    public class PagingResult<T> where T : class, IPageItem, new()
    {
        public int CurrentPage { get; set; }
        public IEnumerable<T> CurrentPageItems { get; set; }
        public IEnumerable<int> CurrentPageGroupPageNumbers { get; set; }
        public int? PreviousPage { get; set; }
        public int? NextPage { get; set; }
    }
}