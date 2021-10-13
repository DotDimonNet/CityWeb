using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Infrastructure;

namespace CityWeb.Transport
{
    class MunicipalTransport
    {
        public Guid ID { get; set; }
        public double CurrentDiscount { get; set; }
        public double MaxDiscount { get; set; }
        public double DiscountMoneyStep { get; set; }
        public DateTime RealizationDate  {get; set; }
        public double SpentMoney  {get; set; }
        public double Rating  {get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        //public TransportType MunicipalTransportType { get; set; }
        //public IEnumerable<Route> Routes { get; set; }
        /*public void BuyTicket(Route route)
        {

        }*/
    }
}
