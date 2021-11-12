using CityWeb.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.DTO
{
    public class ProductModelDTO
    {
        public Guid DeliveryId { get; set; }
        public string ProductName { get; set; }
        public string ProductType { get; set; }
        public string ProductImage { get; set; }
        public PriceModelDTO ProductPrice{ get; set; }
    }
}
