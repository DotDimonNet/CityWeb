using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Entities;

namespace CityWeb.Infrastructure
{
    public interface IService
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public double CurrentDiscount { get; set; } //int?
        public double MaxDiscount { get; set; }
        public double DiscountMoneyStep { get; set; }
        public DateTime RealizationDate { get; set; }
        public double SpentMoney  { get; set; }
        public Rating Rating { get; set; }
        public void GetPrice();
        public void Buy();

        
    }   
}

