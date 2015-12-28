using Azmanov.Data.Interfaces;
using Azmanov.Data.Repositories;
using Azmanov.Dtos.Paging;
using Azmanov.Entities;
using Azmanov.Factories;
using Core;
using Core.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azmanov.ViewModels
{
    public class MediaViewModel : BaseViewModel, IMediaViewModel
    {
        private IPager<MediaEvent, MediaDisplayViewModel> _pager;

        public PagingResult<MediaDisplayViewModel> PagingResult { get; set; }

        public MediaViewModel(
            ILanguageRepository languageRepository,
            ILanguageViewModelFactory languageViewModelFactory,
            IMenuRepository menuRepository,
            IMenuViewModelFactory menuViewModelFactory,
            IPager<MediaEvent, MediaDisplayViewModel> pager)
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
