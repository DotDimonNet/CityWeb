using CityWeb.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Food.Interface
{
    public interface IRestaurant : IDelivery
    {
        public string RestaurantName { get; set; }
        //public Address RestaurantAdress { get; set; }
        public int FreePlaces { get; set; }
        public DateTime OpenTime { get; set; }
        public DateTime CloseTime { get; set; }
    }
}
