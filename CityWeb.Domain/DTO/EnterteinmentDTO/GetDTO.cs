using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.DTO.EnterteinmentDTO
{
    public class GetEventsFromEntertainmentsDTO
    {
        public string Title { get; set; }
    }

    public class GetEventFromEventsDTO
    {
        public string Title { get; set; }
        public bool isAvailable { get; set; }
    }
}
