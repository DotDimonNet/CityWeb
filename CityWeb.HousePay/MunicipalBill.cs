using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Entities;
using CityWeb.Infrastructure.Interfaces;

namespace CityWeb.HousePay
{
    public class MunicipallBill //: IService
    {
        public Guid ID { get; set; }
        public Address HouseAddress { get; set; }
        public string Title { get; set; }
        public DateTime RealizationDate { get; set; }
        public double SpentMoney { get; set; }
        public Rating Rating { get; set; }

        public IEnumerable<IPrice> Pricelist { get; set; }


    }
}
