using System.ComponentModel.DataAnnotations;

namespace Azmanov.ViewModels.Models
{
    public class ContactFormViewModel
    {
        [Required(ErrorMessage = "Please, enter a name.")]
        [StringLength(maximumLength: 255, MinimumLength = 5, ErrorMessage = "Name should be between 5 and 255 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please, provide an email.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please, enter a message.")]
        [StringLength(1024, MinimumLength = 5, ErrorMessage = "Message should be between 5 and 255 characters.")]
        public string Message { get; set; }

    }
}