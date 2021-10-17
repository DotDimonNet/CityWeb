using CityWeb.Infrastructure.Enums;
using CityWeb.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CityWeb.Entertainment.Interfaces
{
    public interface IEventService : IServiceMetadata
    {
        public IEnumerable<IPrice> Pricelist { get; set; }
        public bool RateService(IUser user, IRating rating);
        public IEventPaymentHistory Run(Guid userId, EventType eventType, DateTime time );
    }
}
