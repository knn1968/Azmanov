using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azmanov.Entities
{
    public class EventDetail
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
