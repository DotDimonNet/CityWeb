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
        public Guid EventId { get; set; }
        public Guid PriceId { get; set; }
        public bool isAvailable { get; set; }
        public string Title { get; set; }
        public string EventTitle { get; set; }
        public double Total { get; set; }
        public double Value { get; set; }
        public double Tax { get; set; }
        public double VAT { get; set; }
        
    }
}
