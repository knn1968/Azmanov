using Azmanov.Controllers.Web;
using Azmanov.Data.Interfaces;
using Azmanov.Data.Repositories;
using Azmanov.Factories;
using Azmanov.ViewModels;
using Azmanov.ViewModels.Interfaces.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;


namespace Azmanov.ViewModels.Models
{
    public class ContactViewModel : BaseViewModel, IContactViewModel
    {
        public ContactFormViewModel FormInput { get; set; }

        public bool RedirectToHome { get; set; }

        public string ThankYouMessage { get; set; }

        public ContactViewModel(
            ILanguageRepository languageRepository,
            ILanguageViewModelFactory languageViewModelFactory,
            IMenuRepository menuRepository,
            IMenuViewModelFactory menuViewModelFactory)
            : base(
                  languageRepository,
                  languageViewModelFactory,
                  menuRepository,
                  menuViewModelFactory)
        {
            FormInput = new ContactFormViewModel();
        }
    }
}
