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
        public static EntertainmentModelDTO ToEntertainmentModelDTO(this EntertainmentModel entModel)
        {
            return new EntertainmentModelDTO()
            {
                EntertainmentTitle = entModel.Title,
                Description = entModel.Description,
                Type = entModel.EntertainmentType,
                Address = entModel.Address
            };
        }

        public static EventModelDTO ToEventModelDTO(this EventModel eventModel)
        {
            return new EventModelDTO()
            {
                EventTitle = eventModel.Title,
                Description = eventModel.Description,
                Price = eventModel.EventPrice,
                
            };
        }


        


        


        public static EntertainmentModelDTO ToAddEntertainmentModel(this AddEntertainmentModelDTO entModel)
        {
            return new EntertainmentModelDTO()
            {
                EntertainmentTitle = entModel.EntertainmentTitle,
                Type = entModel.Type,
                Description = entModel.Description,
                Address = entModel.Address

            };
        }

    }
}
