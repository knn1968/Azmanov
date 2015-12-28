using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Azmanov.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Azmanov.Controllers.Web
{
    public class MediaController : Controller
    {
        private IMediaViewModel _mediaViewModel;

        public MediaController(IMediaViewModel mediaViewModel)
        {
            _mediaViewModel = mediaViewModel;
        }
        public IActionResult Index(int id = 1, string language = null)
        {
            _mediaViewModel.Load(language, id);
            return View(_mediaViewModel);
        }
    }
}
