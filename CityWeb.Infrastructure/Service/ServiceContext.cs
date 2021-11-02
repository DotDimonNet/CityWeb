using CityWeb.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Infrastructure.Service
{
    public class ServiceContext : IServiceContext
    {
        private IEnumerable<IServiceMetadata> Services { get; set; } = new List<IServiceMetadata>();

        public IServiceMetadata GetService(string serviceName)
        {
            return Services.FirstOrDefault(x => x.Title == serviceName);
        }

        public void SetServices(IEnumerable<IServiceMetadata> services)
        {
            Services = services;
        }
    }
}
