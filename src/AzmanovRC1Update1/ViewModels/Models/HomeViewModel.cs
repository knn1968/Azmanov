using Azmanov.Data.Interfaces;
using Azmanov.Data.Repositories;
using Azmanov.Entities;
using Azmanov.Factories;
using AzmanovRC1Update1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azmanov.ViewModels
{
    public class HomeViewModel : BaseViewModel, IHomeViewModel
    {
        public string HomeImageUrl { get; set; }
        public HomeViewModel(ILanguageRepository languageRepository,
            ILanguageViewModelFactory languageViewModelFactory,
            IMenuRepository menuRepository,
            IMenuViewModelFactory menuViewModelFactory)
            : base(
                  languageRepository,
                  languageViewModelFactory,
                  menuRepository,
                  menuViewModelFactory)

        {
           HomeImageUrl = Startup.Configuration["HomePage:ImageUrl"];
        }

    }
}
