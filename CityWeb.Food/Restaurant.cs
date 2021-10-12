using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Infrastructure;
using CityWeb.Entities;

namespace CityWeb.Food
{
    public class Restaurant 
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

        // Restaurant
        public string RestaurantName { get; set; }
        public IEnumerable<Dish> Order { get; set; }
        public Address RestaurantAdress { get; set; }
        public int FreePlaces { get; set; }
        public DateTime OpenTime { get; set; }
        public DateTime CloseTime { get; set; }

       
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

        // Method
        public void OrderPlace()
        {
            if (FreePlaces != 0)
            {
                FreePlaces--;
            }
            else
            {
                Console.WriteLine("All places are busy");
            }
        }

    }
}
