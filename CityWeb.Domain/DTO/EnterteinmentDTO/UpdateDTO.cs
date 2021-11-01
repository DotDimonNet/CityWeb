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
        public string EntertainmentTitle { get; set; }
        
    }
    public class UpdateEventDTO
    {
        public string EntertainmentTitle { get; set; }
        public string EventTitle { get; set; }
        public double VAT { get; set; }
        public double Value { get; set; }
        public double Tax { get; set; }
    }
}
