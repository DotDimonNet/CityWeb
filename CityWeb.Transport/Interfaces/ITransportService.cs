using CityWeb.Infrastructure.Interfaces;
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
        public Task<bool> RateService(IUser user, IRating rating);
        public ITransportJourney Run(Guid userId, IVehicle vehicle, DateTime time, params IAddress[] addresses);
    }
}
