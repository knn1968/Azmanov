using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azmanov.Entities
{
    public class AutobiographyDetail
    {
        public int Id { get; set; }
        //public int AutobiographyDetailId { get; set; }
        public int LanguageId { get; set; }
        public string Text { get; set; }

    }
}
