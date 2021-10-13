using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Entertainment.Enums;
using CityWeb.Infrastructure.Interfaces;

namespace CityWeb.Entertainment.Interfaces
{
    public interface IEventPayment : IBaseDBO
    {
        public Guid RatingId { get; set; }
        public Guid PaymentId { get; set; }
        public Guid OwnerId { get; set; }
        public EventType EventType { get; set; }

    }
}
