using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Domain.DTO.EnterteinmentDTO;

namespace CityWeb.Infrastructure.Interfaces.Service
{
    public interface IEntertainmentService
    {
        public Task<IEnumerable<string>> GetEventTitlesFromEntertainment(GetEventsFromEntertainmentsDTO entModel);
        public Task<EventModelDTO> GetEventFromEventTitles(GetEventFromEventsDTO eventModel);  
        public Task<AddEntertainmentModelDTO> AddEntertainmentModel(EntertainmentModelDTO addData);
        public Task<AddEventModelDTO> AddEventtModel(EventModelDTO addData);
        public Task<bool> DeleteEventModel(DeleteEventDTO deleteData);
        public Task<string> DeleteEntertainmentModel(DeleteEntertainmentDTO deleteData);
        public Task<UpdateEventDTO> UpdateEventModel(EventModelDTO updateEvent);
        public Task<UpdateEntertainmentDTO> UpdadeEntertainmentModel(EntertainmentModelDTO updateData);
    }
}