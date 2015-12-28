using Azmanov.Dtos.Paging;
using Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Azmanov.ViewModels.Paging
{
    public class GalleryUpdateViewModel : IPageItem
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, enter a Thumbnail Url.")]
        public string ThumbnailUrl { get; set; }
        [Required(ErrorMessage = "Please, enter an Image Url.")]
        public string ImageUrl { get; set; }
        public int Order { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
        public DateTime ExpireDateTime { get; set; } = DateTime.UtcNow.AddYears(100);
        public ICollection<GalleryUpdateViewModelDetail> GalleryDetails { get; set; }
    }
}
