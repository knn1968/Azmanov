using AutoMapper;
using Azmanov.Data.Interfaces;
using Azmanov.Entities;
using Azmanov.Services.Interfaces;
using Azmanov.ViewModels.Interfaces.ViewModels;
using Azmanov.ViewModels.Models;
using AzmanovRC1Update1;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Azmanov.Controllers.Web
{
    public class ContactController : Controller
    {
        private IContactRepository _contactRepository;
        private IContactViewModel _contactViewModel;
        private IMailService _mailService;

        public ContactController(
            IMailService service,
            IContactViewModel contactViewModel,
            IContactRepository contactRepository)
        {
            _mailService = service;
            _contactViewModel = contactViewModel;
            _contactRepository = contactRepository;
        }
        [HttpGet]
        public IActionResult Index(string language = null)
        {
            _contactViewModel.Load(language);
            return View(_contactViewModel);
        }

        [HttpPost]
        public IActionResult Index(ContactFormViewModel model, string language = null)
        {
            if (ModelState.IsValid)
            {
                var email = Startup.Configuration["AppSettings:SiteEmailAddress"];

                if (string.IsNullOrWhiteSpace(email))
                {
                    ModelState.AddModelError("", "Could not send email. Configuration error.");
                }
                else
                {
                    if (_mailService.SendMail(email,
                        email,
                        $"Contact Page from {model.Name} ({model.Email})",
                        model.Message))
                    {
                        _contactRepository.Add(Mapper.Map<ContactEntry>(model));

                        if (_contactRepository.Commit())
                        {
                            ModelState.Clear();
                            _contactViewModel.FormInput = new ContactFormViewModel();
                            _contactViewModel.RedirectToHome = true;
                            //todo add to common settings repository
                            _contactViewModel.ThankYouMessage = "Your message has been sent. Thank you!";
                        }
                        else
                        {
                            ModelState.AddModelError("", "Could not send email. Database error.");
                        }
                    }
                    else
                    {
                        //todo add logging to the database
                        ModelState.AddModelError("", "Could not send email. Database error.");
                    }
                }
            }

            _contactViewModel.Load(language);
            return View(_contactViewModel);
        }
    }
}
