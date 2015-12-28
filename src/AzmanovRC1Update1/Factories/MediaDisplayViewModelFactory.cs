using Azmanov.Data;
using Azmanov.Dtos.Paging;
using Azmanov.Entities;
using Core.Factories.Interfaces;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azmanov.Factories.Interfaces
{
    public class MediaDisplayViewModelFactory : IModelFactory<MediaEvent, MediaDisplayViewModel>
    {
        private AzmanovContext _context;

        public MediaDisplayViewModelFactory(AzmanovContext context)
        {
            _context = context;
        }
        public MediaDisplayViewModel CreateInstance(MediaEvent input)
        {
            return CreateInstance(input, _context.Languages.Single(p => p.Default).ShortDisplay);
        }

        public MediaDisplayViewModel CreateInstance(MediaEvent input, string languageShortDisplay)
        {
            var language = _context.Languages.First(p => p.ShortDisplay == languageShortDisplay);

            var itemTemp = _context.MediaEvents.Include(p => p.MediaEventDetails).First(p => p == input);

            var mediaEventDetail = itemTemp.MediaEventDetails.FirstOrDefault(p => p.LanguageId == language.Id);
            if (mediaEventDetail == null)
            {
                return null;
            }

            var viewModel = new MediaDisplayViewModel()
            {
                Id = input.Order,
                Title = mediaEventDetail.Title,
                Intro = mediaEventDetail.Intro,
                Body = mediaEventDetail.Body,
                FullText = true,
                EventDate = input.EventDate
            };

            //if (viewModel.Body.Length > 500)
            //{
            //    viewModel.BodyCollapsed = viewModel.Body.Substring(0, 500);
            //    viewModel.FullText = false;
            //    viewModel.LinkText = "Full Article >>";
            //}

            return viewModel;
        }

        public IEnumerable<MediaDisplayViewModel> CreateList(IEnumerable<MediaEvent> input)
        {
            List<MediaDisplayViewModel> viewModels = new List<MediaDisplayViewModel>();

            foreach (var item in input)
            {
                viewModels.Add(CreateInstance(item));
            }

            return viewModels;
        }

        public IEnumerable<MediaDisplayViewModel> CreateList(IEnumerable<MediaEvent> input, string languageShortDisplay)
        {
            List<MediaDisplayViewModel> viewModels = new List<MediaDisplayViewModel>();

            foreach (var item in input)
            {
                viewModels.Add(CreateInstance(item, languageShortDisplay));
            }

            return viewModels;
        }
    }
}
