﻿using CityWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.DTO.Transport.Taxi
{
    public class UpdateTaxiModelDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        //public virtual ServiceModel Service { get; set; }
    }
}
