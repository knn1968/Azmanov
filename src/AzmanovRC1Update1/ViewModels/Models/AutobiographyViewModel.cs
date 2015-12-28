using Azmanov.Data.Interfaces;
using Azmanov.Data.Repositories;
using Azmanov.Factories;
using Azmanov.Factories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azmanov.ViewModels
{
    public class AutobiographyViewModel : BaseViewModel, IAutobiographyViewModel
    {
        private IAutobiographyDisplayViewModelFactory _AutobiographyDisplayViewModelFactory;
        public string ImageUrl { get; set; }
        public string Text { get; set; }
        public AutobiographyViewModel(
            ILanguageRepository languageRepository,
            ILanguageViewModelFactory languageViewModelFactory,
            IMenuRepository menuRepository,
            IMenuViewModelFactory menuViewModelFactory,
            IAutobiographyDisplayViewModelFactory AutobiographyDisplayViewModelFActory)
            : base(
                  languageRepository,
                  languageViewModelFactory,
                  menuRepository,
                  menuViewModelFactory)
        {
            _AutobiographyDisplayViewModelFactory = AutobiographyDisplayViewModelFActory;
        }

        public void PopulateAutobiographyData(string languageShortDisplay)
        {
            var AutobiographyDisplayViewModel = _AutobiographyDisplayViewModelFactory.Get(languageShortDisplay);

            Text = AutobiographyDisplayViewModel.Text;
            ImageUrl = AutobiographyDisplayViewModel.ImageUrl;
        }

        public override void Load(string languageShortDisplay)
        {
            PopulateAutobiographyData(languageShortDisplay);
            base.Load(languageShortDisplay);
        }
    }
}
