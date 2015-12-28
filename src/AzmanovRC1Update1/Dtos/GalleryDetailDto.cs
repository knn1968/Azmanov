using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azmanov.Dtos
{
    public class GalleryDetailDto
    {
        public string ImageUrl { get; internal set; }
        public string Name { get; set; }
        public string ThumbnailUrl { get; set; }
    }
}
