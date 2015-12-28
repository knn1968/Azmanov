using Azmanov.Data.Interfaces;
using Azmanov.Data.Repositories;
using Azmanov.Entities;
using Azmanov.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azmanov.ViewModels
{
    public class BaseViewModel : IBaseViewModel
    {
        public IEnumerable<LanguageViewModel> LanguagesList { get; set; }
        public IEnumerable<MenuItemViewModel> MenuItemsList { get; set; }
        public IEnumerable<MenuItemViewModel> Menu { get; set; }
        public string CurrentLanguageShortDisplayInEnglish { get; set; }
        public LanguageViewModel CurrentLanguageDetails { get; internal set; }

        private ILanguageRepository _languageRepository;
        private ILanguageViewModelFactory _languageViewModelFactory;
        private IMenuRepository _menuRepository;
        private IMenuViewModelFactory _menuViewModelFactory;

        public BaseViewModel(
            ILanguageRepository languageRepository, 
            ILanguageViewModelFactory languageViewModelFactory, 
            IMenuRepository menuRepository,
            IMenuViewModelFactory menuViewModelFactory)
        {
            _languageRepository = languageRepository;
            _languageViewModelFactory = languageViewModelFactory;
            _menuRepository = menuRepository;
            _menuViewModelFactory = menuViewModelFactory;
        }

        public void PopulateLanguageData(string language)
        {
            CurrentLanguageShortDisplayInEnglish = language;
            CurrentLanguageDetails = _languageViewModelFactory.Get(_languageRepository.GetLanguageDetailsInCurrentLanguage(CurrentLanguageShortDisplayInEnglish));
            LanguagesList = _languageViewModelFactory.Get(_languageRepository.GetLanguageDetails(language));

        }
        public void PopulateMenuData(string language)
        {
            MenuItemsList = _menuViewModelFactory.Get( _menuRepository.Get("main", language));
        }

        public virtual void Load(string languageShortDisplay)
        {
            PopulateLanguageData(languageShortDisplay);
            PopulateMenuData(languageShortDisplay);
        }
    }
}
