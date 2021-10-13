using CityWeb.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.RentHouse
{
    public class RentHouseService : IRentHouseService
    {
        private readonly IServiceContext _context;
        private readonly ILogger<IRentHouseService> _logger;
        public IEnumerable<IPrice> Pricelist { get ; set ; }
        public bool IsActive { get ; set ; }
        public string Version { get ; set ; }
        public Guid Id { get ; set ; }
        public DateTime Created { get ; set ; }
        public DateTime Modified { get ; set ; }
        public string Title { get ; set ; }
        public string Description { get ; set ; }
        public IAddress Address { get ; set ; }

        public RentHouseService(IServiceContext context, ILogger<IRentHouseService> logger)
        {
            _context = context;
            _logger = logger;
            Pricelist = GetInitialPricesForServiceUsage();
        }
        private static IEnumerable<IPrice> GetInitialPricesForServiceUsage()
        {
           
            throw new NotImplementedException();
            /*var prices = new List<IPrice>();
            foreach (var type in Enum.GetValues(typeof(TransportType)).Cast<TransportType>())
            {
                prices.Add(new FullPrice()
                {
                    Tax = 3,
                    VAT = 0.1,
                    Price = (int)type * 10,
                    Title = $"{type}",
                    Description = $"Paid for usage transport service with {type} type."
                });
            }
            return prices;*/
        }

        public IEnumerable<IUser> GetUsersActivityForDateRange(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public bool RateService(IUser user, IRating rating)
        {
            throw new NotImplementedException();
        }
    }
}
