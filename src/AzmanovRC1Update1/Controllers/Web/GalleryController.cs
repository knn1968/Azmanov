using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Core;
using System.Reflection;
using Microsoft.Dnx.Runtime;
using Azmanov.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Azmanov.Controllers.Web
{
    public class GalleryController : Controller
    {
        private IGalleryViewModel _galleryViewModel;
        private IGalleryDetailViewModel _galleryDetailViewModel;

        public GalleryController(
            IGalleryViewModel galleryViewModel,
            IGalleryDetailViewModel galleryDetailViewModel)
        {
            _galleryViewModel = galleryViewModel;
            _galleryDetailViewModel = galleryDetailViewModel;
        }
        // GET: /<controller>/
        public IActionResult Index(int id = 1, string language = null)
        {
            _galleryViewModel.Load(language, id);
            return View(_galleryViewModel);
        }

        public IActionResult Detail(int id, string language = null, int pageId = 1)
        {
            _galleryDetailViewModel.Load(language, id, pageId);

            return View(_galleryDetailViewModel);
        }
    }
}
