using System.ComponentModel.DataAnnotations;

namespace Azmanov.ViewModels.Paging
{
    public class EventUpdateViewModelDetail
    {
        public int Id { get; set; }
        [Required]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "The language code should be 2 characters long.")]
        public string LanguageShortDisplay { get; set; }
        [Required(ErrorMessage = "Please, enter a title for this event.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please, enter a body for this event.")]
        public string Body { get; set; }

    }
}