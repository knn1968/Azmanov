using AutoMapper;
using Azmanov.Entities;
using Azmanov.ViewModels.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzmanovRC1Update1.ViewModels
{
    public class EventUpdateViewModelPictureToEventPictureResolver : IValueResolver
    {

        public ResolutionResult Resolve(ResolutionResult source)
        {

            var eventPictureDetails = ((EventPicture)source.Context.DestinationValue).EventPictureDetail;

            foreach (var eventPictureDetail in eventPictureDetails)
            {
                var modelEventPictureDetail = ((EventUpdateViewModelPicture)source.Value).EventPictureDetail.FirstOrDefault(p => p.Id == eventPictureDetail.Id);

                if (modelEventPictureDetail != null)
                {
                    Mapper.Map(modelEventPictureDetail, eventPictureDetail);
                }
            }

            return source.New(eventPictureDetails, typeof(ICollection<EventPictureDetail>));
        }
    }

}

