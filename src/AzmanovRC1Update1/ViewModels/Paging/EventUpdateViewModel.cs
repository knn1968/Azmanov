using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Azmanov.ViewModels.Paging
{
    public class EventUpdateViewModel
    {
        public int Id { get; set; }
        [Required]
        public DateTime EventDate { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
        public DateTime ExpireDateTime { get; set; } = DateTime.UtcNow.AddYears(100);
        public int Order { get; set; }
        public ICollection<EventUpdateViewModelDetail> EventDetails { get; set; }
        public ICollection<EventUpdateViewModelPicture> EventPictures { get; set; }
    }
}
