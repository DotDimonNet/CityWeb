﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Infrastructure;
using CityWeb.Entities;

namespace CityWeb.Transport 
{
    public class Taxi : CityWeb.Infrastructure.IService
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public double CurrentDiscount { get; set; }
        public double MaxDiscount { get; set; }
        public double DiscountMoneyStep { get; set; }
        public DateTime RealizationDate { get; set; }
        public double SpentMoney { get; set; }
        public double Rating { get; set; }
        public Address StartAddress { get; set; }
        public Address EndAddress { get; set; }
        public double TripRange { get; set; }
        public void PayTrip()
        {
            
        }
    }
}
