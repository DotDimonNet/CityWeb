using CityWeb.Domain.Entities;
using CityWeb.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.DTO.NewsDTO
{
    public class DeleteNewsServiceDTO
    {
        public string ServiceTitle { get; set; } 
        public string Description { get; set; }
        public NewsType Type { get; set; }
    }
}
