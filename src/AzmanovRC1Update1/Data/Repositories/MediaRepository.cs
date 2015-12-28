using System;
using System.Linq;
using Azmanov.Entities;
using Microsoft.Data.Entity;
using Core;
using Core.Repositories;
using System.Linq.Expressions;

namespace Azmanov.Data.Repositories
{
    public class MediaRepository : IRepository<MediaEvent>, IPagingRepository<MediaEvent>
    {
        private AzmanovContext _context;

        public MediaRepository(AzmanovContext context)
        {
            _context = context;
        }
        public int GetCount()
        {
            return _context.MediaEvents.Count();
        }
        public IQueryable<MediaEvent> GetPage(string languageShortDisplay, int startIndex, int itemCount)
        {
            var language = _context.Languages.FirstOrDefault(p => p.ShortDisplay == languageShortDisplay);

            if (language == null)
                return null;

            return
                _context.MediaEvents
                    .Include(p => p.MediaEventDetails)
                    .Skip(startIndex)
                    .Take(itemCount)
                    .OrderBy(p => p.Order);

        }
        public IQueryable<MediaEvent> GetPage(int startIndex, int itemCount)
        {
            return GetPage(_context.Languages.First(p => p.Default).ShortDisplay, startIndex, itemCount);
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public void Add(MediaEvent newEntity)
        {
            throw new NotImplementedException();
        }

        public void Remove(MediaEvent entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<MediaEvent> Find(Expression<Func<MediaEvent, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
