using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Entertainment.Enums;
using CityWeb.Infrastructure.Interfaces;

namespace CityWeb.Entertainment.Interfaces
{
    public interface IEventService : IServiceMetadata
    {
        public IEnumerable<IPrice> Pricelist { get; set; }
        public bool RateService(IUser user, IRating rating);
        public IEventPayment Run(Guid userId, EventType eventType, DateTime time );
    }
}
