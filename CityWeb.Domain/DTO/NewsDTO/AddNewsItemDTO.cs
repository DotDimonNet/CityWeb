using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Domain.Enums;

namespace CityWeb.Domain.DTO.NewsDTO
{
    public class AddNewsItemDTO
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
