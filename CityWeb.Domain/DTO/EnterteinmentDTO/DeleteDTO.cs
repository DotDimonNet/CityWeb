using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Domain.Entities;
using CityWeb.Domain.Enums;

namespace CityWeb.Domain.DTO.EnterteinmentDTO
{
    public class DeleteEntertainmentDTO
    {
        
        public string Title { get; set; }
        
    }

    public class DeleteEventDTO
    {
        public string Title { get; set; }
        public string EventTitle { get; set; }
    }
}
