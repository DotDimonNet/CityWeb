using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.DTO.EnterteinmentDTO
{
    public class GetEventsFromEntertainmentsDTO
    {
        public string EntertainmentTitle { get; set; }
    }

    public class GetEventFromEventsDTO
    {
        public string EventTitle { get; set; }
        public double Total { get; set; }
        public bool isAvailable { get; set; }
    }
}
