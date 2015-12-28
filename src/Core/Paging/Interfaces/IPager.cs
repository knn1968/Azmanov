using System.Collections.Generic;

namespace Core.Paging
{
    public interface IPager<TInput, TOutput>
        where TInput : class, new()
        where TOutput : class, IPageItem, new()
    {
        PagingResult<TOutput> GetPage(int page, string languageShortDisplay) ;
    }
}