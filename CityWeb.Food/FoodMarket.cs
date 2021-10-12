using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Entities;
using CityWeb.Infrastructure;


namespace CityWeb.Food
{
    public class FoodMarket : IService, IDelivery
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public double CurrentDiscount { get; set; }
        public double MaxDiscount { get; set; }
        public double DiscountMoneyStep { get; set; }
        public DateTime RealizationDate { get; set; }
        public double SpentMoney { get; set; }
        //FoodMarket
        public string MarketName { get; set; }
        public Address MarketAddress { get; set; }
        public DateTime OpenTime { get; set; }
        public DateTime CloseTime { get; set; }
        //Delivery
        public DeliveryServiceType DeliveryService { get ; set ; }
        public double DeliveryPrise { get ; set ; }
        public Address DeliveryAddress { get ; set ; }
        public Rating Rating { get; set; }

        public void Buy()
        {
            throw new NotImplementedException();
        }

        public void GetPrice()
        {
            throw new NotImplementedException();
        }
    }
}
