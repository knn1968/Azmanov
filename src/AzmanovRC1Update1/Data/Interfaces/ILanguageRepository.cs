using System.Collections.Generic;
using Azmanov.Entities;

namespace Azmanov.Data.Interfaces
{
    public interface ILanguageRepository
    {
        IEnumerable<LanguageDetail> GetLanguageDetails(string languageShortDisplay);
        LanguageDetail GetLanguageDetailsInCurrentLanguage(string languageShortDisplay);
        Language GetDefaultLanguage();
    }
}