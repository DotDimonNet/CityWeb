using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Domain.Entities;
using CityWeb.Domain.Enums;

namespace CityWeb.Domain.DTO.EnterteinmentDTO
{
    public class DeleteEntertainmentDTO
    {
        public  ServiceModel Service { get; set; }
        public  Guid ServiceId { get; set; }
        public  EntertainmentType EntertainmentType { get; set; }    
        public  PriceModel Price { get; set; }
        public  AddressModel Address { get; set; }

        public  PeriodModel WorkSchedule { get; set; }
        public  ICollection<EventModel> Event { get; set; } = new List<EventModel>();
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
