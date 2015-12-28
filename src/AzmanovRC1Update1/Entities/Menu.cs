using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azmanov.Entities
{
    public class Menu
    {
        public int Id { get; set; }
        public string ShortDisplay { get; set; }
        public string LongDisplay { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime ExpireDateTime { get; set; }
        public ICollection<MenuItem> MenuItems { get; set; }

    }
}
