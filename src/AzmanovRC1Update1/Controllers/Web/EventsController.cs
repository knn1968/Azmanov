using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Azmanov.ViewModels;
using Microsoft.Dnx.Runtime;
using Core;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Azmanov.Controllers.Web
{
    public class EventsController : Controller
    {
        private IEventsViewModel _eventsViewModel;

        public EventsController(
            IEventsViewModel eventsViewModel)
        {
            _eventsViewModel = eventsViewModel;
        }
        public IActionResult Index(int id = 1, string language = null)
        {
            _eventsViewModel.Load(language, id);
            return View(_eventsViewModel);
        }
    }
}
