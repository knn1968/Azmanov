using System;
using System.Collections.Generic;

namespace Azmanov.Entities
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string ShortDisplay { get; set; }
        public string LongDisplay { get; set; }
        public string Description { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Attribute { get; set; }
        public int Order { get; set; }
        public int ParentMenuItemId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime ExpireDateTime { get; set; }
        public ICollection<MenuItemDetail> MenuItemDetails { get; set; }

    }
}