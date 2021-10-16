using CityWeb.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Common.Repository
{
    public interface IDbContext
    {
        public Task InitializeContext();

        public IDbCollection<ITransportJourney> Journeys { get; set; }

    }
}
