using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Infrastructure;

namespace CityWeb.Transport
{
    class CarSharing : CityWeb.Infrastructure.IService
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public double CurrentDiscount { get; set; }
        public double MaxDiscount { get; set; }
        public double DiscountMoneyStep { get; set; }
        public DateTime RealizationDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double SpentMoney { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Rating { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


    }
}
