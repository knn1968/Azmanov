using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azmanov.Entities
{
    public class MediaEvent
    {
        public int Id { get; set; }
        public DateTime EventDateTime { get; set; }
        public int Order { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime ExpireDateTime { get; set; }
        public ICollection<MediaEventDetail> MediaEventDetails { get; set; }
        public DateTime EventDate { get; set; }
    }
}
