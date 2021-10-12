using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Entities;
using CityWeb.Infrastructure;


namespace CityWeb.Food
{
    public class FoodMarket : IService
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public double CurrentDiscount { get; set; }
        public double MaxDiscount { get; set; }
        public double DiscountMoneyStep { get; set; }
        public DateTime RealizationDate { get; set; }
        public double SpentMoney { get; set; }
        public Rating Rating { get; set; }

        //FoodMarket
        public string MarketName { get; set; }
        public Address MarketAddress { get; set; }
        public DateTime OpenTime { get; set; }
        public DateTime CloseTime { get; set; }
        public IEnumerable<Dish> Order { get; set; }

        
        public void Buy()
        {
            throw new NotImplementedException();
        }

        public void GetPrice()
        {
            foreach (var item in Order)
            {
                Price += item.DishPrice * item.DishCount;
            }
        }
    }
}
