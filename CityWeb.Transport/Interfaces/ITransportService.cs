using CityWeb.Infrastructure.Interfaces;
using CityWeb.Transport.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Transport.Interfaces
{
    public interface ITransportService : IServiceMetadata
    {
        public IEnumerable<IPrice> Pricelist { get; set; }
        public IEnumerable<IUser> GetUsersActivityForDateRange(DateTime start, DateTime end);
        public bool RateService(IUser user, IRating rating);
        public ITransportJourney Run(Guid userId, TransportType transportType, DateTime time, params IAddress[] addresses);
    }
}
