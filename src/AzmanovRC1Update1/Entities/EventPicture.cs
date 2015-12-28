using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azmanov.Entities
{
    public class EventPicture
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<EventPictureDetail> EventPictureDetail { get; set; }
    }
}
