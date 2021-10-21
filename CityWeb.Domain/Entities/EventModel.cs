using System;
using CityWeb.Domain.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.Entities
{
    public class EventModel : Entity
    {
        public virtual string Film { get; set; }
        //public virtual ServiceModel Service { get; set; }
        public virtual EventType Type { get; set; }
        public virtual PriceModel EventPrice { get; set; }
        public virtual EntertaimentModel Entertaiment { get; set;}
        public virtual Guid EntertainmentId { get; set; } = Guid.NewGuid();


    }
}
