using Azmanov.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Azmanov.Entities;
using Microsoft.Data.Entity;

namespace Azmanov.Data.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private AzmanovContext _context;

        public MenuRepository(AzmanovContext context)
        {
            _context = context;
        }

        public IEnumerable<MenuItemDetail> Get(string menuShortDisplay, string languageShortDisplay)
        {
            List<MenuItemDetail> menuItemDetails = new List<MenuItemDetail>();

            var language = _context.Languages.First(p => p.ShortDisplay == languageShortDisplay);

            var menu = 
                _context.Menus
                .Include(p=>p.MenuItems)
                //.Include(p=>p.MenuItems.Select(p1=>p1.MenuItemDetails))
                .First(p => p.ShortDisplay == menuShortDisplay);

            foreach(var menuItem in menu.MenuItems.OrderBy(p=>p.Order))
            {
                var v = _context.MenuItems.Include(p => p.MenuItemDetails).First(p => p == menuItem);
                menuItemDetails.Add(v.MenuItemDetails.First(p => p.InLanguageId == language.Id));
            }

            return menuItemDetails;
        }
    }
}
