using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Food.Interface;
using CityWeb.Infrastructure.Interfaces;

namespace CityWeb.Food
{
    public interface IDelivery : IServiceMetadata
    {
        public string DeliveryServiceName { get; set; }
        public IEnumerable<IDish> Order { get; set; }
        public double DeliveryPrice { get; set; }
        //public Address DeliveryAddress { get; set; }
        public double FreeDeliveryPrice { get; set; }
    }
}
