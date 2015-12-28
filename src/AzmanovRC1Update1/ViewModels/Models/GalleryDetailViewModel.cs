using Azmanov.Data.Interfaces;
using Azmanov.Data.Repositories;
using Azmanov.Factories;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azmanov.ViewModels
{
    public class GalleryDetailViewModel : BaseViewModel, IGalleryDetailViewModel
    {
        private IGalleryRepository _galleryRepository;
        public GalleryDetailViewModel(ILanguageRepository languageRepository,
            ILanguageViewModelFactory languageViewModelFactory,
            IMenuRepository menuRepository,
            IMenuViewModelFactory menuViewModelFactory,
            IGalleryRepository galleryRepository)
            : base(
                  languageRepository,
                  languageViewModelFactory,
                  menuRepository,
                  menuViewModelFactory)
        {
            _galleryRepository = galleryRepository;
        }
        public string ThumbnailUrl { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int PageId { get; set; }

        public void Load(string languageShortDisplay, int galleryDetailId, int pageId)
        {
            var galleryDetailDto = _galleryRepository.GetGalleryDetail(languageShortDisplay, galleryDetailId);

            Name = galleryDetailDto.Name;
            ThumbnailUrl = galleryDetailDto.ThumbnailUrl;
            ImageUrl = galleryDetailDto.ImageUrl;
            PageId = pageId;

            base.Load(languageShortDisplay);
        }
    }
}
