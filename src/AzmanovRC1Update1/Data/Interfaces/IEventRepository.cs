using Azmanov.Entities;
using Azmanov.ViewModels.Paging;
using Core;
using Core.Repositories;

namespace Azmanov.Data.Repositories
{
    public interface IEventRepository : IRepository<Event>, IPagingRepository<Event>
    {
        void AddEventPicture(string eventId, EventPicture eventPicture);
        EventPicture GetEventPicture(int eventId, int pictureId);
        void DeletePicture(int eventId, int pictureId);
    }
}