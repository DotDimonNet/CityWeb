using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Entities;
using CityWeb.Infrastructure;

namespace CityWeb.Transport
{
    class MunicipalTransport : IService
    {
        public Guid ID { get; set; }
        public double CurrentDiscount { get; set; }
        public double MaxDiscount { get; set; }
        public double DiscountMoneyStep { get; set; }
        public DateTime RealizationDate  {get; set; }
        public double SpentMoney  {get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public MunicipalTransportType MunicipalTransportType { get; set; }
        public int Route { get; set; }
        public Rating Rating { get; set ; }

        public void Buy()
        {
            throw new NotImplementedException();
        }

        public void GetPrice()
        {
            throw new NotImplementedException();
        }
        public void BuyTicket()
        {

        }
    }
}
