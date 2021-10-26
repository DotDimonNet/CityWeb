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
        public string Title { get; set; }
        public string ProductName { get; set; }
        public ProductType ProductType { get; set; }
        public string ProductImage { get; set; }
        public double Value { get; set; }
        public double Tax { get; set; }
        public double VAT { get; set; }
    }
}
