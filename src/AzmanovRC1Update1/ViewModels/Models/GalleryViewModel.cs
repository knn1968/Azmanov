using Azmanov.Data.Interfaces;
using Azmanov.Data.Repositories;
using Azmanov.Entities;
using Azmanov.Factories;
using Azmanov.ViewModels.Paging;
using Core;
using Core.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azmanov.ViewModels
{
    public class GalleryViewModel : BaseViewModel, IGalleryViewModel
    {
        private IPager<Gallery, GalleryDisplayViewModel> _pager;
        public PagingResult<GalleryDisplayViewModel> PagingResult { get; set; }
        public GalleryViewModel(
            ILanguageRepository languageRepository,
            ILanguageViewModelFactory languageViewModelFactory,
            IMenuRepository menuRepository,
            IMenuViewModelFactory menuViewModelFactory,
            IPager<Gallery, GalleryDisplayViewModel> pager)
            : base(
                  languageRepository,
                  languageViewModelFactory,
                  menuRepository,
                  menuViewModelFactory)
        {
            _pager = pager;
        }
        public void Load(string languageShortDisplay, int pageId)
        {
            PagingResult = _pager.GetPage(pageId, languageShortDisplay);
            base.Load(languageShortDisplay);
        }
    }
}
