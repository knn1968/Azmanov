using Azmanov.Data;
using Azmanov.Entities;
using Azmanov.ViewModels;
using Azmanov.ViewModels.Paging;
using Core;
using Core.Factories.Interfaces;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azmanov.Factories.Interfaces
{
    public class EventDisplayViewModelFactory : IModelFactory<Event, EventDisplayViewModel>
    {
        private AzmanovContext _context;

        public EventDisplayViewModelFactory(AzmanovContext context)
        {
            _context = context;
        }
        //public EventDisplayViewModel CreateInstance(Event input)
        //{
        //    return CreateInstance(input, _context.Languages.Single(p => p.Default).ShortDisplay);
        //}

        public EventDisplayViewModel CreateInstance(Event input, string languageShortDisplay)
        {
            var language = languageShortDisplay == null ? _context.Languages.First(p=>p.Default) : _context.Languages.First(p => p.ShortDisplay == languageShortDisplay);

            var itemTemp = _context.Events
                .Include(p => p.EventDetails)
                .Include(p => p.EventPictures).First(p => p == input);

            var eventDetail = itemTemp.EventDetails.FirstOrDefault(p => p.LanguageId == language.Id);
            if (eventDetail == null)
            {
                return null;
            }

            var viewModel = new EventDisplayViewModel()
            {
                Id = input.Order,
                Title = eventDetail.Title,
                Body = eventDetail.Body,
                Images = new List<GalleryDisplayViewModel>(),
                EventDate = input.EventDate
            };

            foreach (var detail in input.EventPictures)
            {
                var detailTemp = _context.EventPictures.Include(p => p.EventPictureDetail).First(p => p == detail);

                var eventPictureDetail = detailTemp.EventPictureDetail.FirstOrDefault(p => p.LanguageId == language.Id);
                if (eventPictureDetail == null)
                {
                    continue;
                }

                var image = new GalleryDisplayViewModel()
                {
                    Location = detail.ImageUrl,
                    Title = eventPictureDetail.Name
                };

                viewModel.Images.Add(image);
            }

            return viewModel;
        }

        //public IEnumerable<EventDisplayViewModel> CreateList(IEnumerable<Event> input)
        //{
        //    List<EventDisplayViewModel> viewModels = new List<EventDisplayViewModel>();

        //    foreach (var item in input)
        //    {
        //        viewModels.Add(CreateInstance(item));
        //    }

        //    return viewModels;
        //}

        public IEnumerable<EventDisplayViewModel> CreateList(IEnumerable<Event> input, string languageShortDisplay)
        {
            List<EventDisplayViewModel> viewModels = new List<EventDisplayViewModel>();

            foreach (var item in input)
            {
                viewModels.Add(CreateInstance(item, languageShortDisplay));
            }

            return viewModels;
        }
    }
}
