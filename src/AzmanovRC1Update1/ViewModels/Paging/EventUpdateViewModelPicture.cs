using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Azmanov.ViewModels.Paging
{
    public class EventUpdateViewModelPicture
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, enter an Image Url.")]
        public string ImageUrl { get; set; }
        public ICollection<EventUpdateViewModelPictureDetail> EventPictureDetail { get; set; }

    }
}