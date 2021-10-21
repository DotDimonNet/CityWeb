using CityWeb.Infrastructure.Enums;
using CityWeb.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Infrastructure.Interfaces
{
    public interface IEventPayment //: IBaseDBO
    {
        public Guid RatingId { get; set; }
        public Guid PaymentId { get; set; }
        public Guid OwnerId { get; set; }
        public EventType EventType { get; set; }

    }
}
