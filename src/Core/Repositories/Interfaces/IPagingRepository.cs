using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public interface IPagingRepository<out T> : IDisposable where T : class, new()
    {
        IQueryable<T> GetPage(string languageShortDisplay, int startIndex, int itemCount);
        IQueryable<T> GetPage(int startIndex, int itemCount);
        int GetCount();
    }
}