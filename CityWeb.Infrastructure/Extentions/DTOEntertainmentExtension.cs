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
        
        //public static EntertainmentModelDTO ToEntertainmentModelDTO(this EntertainmentModel addData)
        //{
        //    return new EntertainmentModelDTO()
        //    {
        //        EntertainmentTitle = addData.Title,
        //        Description = addData.Description,
        //        Type = addData.EntertainmentType,
                
        //    };
        //}

        //public static EventModelDTO ToEventModelDTO(this EventModel eventModel)
        //{
        //    return new EventModelDTO()
        //    {
        //        EventTitle = eventModel.Title,
        //        Value = eventModel.EventPrice.Value,
        //        Tax = eventModel.EventPrice.Tax,
        //        VAT = eventModel.EventPrice.VAT,
        //        Total = eventModel.EventPrice.Total
        //    };
        //}

        //public static EventModelDTO ToEventModelDTO(this GetEventFromEventsDTO eventModel)
        //{
        //    return new EventModelDTO()
        //    {
        //        EventTitle = eventModel.EventTitle,
        //        Total = eventModel.Total,
        //        isAvailable = eventModel.isAvailable
        //    };
        //}

        //public static EntertainmentModel UpdateFromDTO(this UpdateEntertainmentDTO updateData)
        //{
        //    return  new EntertainmentModel()
        //    {
        //        Title = updateData.EntertainmentTitle,
        //        Description = updateData.Description,
        //        EntertainmentType = updateData.Type,
        //        Address = new AddressModel()
        //        {
        //            StreetName = updateData.StreetName,
        //            HouseNumber = updateData.HouseNumber
        //        }
        //    };
        //}

        //public static EventModel UpdateFromDTO(this UpdateEventDTO updateData)
        //{
        //    return new EventModel()
        //    {
        //        Title = updateData.EventTitle,
        //        EventPrice = new PriceModel()
        //        {
        //            Value = updateData.Value,
        //            Tax = updateData.Tax,
        //            VAT = updateData.VAT
        //        }
        //    };
        //}
        #region AddEntertainment
        //public static EntertainmentModel ToEntertainmentModel(this AddEntertainmentModelDTO entModel)
        //{
        //    return new EntertainmentModel()
        //    {

        //        Title = entModel.EntertainmentTitle,
        //        Description = entModel.Description,
        //        EntertainmentType = entModel.Type,

        //    };
        //}
        #endregion

        #region AddEvent
        //public static EventModel ToEventModel(this AddEventModelDTO addData)
        //{
        //    return new EventModel()
        //    {
        //        Title = addData.EventTitle,
        //        EventPrice = new PriceModel()
        //        {
        //            Value = addData.Value,
        //            Tax = addData.Tax,
        //            VAT = addData.VAT
        //        }
        //    };
        //}
        #endregion

    }
}


