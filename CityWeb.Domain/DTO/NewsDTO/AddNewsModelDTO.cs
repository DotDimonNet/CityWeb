using CityWeb.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.DTO.NewsDTO
{
    public class AddNewsModelDTO
    {
        public string ServiceTitle { get; set; }
        public string Description { get; set; }
        public NewsType Type { get; set; }
    }
}
