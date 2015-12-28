using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Azmanov.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Azmanov.Controllers.Web
{
    public class AutobiographyController : Controller
    {
        private IAutobiographyViewModel _autobiographyViewModel;

        public AutobiographyController(IAutobiographyViewModel autobiographyViewModel)
        {
            _autobiographyViewModel = autobiographyViewModel;
        }
        public IActionResult Index(string language = null)
        {
            _autobiographyViewModel.Load(language);
            return View(_autobiographyViewModel);
        }
    }
}
