using Core;
using Core.Paging;

namespace Azmanov.ViewModels
{
    public interface IEventsViewModel : IBaseViewModel
    {
        PagingResult<EventDisplayViewModel> PagingResult { get; set; }
        void Load(string languageShortDisplay, int pageId);
    }
}