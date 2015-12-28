using Azmanov.Data.Repositories;
using Azmanov.Entities;
using Azmanov.Factories;
using Azmanov.ViewModels;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using System;
using System.Linq;
using Azmanov.Services;

namespace Azmanov.Controllers.Web
{
    public class HomeController : Controller
    {
        private IHomeViewModel _homeViewModel;

        public HomeController(IHomeViewModel homeViewModel)
        {
            _homeViewModel = homeViewModel;
        }

        public IActionResult Index(string language = null)
        {
            _homeViewModel.Load(language);
            return View(_homeViewModel);
        }
    }
}

