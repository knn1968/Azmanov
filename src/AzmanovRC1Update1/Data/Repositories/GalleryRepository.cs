using Azmanov.Data.Interfaces;
using System;
using System.Linq;
using Azmanov.Entities;
using Microsoft.Data.Entity;
using Azmanov.Dtos;
using System.Linq.Expressions;

namespace Azmanov.Data.Repositories
{
    public class GalleryRepository : IGalleryRepository
    {
        private AzmanovContext _context;

        public GalleryRepository(AzmanovContext context)
        {
            _context = context;
        }
        public int GetCount()
        {
            return _context.Galleries.Count();
        }

        public GalleryDetailDto GetGalleryDetail(string languageShortDisplay, int galleryDetailId)
        {
            var galleryDetailDto = new GalleryDetailDto();

            var language = _context.Languages.FirstOrDefault(p => p.ShortDisplay == languageShortDisplay);

            if (language == null)
                return galleryDetailDto;

            var gallery = _context.Galleries.Include(p => p.GalleryDetails).FirstOrDefault(p => p.Id == galleryDetailId);

            if (gallery == null)
                return galleryDetailDto;

            var galleryDetail = gallery.GalleryDetails.First(p => p.LanguageId == language.Id);

            if (galleryDetail == null)
                return galleryDetailDto;

            return new GalleryDetailDto()
            {
                Name = galleryDetail.Name,
                ThumbnailUrl = gallery.ThumbnailUrl,
                ImageUrl = gallery.ImageUrl
            };
        }
        public IQueryable<Gallery> GetPage(string languageShortDisplay, int startIndex, int itemCount)
        {
            var language = _context.Languages.FirstOrDefault(p => p.ShortDisplay == languageShortDisplay);

            if (language == null)
                return null;

            return
                _context.Galleries
                    .Where(p => GalleryIsValid(p, language))
                    .Skip(startIndex)
                    .Take(itemCount)
                    .Include(p => p.GalleryDetails)
                    .OrderBy(p => p.Order);
        }
        public IQueryable<Gallery> GetPage(int startIndex, int itemCount)
        {
            return GetPage(_context.Languages.First(p => p.Default).ShortDisplay, startIndex, itemCount);
        }
        public void Add(Gallery newEntity)
        {
            if (newEntity.Order == 0)
            {
                newEntity.Order = GetCount() + 1;
            }

            if (newEntity.CreatedDateTime <= DateTime.UtcNow)
            {
                newEntity.CreatedDateTime = DateTime.UtcNow;
            }

            _context.Galleries.Add(newEntity);
            _context.GalleryDetails.AddRange(newEntity.GalleryDetails);
        }

        public void Remove(Gallery entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Gallery> Find(Expression<Func<Gallery, bool>> predicate)
        {
            return _context.Galleries.Include(p => p.GalleryDetails).Where(predicate);
        }

        private static bool GalleryIsValid(Gallery p, Language language)
        {
            return p.ExpireDateTime >= DateTime.UtcNow &&
                   (String.IsNullOrEmpty(p.ImageUrl) == false) &&
                   (String.IsNullOrWhiteSpace(p.ThumbnailUrl) == false) &&
                   p.GalleryDetails != null &&
                   p.GalleryDetails.Count() > 0 &&
                   p.GalleryDetails.Any(p1 => p1.LanguageId == language.Id);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
