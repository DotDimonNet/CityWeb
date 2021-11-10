using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Domain.Entities;
using CityWeb.Domain.Enums;

namespace CityWeb.Domain.DTO.EnterteinmentDTO
{
    public class UpdateEntertainmentDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public AddressModelDTO Address { get; set; }


    }
    public class UpdateEventDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public PriceModelDTO Price { get; set; }
        public bool isAvailable { get; set; }
    }
}
