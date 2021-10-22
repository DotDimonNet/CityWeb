using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Domain.Entities;
using CityWeb.Domain.Enums;

namespace CityWeb.Domain.DTO
{
    public class AddEntertainmentDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public EventType Type { get; set; }
        public PriceModel Price { get; set; }
    }
}
