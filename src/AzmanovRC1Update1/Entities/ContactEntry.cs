using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azmanov.Entities
{
    public class ContactEntry
    {
        public int Id { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
