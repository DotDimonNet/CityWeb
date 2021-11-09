﻿using CityWeb.Domain.Entities;
using CityWeb.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.DTO.NewsDTO
{
    public class NewsModelDTO
    {
        public virtual NewsType Type { get; set; }
    }
}
