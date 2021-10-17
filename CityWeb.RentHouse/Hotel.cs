using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Infrastructure;
using CityWeb.Entities;
using CityWeb.Infrastructure.Interfaces;
using CityWeb.RentHouse.Interfaces;

namespace CityWeb.RentHouse
{
    /*public class Hotel : IHotel
    {
        public HotelRoomType RoomType { get ; set ; }
        public IDictionary<HotelRoomType, int> RoomsQuantity { get ; set ; }
        public Infrastructure.Interfaces.Address Address { get ; set ; }
        public IEnumerable<Price> Pricelist { get ; set ; }
        public bool IsActive { get ; set ; }
        public string Version { get ; set ; }
        public Guid Id { get ; set ; }
        public DateTime Created { get ; set ; }
        public DateTime Modified { get ; set ; }
        public string Title { get ; set ; }
        public string Description { get ; set ; }

        private static IEnumerable<Price> GetInitialPricesForServiceUsage()
        {
            var prices = new List<Price>();
            foreach (var type in Enum.GetValues(typeof(HotelRoomType)).Cast<HotelRoomType>())
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
            return prices;
        }
        public IEnumerable<IUser> GetUsersActivityForDateRange(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public bool RateService(IUser user, Infrastructure.Interfaces.Rating rating)
        {
            throw new NotImplementedException();
        }
    }*/
}
