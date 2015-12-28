using System;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Azmanov.Data.Interfaces;
using System.Net;
using AutoMapper;
using Azmanov.Entities;
using Azmanov.ViewModels.Paging;
using Core.Factories.Interfaces;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Azmanov.Controllers.Api
{
    [Route("api/galleries")]
    public class GalleryController : Controller
    {
        private IGalleryRepository _repository;
        private IModelFactory<Gallery, GalleryUpdateViewModel> _factory;
        private ILogger<GalleryController> _logger;

        public GalleryController(
            IGalleryRepository repository,
            IModelFactory<Gallery, GalleryUpdateViewModel> factory,
            ILogger<GalleryController> logger)
        {
            _repository = repository;
            _factory = factory;
            _logger = logger;
        }
        // GET: api/values
        [HttpGet]
        public JsonResult Get(string languageCode)
        {
            return Json(_factory.CreateList(_repository.Find(p => true).OrderBy(p => p.Order)));
            //return Json(true);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public JsonResult Post([FromBody]GalleryUpdateViewModel value)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var gallery = Mapper.Map<Gallery>(value);

                    _repository.Add(gallery);

                    if (_repository.Commit())
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return Json(Mapper.Map<GalleryUpdateViewModel>(gallery));
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to create new gallery Item", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { message = ex.Message });
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { message = "Failed", ModelState = ModelState });
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
