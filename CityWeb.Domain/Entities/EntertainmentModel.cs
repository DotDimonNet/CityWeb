using CityWeb.Domain.DTO.EnterteinmentDTO;
using CityWeb.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.Entities
{
    public class EntertainmentModel : Entity, IDescribe
    {
        public virtual ServiceModel Service { get; set; }
        public virtual Guid ServiceId { get; set; }
        public virtual EntertainmentType EntertainmentType { get; set; }       
        public virtual PriceModel Price { get; set; }
        public virtual AddressModel Address { get; set; }        
        public virtual PeriodModel WorkSchedule { get; set; }
        public virtual ICollection<EventModel> Event { get; set; } = new List<EventModel>();
        public string Title { get ; set ; }
        public string Description { get ; set ; }
        public virtual ApplicationUserModel User { get; set; }
        public virtual NewsType EntertainmentNews { get; set; }
        public EntertainmentModel UpdateFromDTO(UpdateEntertainmentDTO updateData)
        {
            return new EntertainmentModel()
            {
                Title = updateData.EntertainmentTitle,
                Description = updateData.Description,
                EntertainmentType = updateData.Type,
                Address = new AddressModel()
                {
                    StreetName = updateData.StreetName,
                    HouseNumber = updateData.HouseNumber
                }
            };
        }
    }
}
