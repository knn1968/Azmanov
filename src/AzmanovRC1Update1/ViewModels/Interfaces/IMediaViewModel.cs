using Azmanov.Dtos.Paging;
using Core;
using Core.Paging;

namespace Azmanov.ViewModels
{
    public interface IMediaViewModel : IBaseViewModel
    {
        PagingResult<MediaDisplayViewModel> PagingResult { get; set; }
        void Load(string languageShortDisplay, int pageId);
    }
}