using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azmanov.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime ExpireDateTime { get; set; }
        public int Order { get; set; }
        public ICollection<EventDetail> EventDetails { get; set; }
        public ICollection<EventPicture> EventPictures { get; set; }
    }
}
