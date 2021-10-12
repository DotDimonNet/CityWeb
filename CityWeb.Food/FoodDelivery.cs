using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Infrastructure;




namespace CityWeb.Food
{
    class FoodDelivery : IService
    {
        public Guid ID { get ; set ; }
        public string Title { get ; set ; }
        public double Price { get ; set; }
        public double CurrentDiscount { get ; set; }
        public double MaxDiscount { get ; set ; }
        public double DiscountMoneyStep { get ; set ; }
        public DateTime RealizationDate { get ; set ; }
        public double SpentMoney { get ; set ; }
        public double Rating { get ; set ; }

        public TypeOfDeliveryService DeliveryService { get; set; }
       // public Resraurant DeliveryFrom {get; set; }
        public double DeliveryPrise { get; set; }
        //public Address DeliveryAddress { get; set; }
    }
}
