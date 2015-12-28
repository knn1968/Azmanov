using Azmanov.Data.Interfaces;
using Azmanov.Factories.Interfaces;

namespace Azmanov.ViewModels
{
    public interface IAutobiographyViewModel : IBaseViewModel
    {
        string ImageUrl { get; set; }
        string Text { get; set; }
        void PopulateAutobiographyData(string language);
    }
}