using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.DTO.EnterteinmentDTO
{
    public class GetEventsFromEntertainmentsDTO
    {
        public Guid EntertainmentId { get; set; }
    }

    public class GetEventFromEventsDTO
    {
        public Guid EventId { get; set; }
        
    }
}
