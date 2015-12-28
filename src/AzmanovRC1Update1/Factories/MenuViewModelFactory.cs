using Azmanov.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azmanov.Entities;
using Azmanov.Data;

namespace Azmanov.Factories
{
    public class MenuViewModelFactory : IMenuViewModelFactory
    {
        private AzmanovContext _context;

        public MenuViewModelFactory(AzmanovContext context)
        {
            _context = context;
        }
        public IEnumerable<MenuItemViewModel> Get(IEnumerable<MenuItemDetail> menuItemDetails)
        {
            List<MenuItemViewModel> menuItemViewModels = new List<MenuItemViewModel>();

            foreach (var item in menuItemDetails)
            {
                var menuItem = _context.MenuItems.First(p => p.MenuItemDetails.Any(p1=>p1.Id == item.Id));

                MenuItemViewModel menuItemViewModel = new MenuItemViewModel()
                {
                    ShortDisplay = item.ShortDisplay,
                    Controller = menuItem.Controller,
                    Action = menuItem.Action,
                    SubMenuItems = null
                };
                menuItemViewModels.Add(menuItemViewModel);
            }

            return menuItemViewModels;
        }
    }
}
