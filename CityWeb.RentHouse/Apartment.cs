using CityWeb.Entities;
using CityWeb.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.RentHouse
{
    class Apartment
    {
        //interface props
        public Guid ID { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public double CurrentDiscount { get; set; }
        public double MaxDiscount { get; set; }
        public double DiscountMoneyStep { get; set; }
        public DateTime RealizationDate { get; set; }
        public double SpentMoney { get; set; }
        //class props
        Address HotelAddress { get; set; }
        public DateTime OpenTime { get; set; }
        public DateTime CloseTime { get; set; }
        public Rating Rating { get; set; }
        public Address Address { get; set; }
        public double PricePerMonth { get; set; }
        public int MonthCount { get; set; }

        public void Buy()
        {
            throw new NotImplementedException();
        }

        public void GetPrice()
        {
            Price = MonthCount * PricePerMonth;
        }


    }
}
