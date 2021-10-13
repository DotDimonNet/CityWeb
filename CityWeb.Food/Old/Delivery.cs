using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Entities;
using CityWeb.Infrastructure;

namespace CityWeb.Food
{
    public class Delivery<T> 
    {
        public Guid ID { get ; set ; }
        public string Title { get ; set ; }
        public double Price { get ; set ; }
        public double CurrentDiscount { get ; set ; }
        public double MaxDiscount { get ; set ; }
        public double DiscountMoneyStep { get ; set ; }
        public DateTime RealizationDate { get ; set ; }
        public double SpentMoney { get  ; set ; }
        public Rating Rating { get ; set ; }

        //Delivery
        public DeliveryServiceType DeliveryService { get; set; }
        public T DeliveryFrom { get; set; }
        public IEnumerable<Dish> Order { get; set; }
        public double DeliveryPrice { get; set; }
        public Address DeliveryAddress { get; set; }
        public double FreeDeliveryPrice { get; set; }

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
            if (FreeDeliveryPrice < Price)
            Price += DeliveryPrice;
        }
    }
}
