using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Domain.DTO.EnterteinmentDTO;
using CityWeb.Domain.Entities;

namespace CityWeb.Domain.ValueTypes
{
    public class EntertainmentBuilderResult
    {
        //Step1
        public string EntertainmentTitle { get; set; }
        public string Description { get; set; }
        //Step2
        public EventModelDTO Event { get; set; }
        
        
    }
}
