using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azmanov.Entities
{
    public class Gallery
    {
        public int Id { get; set; }
        public string ThumbnailUrl { get; set; }
        public string ImageUrl { get; set; }
        public int Order { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime ExpireDateTime { get; set; }
        public ICollection<GalleryDetail> GalleryDetails { get; set; }
    }
}
