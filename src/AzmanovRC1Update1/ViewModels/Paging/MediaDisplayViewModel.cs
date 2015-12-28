using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azmanov.Dtos.Paging
{
    public class MediaDisplayViewModel : IPageItem
    {
        public string Body { get; set; }
        public string BodyCollapsed { get; internal set; }
        public DateTime EventDate { get; set; }
        public bool FullText { get; set; }
        public int Id { get; set; }
        public string Intro { get; internal set; }
        public string LinkText { get; set; }
        public string Title { get; set; }
    }
}
