using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Domain.Entities;

namespace CityWeb.Domain.DTO.EnterteinmentDTO
{
    public class EventModelDTO
    {
        public string Title { get; set; }
        public PriceModelDTO Price { get; set; }
        public string Description { get; set; }
        public bool isAvailable { get; set; }
        
    }
}
