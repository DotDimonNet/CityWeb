using CityWeb.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Food.Interface
{
    public interface IFoodMarket : IDelivery
    {
        public string MarketName { get; set; }
        public IAddress MarketAddress { get; set; }
        public DateTime OpenTime { get; set; }
        public DateTime CloseTime { get; set; }
    }
}
