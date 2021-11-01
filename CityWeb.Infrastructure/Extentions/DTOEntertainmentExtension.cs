using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Domain.DTO;
using CityWeb.Domain.DTO.EnterteinmentDTO;
using CityWeb.Domain.Entities;

namespace CityWeb.Infrastructure.Extentions
{
    public static class DTOEntertainmentExtension
    {
        //public static EntertainmentModel ToAddEntertainmentModelDTO(this AddEntertainmentModelDTO entModel)
        //{
        //    return new EntertainmentModel()
        //    {

        //        Title = entModel.EntertainmentTitle,
        //        Description = entModel.Description,
        //        EntertainmentType = entModel.Type,

        //    };
        //}
        //public static AddEventModelDTO ToAddEventModelDTO(this EventModel eventModel)
        //{
        //    return new AddEventModelDTO()
        //    {
        //        EventTitle = eventModel.Title,
        //        Value = eventModel.EventPrice.Value,
        //        VAT = eventModel.EventPrice.VAT,
        //        Tax = eventModel.EventPrice.Tax
        //    };
        //}
        //public static UpdateEntertainmentDTO ToUpdateEntertainmentModelDTO(this EntertainmentModel entModel)
        //{
        //    return new UpdateEntertainmentDTO()
        //    {
        //        EntertainmentTitle = entModel.Title
        //    };
        //}
        //public static UpdateEventDTO ToUpdateEventModelDTO(this EventModel eventModel)
        //{
        //    return new UpdateEventDTO()
        //    {
        //        EventTitle = eventModel.Title,
        //        Value = eventModel.EventPrice.Value,
        //        Tax = eventModel.EventPrice.Tax,
        //        VAT = eventModel.EventPrice.VAT,
        //    };
        //}

        public static EventModelDTO ToEventModelDTO(this EventModel eventModel)
        {
            return new EventModelDTO()
            {
                EventTitle = eventModel.Title,
                Total = eventModel.EventPrice.Total,
                isAvailable = eventModel.isAvailable
            };
        }

        public static EntertainmentModelDTO ToEntertainmentModelDTO(this UpdateEntertainmentDTO updateData)
        {
            return  new EntertainmentModelDTO()
            {
                EntertainmentTitle = updateData.EntertainmentTitle,
                Description = updateData.Description,

            };
        }
    }
}
