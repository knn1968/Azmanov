using System;
using System.Linq;
using Core;
using Azmanov.Entities;
using Microsoft.Data.Entity;
using Core.Repositories;
using System.Linq.Expressions;

namespace Azmanov.Data.Repositories
{
    public class EventsRepository : IEventRepository, IRepository<Event>, IPagingRepository<Event>
    {
        private AzmanovContext _context;

        public EventsRepository(AzmanovContext context)
        {
            _context = context;
        }

        public int GetCount()
        {
            return _context.Events.Count();
        }

        public IQueryable<Event> GetPage(string languageShortDisplay, int startIndex, int itemCount)
        {
            var language = _context.Languages.FirstOrDefault(p => p.ShortDisplay == languageShortDisplay);

            if (language == null)
                return null;

            return
                _context.Events
                    .Include(p => p.EventDetails)
                    .Include(p => p.EventPictures)
                    .Skip(startIndex)
                    .Take(itemCount)
                    .OrderBy(p => p.Order);
        }
        public void Dispose()
        {
            _context.Dispose();
        }
        public IQueryable<Event> GetPage(int startIndex, int itemCount)
        {
            return GetPage(_context.Languages.First(p => p.Default).ShortDisplay, startIndex, itemCount);
        }

        public void Add(Event newEntity)
        {
            if (newEntity.Order == 0)
            {
                newEntity.Order = GetCount() + 1;
            }

            _context.Events.Add(newEntity);
            _context.EventDetails.AddRange(newEntity.EventDetails);
            _context.EventPictures.AddRange(newEntity.EventPictures);

            foreach (var item in newEntity.EventPictures)
            {
                _context.EventPictureDetails.AddRange(item.EventPictureDetail);
            }
        }

        public void Remove(Event entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Event> Find(Expression<Func<Event, bool>> predicate)
        {
            return _context.Events.Include(p => p.EventDetails).Include(p => p.EventPictures).ThenInclude(p => p.EventPictureDetail).Where(predicate);
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void AddEventPicture(string eventId, EventPicture eventPicture)
        {
            var @event = Find(p => p.Id == Convert.ToInt32(eventId)).FirstOrDefault();
            if (@event != null)
            {
                @event.EventPictures.Add(eventPicture);
                _context.EventPictures.Add(eventPicture);
                _context.EventPictureDetails.AddRange(eventPicture.EventPictureDetail);
            }
        }

        public EventPicture GetEventPicture(int eventId, int pictureId)
        {
            var @event = Find(p => p.Id == Convert.ToInt32(eventId)).FirstOrDefault();
            if (@event != null)
            {
                return _context.EventPictures.FirstOrDefault(p => p.Id == pictureId);
            }

            return null;
        }

        public void DeletePicture(int eventId, int pictureId)
        {
            var @event = Find(p => p.Id == Convert.ToInt32(eventId)).FirstOrDefault();
            if (@event != null)
            {
              var v =  _context.Remove(_context.EventPictures.FirstOrDefault(p => p.Id == pictureId));
            }
        }
    }
}

