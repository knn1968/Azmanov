using System;
using System.Collections.Generic;
using Core;
using Azmanov.ViewModels.Paging;

namespace Azmanov.ViewModels
{
    public class EventDisplayViewModel : IPageItem
    {
        public string Title { get; set; }
        public DateTime EventDate { get; set; }
        public int Id { get; set; }
        public string Body { get; set; }
        public IList<GalleryDisplayViewModel> Images { get; set; }
    }
}