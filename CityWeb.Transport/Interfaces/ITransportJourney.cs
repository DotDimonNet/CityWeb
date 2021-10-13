using CityWeb.Infrastructure.Interfaces;
using CityWeb.Transport.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Transport.Interfaces
{
    public interface ITransportJourney : IBaseDBO
    {
        public Guid RatingId { get; set; }
        public Guid PaymentId { get; set; }
        public Guid OwnerId { get; set; }
        public TransportType TransportType { get; set; }
        public IEnumerable<IAddress> Visited { get; set; }
    }
}
