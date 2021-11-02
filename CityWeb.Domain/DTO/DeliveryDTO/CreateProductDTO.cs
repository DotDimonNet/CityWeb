﻿using CityWeb.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.DTO
{
    public class CreateProductDTO
    {
        public string ProductName { get; set; }
        public virtual ProductType ProductType { get; set; }
        public string ProductImage { get; set; }
        public PriceModelDTO Price{ get; set; }
    }
}
