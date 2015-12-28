using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azmanov.Entities;
using Microsoft.Data.Entity;
using Azmanov.Data.Interfaces;

namespace Azmanov.Data.Repositories
{
    public class LanguageRepository : ILanguageRepository
    {
        private AzmanovContext _context;

        public LanguageRepository(AzmanovContext context)
        {
            _context = context;
        }

        public Language GetDefaultLanguage()
        {
            var defaultLanguage = _context.Languages.FirstOrDefault(p => p.Default);

            if (defaultLanguage == null)
                defaultLanguage = _context.Languages.OrderBy(p => p.Id).FirstOrDefault();

            if (defaultLanguage == null)
                throw new Exception("Internal Error", new Exception("No language defined"));

            return defaultLanguage;
        }

        public IEnumerable<LanguageDetail> GetLanguageDetails(string languageShortDisplay)
        {
            if (languageShortDisplay == null)
                languageShortDisplay = GetDefaultLanguage().ShortDisplay;

            var language = _context.Languages.FirstOrDefault(p => p.ShortDisplay == languageShortDisplay);

            if (language == null)
                return null;

            var translations =
                 _context.LanguageDetails
                     .Where(p => p.InLanguageId == language.Id)
                     .OrderBy(p => p.Order)
                     .ToList();

            return translations;
        }
        public LanguageDetail GetLanguageDetailsInCurrentLanguage(string languageShortDisplay)
        {
            var language = _context.Languages.Include(p => p.LanguageDetails).FirstOrDefault(p => p.ShortDisplay == languageShortDisplay);

            if (language == null)
            {
                language = GetDefaultLanguage() ;

                if (language == null)
                {
                    throw new Exception("Internal Error", new Exception("Could not retrieve native language."));
                }
            }

            return language.LanguageDetails
                     .First(p => p.InLanguageId == language.Id);
        }
    }
}
