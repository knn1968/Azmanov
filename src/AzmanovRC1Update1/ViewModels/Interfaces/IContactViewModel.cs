using Azmanov.Controllers.Web;
using Azmanov.ViewModels;
using Azmanov.ViewModels.Models;

namespace Azmanov.ViewModels.Interfaces.ViewModels
{
    public interface IContactViewModel : IBaseViewModel
    {
        ContactFormViewModel FormInput { get; set; }
        bool RedirectToHome { get; set; }
        string ThankYouMessage { get; set; }
    }
}