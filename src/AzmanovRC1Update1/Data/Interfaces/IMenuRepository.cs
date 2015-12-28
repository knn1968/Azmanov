using Azmanov.Entities;
using System.Collections.Generic;

namespace Azmanov.Data.Interfaces
{
    public interface IMenuRepository
    {
        IEnumerable<MenuItemDetail> Get(string menuShortDisplay, string languageShortDisplay);
    }
}
