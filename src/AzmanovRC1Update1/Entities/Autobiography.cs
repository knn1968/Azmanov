using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azmanov.Entities
{
    public class Autobiography
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime ExpireDateTime { get; set; }
        public ICollection<AutobiographyDetail> AutobiographyDetails { get; set; }
    }
}
