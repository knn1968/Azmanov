using System.ComponentModel.DataAnnotations;

namespace Azmanov.ViewModels.Paging
{
    public class EventUpdateViewModelPictureDetail
    {
        public int Id { get; set; }
        [Required]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "The language code should be 2 characters long.")]
        public string LanguageShortDisplay { get; set; }
        [Required(ErrorMessage = "Please, enter a Name for this picture.")]
        public string Name { get; set; }
    }
}