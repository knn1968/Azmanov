using Azmanov.Dtos;
using Azmanov.Entities;
using Azmanov.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azmanov.Factories.Interfaces
{
    public interface IAutobiographyDisplayViewModelFactory
    {
        AutobiographyDisplayViewModel Get(string language);
    }
}
