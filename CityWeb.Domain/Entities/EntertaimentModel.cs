using CityWeb.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.Entities
{
    public class EntertaimentModel : Entity, IDescribe
    {
        //public virtual ServiceModel Service { get; set; }
        public virtual EventType EventType { get; set; }
        public int FreePlaceAmount { get; set; }
        public virtual PriceModel Price { get; set; }
        public virtual AddressModel Address { get; set; }
        public virtual PeriodModel EventPeriod { get; set; }
        public virtual PeriodModel WorkSchedule { get; set; }
        public virtual ICollection<EventModel> Event { get; set; } = new List<EventModel>();
        public string Title { get ; set ; }
        public string Description { get ; set ; }
    }
}
