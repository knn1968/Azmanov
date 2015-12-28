using System.Collections.Generic;
using Azmanov.Entities;
using Azmanov.ViewModels;

namespace Azmanov.Factories
{
    public interface ILanguageViewModelFactory
    {
        LanguageViewModel Get(LanguageDetail language);
        List<LanguageViewModel> Get(IEnumerable<LanguageDetail> languages);
    }
}