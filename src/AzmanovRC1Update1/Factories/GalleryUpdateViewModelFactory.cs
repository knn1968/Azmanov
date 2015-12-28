using AutoMapper;
using Azmanov.Data;
using Azmanov.Dtos.Paging;
using Azmanov.Entities;
using Azmanov.ViewModels.Paging;
using Core;
using Core.Factories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azmanov.Factories
{
    public class GalleryUpdateViewModelFactory : IModelFactory<Gallery, GalleryUpdateViewModel>
    {
        private AzmanovContext _context;

        public GalleryUpdateViewModelFactory(AzmanovContext context)
        {
            _context = context;
        }
        public GalleryUpdateViewModel CreateInstance(Gallery input)
        {
            return CreateInstance(input, _context.Languages.Single(p => p.Default).ShortDisplay);
        }

        public GalleryUpdateViewModel CreateInstance(Gallery input, string languageShortDisplay)
        {
            var language = _context.Languages.First(p => p.ShortDisplay == languageShortDisplay);

            return Mapper.Map<GalleryUpdateViewModel>(input);
        }

        public IEnumerable<GalleryUpdateViewModel> CreateList(IEnumerable<Gallery> input)
        {
            return CreateList(input, _context.Languages.Single(p => p.Default).ShortDisplay);
        }

        public IEnumerable<GalleryUpdateViewModel> CreateList(IEnumerable<Gallery> input, string languageShortDisplay)
        {
            var language = _context.Languages.First(p => p.ShortDisplay == languageShortDisplay);

            return Mapper.Map<IEnumerable<GalleryUpdateViewModel>>(input);
        }
    }
}
