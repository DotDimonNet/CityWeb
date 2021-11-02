using System;
using CityWeb.Domain.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Domain.DTO.EnterteinmentDTO;

namespace CityWeb.Domain.Entities
{
    public class EventModel : Entity, IDescribe
    {
        public virtual string Title {get; set; }
        public virtual string Description {get; set; }
        public virtual EntertainmentType Type { get; set; }
        public virtual PriceModel EventPrice { get; set; }
        public virtual EntertainmentModel Entertaiment { get; set;}
        public virtual bool isAvailable { get; set; }
        public virtual Guid EntertaimentId { get; set; }

        public EventModel UpdateFromDTO(UpdateEventDTO updateEvent)
        {
            return new EventModel()
            {
                Title = updateEvent.EventTitle,
                EventPrice = new PriceModel()
                {
                    Value = updateEvent.Value,
                    Tax = updateEvent.Tax,
                    VAT = updateEvent.VAT
                }
            };
        }
    }
}
