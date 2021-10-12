using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Infrastructure;
using CityWeb.Entities;

namespace CityWeb.Transport 
{
    public class Taxi : IService
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public double CurrentDiscount { get; set; }
        public double MaxDiscount { get; set; }
        public double DiscountMoneyStep { get; set; }
        public DateTime RealizationDate { get; set; }
        public double SpentMoney { get; set; }
        public Address StartAddress { get; set; }
        public Address EndAddress { get; set; }
        public double TripRange { get; set; }
        public Rating Rating { get; set; }

        public void Buy()
        {
            throw new NotImplementedException();
        }

        public void GetPrice()
        {
            throw new NotImplementedException();
        }
        public void PayTrip()
        {
            
        }
    }
}
