using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Domain.DTO.NewsDTO;

namespace CityWeb.Domain.Entities
{
    public class NewsItemModel : Entity, IDescribe
    {
        public string NewsServiceTitle { get; set; }
        public string Title { get ; set; }
        public string Description { get ; set ; }
        public string Image { get; set; }
    }
}
