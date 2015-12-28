using System;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Core.Factories.Interfaces;
using Azmanov.Entities;
using Azmanov.ViewModels.Paging;
using Core.Repositories;
using AutoMapper;
using System.Net;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Azmanov.Data.Repositories;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Azmanov.Controllers.Api
{
    [Route("api/events")]
    public class EventController : Controller
    {
        private IEventRepository _repository;
        private IModelFactory<Event, EventUpdateViewModel> _factory;
        private ILogger<EventController> _logger;

        public EventController(
            IEventRepository repository,
            IModelFactory<Event, EventUpdateViewModel> factory,
            ILogger<EventController> logger)
        {
            _repository = repository;
            _factory = factory;
            _logger = logger;
        }

        #region Events
        // GET: api/values
        [HttpGet]
        public JsonResult Get()
        {
            return Json(_factory.CreateList(_repository.Find(p => true).OrderBy(p => p.Order)));
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return Json(_factory.CreateInstance(_repository.Find(p => p.Id == id).First()));
        }

        // POST api/values
        [HttpPost]
        public JsonResult Post([FromBody]EventUpdateViewModel value)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var @event = Mapper.Map<Event>(value);

                    _repository.Add(@event);

                    if (_repository.Commit())
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return Json(Mapper.Map<EventUpdateViewModel>(@event));
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to create new event Item", ex);
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
        #endregion

    }
}
