using Azmanov.Data;
using Azmanov.Entities;
using Azmanov.ViewModels.Paging;
using Core;
using Core.Factories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azmanov.Factories.Interfaces
{
    public class GalleryDisplayViewModelFactory : IModelFactory<Gallery, GalleryDisplayViewModel>
    {
        private AzmanovContext _context;

        public GalleryDisplayViewModelFactory(AzmanovContext context)
        {
            _context = context;
        }
        public GalleryDisplayViewModel CreateInstance(Gallery input)
        {
            return CreateInstance(input, _context.Languages.Single(p => p.Default).ShortDisplay);
        }

        public GalleryDisplayViewModel CreateInstance(Gallery input, string languageShortDisplay)
        {
            var language = _context.Languages.First(p => p.ShortDisplay == languageShortDisplay);

            var viewModel = new GalleryDisplayViewModel()
            {
                Id = input.Id,
                Location = input.ThumbnailUrl,
                Title = input.GalleryDetails.FirstOrDefault(p => p.LanguageId == language.Id).Name
            };

            return viewModel;
        }

        public IEnumerable<GalleryDisplayViewModel> CreateList(IEnumerable<Gallery> input)
        {
            List<GalleryDisplayViewModel> viewModels = new List<GalleryDisplayViewModel>();

            foreach(var item in input)
            {
                viewModels.Add(CreateInstance(item));
            }

            return viewModels;
        }

        public IEnumerable<GalleryDisplayViewModel> CreateList(IEnumerable<Gallery> input, string languageShortDisplay)
        {
            List<GalleryDisplayViewModel> viewModels = new List<GalleryDisplayViewModel>();

            foreach (var item in input)
            {
                viewModels.Add(CreateInstance(item, languageShortDisplay));
            }

            return viewModels;
        }
    }
}
