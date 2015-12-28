using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Core.Factories.Interfaces;
using Azmanov.Entities;
using Azmanov.ViewModels.Paging;
using System.Net;
using AutoMapper;
using Azmanov.Data.Repositories;
using Microsoft.Extensions.Logging;
using AzmanovRC1Update1.ViewModels;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Azmanov.Controllers.Api
{
    [Route("api/events/{eventId}/pictures")]
    public class EventPicturesController : Controller
    {
        private IEventRepository _repository;
        private ILogger<EventController> _logger;

        public EventPicturesController(
            IEventRepository repository,
            ILogger<EventController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        #region Event Pictures
        // GET: Get event pictures
        [HttpGet]
        public JsonResult Get(int eventId)
        {
            try
            {
                var @event = _repository.Find(p => p.Id == Convert.ToInt32(eventId)).FirstOrDefault();

                if (@event == null)
                {
                    return Json(null);
                }

                return Json(Mapper.Map<IEnumerable<EventUpdateViewModelPicture>>(@event.EventPictures));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get pictures for event {eventId}", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { message = ex.Message });
            }
        }

        // GET: Get event pictures
        [HttpGet("{pictureId}")]
        public JsonResult Get(int eventId, int pictureId)
        {
            try
            {
                var eventPicture = _repository.GetEventPicture(eventId, pictureId);

                if (eventPicture == null)
                {
                    return Json(null);
                }

                return Json(Mapper.Map<EventUpdateViewModelPicture>(eventPicture));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get picture {pictureId} for event {eventId}", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { message = ex.Message });
            }
        }

        // POST api/values
        [HttpPost]
        public JsonResult Post(string eventId, [FromBody]EventUpdateViewModelPicture eventUpdateViewModelPicture)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Mapper.CreateMap<EventUpdateViewModelPicture, EventPicture>()
                        .ForMember(p => p.Id, opt => opt.Ignore());

                    var eventPicture = Mapper.Map<EventPicture>(eventUpdateViewModelPicture);

                    _repository.AddEventPicture(eventId, eventPicture);

                    if (_repository.Commit())
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return Json(Mapper.Map<EventUpdateViewModelPicture>(eventPicture));
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to create new event picture", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { message = ex.Message });
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { message = "Failed", ModelState = ModelState });
        }

        // PUT api/values/5
        [HttpPut("{pictureId}")]
        public JsonResult Put(int eventId, int pictureId, [FromBody]EventUpdateViewModelPicture eventUpdateViewModelPicture)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var eventPicture = _repository.GetEventPicture(eventId, pictureId);

                    if (eventPicture == null)
                    {
                        return Json(null);
                    }

                    Mapper.CreateMap<EventUpdateViewModelPicture, EventPicture>()
                        .ForMember(p => p.Id, opt => opt.Ignore())
                        .ForMember(p => p.EventPictureDetail, opt => opt.ResolveUsing<EventUpdateViewModelPictureToEventPictureResolver>());

                    eventPicture = Mapper.Map<EventUpdateViewModelPicture, EventPicture>(eventUpdateViewModelPicture, eventPicture);

                    _repository.Commit();

                    return Json(Mapper.Map<EventUpdateViewModelPicture>(eventPicture));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get picture {pictureId} for event {eventId}", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { message = ex.Message });
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { message = "Failed", ModelState = ModelState });
        }

        // DELETE api/values/5
        [HttpDelete("{pictureId}")]
        public void Delete(int eventId, int pictureId)
        {
            _repository.DeletePicture(eventId, pictureId);

            _repository.Commit();
        }
        #endregion
    }
}