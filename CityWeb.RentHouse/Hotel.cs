using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Infrastructure;
using CityWeb.Entities;
using CityWeb.Infrastructure.Interfaces;

namespace CityWeb.RentHouse
{
    class Hotel 
    {
        //interface props
        public Guid ID { get ; set ; }
        public string Title { get; set; }
        public double Price { get ; set ; }
        public double CurrentDiscount { get ; set ; }
        public double MaxDiscount { get ; set ; }
        public double DiscountMoneyStep { get ; set ; }
        public DateTime RealizationDate { get ; set ; }
        public double SpentMoney { get ; set ; }
        public Rating Rating { get; set; }
        //class props
        public Address Address { get; set; }
        public int MaxPlacesAmount { get; set; }
        public int FreePlacelAmount { get; set; }
        public IEnumerable<IUser> Residents { get; set; }
        public double PricePerNight { get; set; }
        public int NightCount { get; set; }


        public void GetFreePlaceAmount()
        {
            FreePlacelAmount = MaxPlacesAmount - Residents.Count();
        }
        public void Buy()
        {
            throw new NotImplementedException();
        }

        public void GetPrice()
        {
            Price = PricePerNight * NightCount;
        }
    }
}
