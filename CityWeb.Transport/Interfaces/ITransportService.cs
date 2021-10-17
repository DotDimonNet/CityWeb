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
        /*public IEnumerable<Price> Pricelist { get; set; }
        public IEnumerable<IUser> GetUsersActivityForDateRange(DateTime start, DateTime end);
        public bool RateService(IUser user, Rating rating);
        public TransportJourney Run(Guid userId, Vehicle vehicle, DateTime time, params Address[] addresses);*/
    }
}
