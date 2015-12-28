using Azmanov.Data;
using Azmanov.Entities;
using Azmanov.ViewModels;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azmanov.Factories
{
    public class LanguageViewModelFactory : ILanguageViewModelFactory
    {
        private AzmanovContext _context;

        public LanguageViewModelFactory(AzmanovContext context)
        {
            _context = context;
        }
        public List<LanguageViewModel> Get(IEnumerable<LanguageDetail> languages)
        {
            var languageLiewModels = new List<LanguageViewModel>();

            foreach (var item in languages)
            {
                languageLiewModels.Add(Get(item));
            }

            return languageLiewModels;
        }
        public LanguageViewModel Get(LanguageDetail languageDetail)
        {
            var language = 
                _context.Languages
                    .Include(p => p.LanguageDetails)
                    .First(p => p.LanguageDetails.Any(p1=>p1.Id == languageDetail.Id));

            return new LanguageViewModel()
            {
                ShortDisplayInEnglish = language.ShortDisplay,
                ShortDisplay = languageDetail.ShortDisplay,
                LongDisplay = languageDetail.LongDisplay,
                CultureCode = language.CultureCode
            };
        }
    }
}
