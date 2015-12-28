using Azmanov.Dtos;
using Azmanov.Entities;
using Core;
using Core.Repositories;

namespace Azmanov.Data.Interfaces
{
    public interface IGalleryRepository : IRepository<Gallery>, IPagingRepository<Gallery>
    {
        GalleryDetailDto GetGalleryDetail(string languageShortDisplay, int galleryDetailId);
    }
}
