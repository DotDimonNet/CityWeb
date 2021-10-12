using CityWeb.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Entities
{
    public class FullPrice : IPrice
    {
        public double Tax { get; set; }
        public double VAT { get; set; }
        public double Price { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
