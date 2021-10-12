using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Entities;
using CityWeb.Infrastructure;

namespace CityWeb.Entertainment
{
    class Event : IService
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public double CurrentDiscount { get; set; } //int?
        public double MaxDiscount { get; set; }
        public double DiscountMoneyStep { get; set; }
        public DateTime RealizationDate { get; set; }
        public double SpentMoney { get; set; }
        public EventType Types { get; set; }
        public Rating Rating { get; set; }

        public void Buy()
        {
            throw new NotImplementedException();
        }

        public void GetPrice()
        {
            throw new NotImplementedException();
        }


        public void GetDiscount(double Price, double CurrentDiscount, double MaxDiscount, double DiscountMoneyStep)
        {

        }

        public void GetPrice(double Price, double CurrentDiscount)
        {

        }

        public void Payment()
        {
            
        }

        
    }
}
