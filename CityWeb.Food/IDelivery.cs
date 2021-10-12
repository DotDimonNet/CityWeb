using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Entities;

namespace CityWeb.Food
{
    public interface IDelivery
    {
        public DeliveryServiceType DeliveryService { get; set; }
        public double DeliveryPrise { get; set; }
        public Address DeliveryAddress { get; set; }
    }
}
