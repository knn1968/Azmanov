using Azmanov.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azmanov.Entities;
using Microsoft.Data.Entity;

namespace Azmanov.Data.Repositories
{
    public class AutobiographyRepository : IAutobiographyRepository
    {
        private AzmanovContext _context;

        public AutobiographyRepository(AzmanovContext context)
        {
            _context = context;
        }

        public AutobiographyDetail Get(string languageShortDisplay)
        {
            var language = _context.Languages.FirstOrDefault(p => p.ShortDisplay == languageShortDisplay);

            var autobiography = _context.Autobiographies.Include(p => p.AutobiographyDetails).FirstOrDefault();

            if (autobiography == null || language == null)
            {
                return null;
            }
            return autobiography.AutobiographyDetails.FirstOrDefault(p => p.LanguageId == language.Id);
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
