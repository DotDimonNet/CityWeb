﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.DTO
{
    public class ProductPriceFilterDTO
    {
        public string Title { get; set; }
        public double MinPrice { get; set; }
        public double MaxPrice { get; set; }
    }
}
