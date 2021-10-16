using CityWeb.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.RentHouse
{
    public interface IRentHouseService : IServiceMetadata
    {
        public IAddress Address { get; set; }
        public IEnumerable<IPrice> Pricelist { get; set; }
        public IEnumerable<IUser> GetUsersActivityForDateRange(DateTime start, DateTime end);
        public bool RateService(IUser user, IRating rating);

        //public ITransportJourney Run(Guid userId, TransportType transportType, DateTime time, params IAddress[] addresses);
    }
}
