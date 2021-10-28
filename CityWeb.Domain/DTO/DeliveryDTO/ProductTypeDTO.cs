using CityWeb.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.DTO
{
    public class ProductTypeDTO
    {
        public string DeliveryTitle { get; set; }
        public ProductType ProductType { get; set; }
    }
}
