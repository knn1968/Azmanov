using Azmanov.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azmanov.Data.Interfaces
{
    public interface IAutobiographyRepository : IDisposable
    {
        AutobiographyDetail Get(string languageShortDisplay);
    }
}
