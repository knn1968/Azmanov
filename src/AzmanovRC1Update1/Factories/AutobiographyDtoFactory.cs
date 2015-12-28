using Azmanov.Factories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azmanov.Entities;
using Azmanov.ViewModels;
using Azmanov.Data.Interfaces;
using Azmanov.Dtos;
using Azmanov.Data;

namespace Azmanov.Factories
{
    public class AutobiographyDisplayViewModelFactory : IAutobiographyDisplayViewModelFactory
    {
        private IAutobiographyRepository _autobiographyRepository;
        private AzmanovContext _context;

        public AutobiographyDisplayViewModelFactory(IAutobiographyRepository autobiographyRepository, AzmanovContext context)
        {
            _autobiographyRepository = autobiographyRepository;
            _context = context;
        }

        public AutobiographyDisplayViewModel Get(string language)
        {
            var AutobiographyDisplayViewModel = new AutobiographyDisplayViewModel()
            {
                Text = "Autobiography",
                ImageUrl = string.Empty
            };

            var autobiographyDetail = _autobiographyRepository.Get(language);

            if (autobiographyDetail != null)
            {
                var autobiography = _context.Autobiographies.First(p => p.AutobiographyDetails.Any(p1 => p1.Id == autobiographyDetail.Id));

                if (autobiography != null)
                {
                    AutobiographyDisplayViewModel.Text = autobiographyDetail.Text;
                    AutobiographyDisplayViewModel.ImageUrl = autobiography.ImageUrl;
                }
            }
            return AutobiographyDisplayViewModel;
        }
    }
}
