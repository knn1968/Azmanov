using Core;
using System;

namespace Azmanov.ViewModels.Paging
{
    public class GalleryDisplayViewModel : IPageItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
    }
}