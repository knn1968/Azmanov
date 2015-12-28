using System.Collections.Generic;

namespace Azmanov.ViewModels
{
    public class MenuItemViewModel
    {
        public string ShortDisplay { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public IEnumerable<MenuItemViewModel> SubMenuItems { get; set; }
    }
}