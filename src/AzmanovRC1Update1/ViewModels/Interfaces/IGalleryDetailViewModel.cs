namespace Azmanov.ViewModels
{
    public interface IGalleryDetailViewModel
    {
        string ThumbnailUrl { get; set; }
        string Name { get; set; }
        void Load(string languageShortDisplay, int galleryDetailId, int pageId);
    }
}