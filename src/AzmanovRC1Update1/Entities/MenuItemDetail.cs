using System;

namespace Azmanov.Entities
{
    public class MenuItemDetail
    {
        public int Id { get; set; }
        public string ShortDisplay { get; set; }
        public string LongDisplay { get; set; }
        public string Description { get; set; }
        public int InLanguageId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime ExpireDateTime { get; set; }
    }
}