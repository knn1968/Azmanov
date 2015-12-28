using System.Collections.Generic;

namespace Azmanov.ViewModels
{
    public interface IBaseViewModel
    {
        LanguageViewModel CurrentLanguageDetails { get; }
        string CurrentLanguageShortDisplayInEnglish { get; set; }
        IEnumerable<LanguageViewModel> LanguagesList { get; set; }
        void PopulateLanguageData(string language);
        void PopulateMenuData(string language);
        void Load(string language);
    }
}