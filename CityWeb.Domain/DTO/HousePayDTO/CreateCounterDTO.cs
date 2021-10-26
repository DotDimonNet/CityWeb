using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.DTO.HousePayDTO
{
    class CreateCounterDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Number { get; set; }
        public double StartCount { get; set; }
        public double EndCount { get; set; }

    }
}
