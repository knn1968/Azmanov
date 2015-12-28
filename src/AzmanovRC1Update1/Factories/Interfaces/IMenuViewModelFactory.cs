using Azmanov.Entities;
using System.Collections.Generic;

namespace Azmanov.ViewModels
{
    public interface IMenuViewModelFactory
    {
        IEnumerable<MenuItemViewModel> Get(IEnumerable<MenuItemDetail> menuItemDetails);
    }
}