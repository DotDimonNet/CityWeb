using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Domain.DTO.EnterteinmentDTO;
using CityWeb.Domain.Entities;

namespace CityWeb.Infrastructure.Interfaces.Service
{
    public interface IEntertainmentService
    {
        public Task<IEnumerable<EventModelDTO>> GetEventsFromEntertainment(GetEventsFromEntertainmentsDTO entModel);
        public Task<EventModelDTO> GetEventFromEventTitles(GetEventFromEventsDTO eventModel);  
        public Task<EntertainmentModelDTO> AddEntertainmentModel(AddEntertainmentModelDTO addData);
        public Task<EventModelDTO> AddEventModel(AddEventModelDTO addData);
        public Task<bool> DeleteEventModel(DeleteEventDTO deleteData);
        public Task<bool> DeleteEntertainmentModel(DeleteEntertainmentDTO deleteData);
        public Task<EventModelDTO> UpdateEventModel(UpdateEventDTO updateEvent);
        public Task<EntertainmentModelDTO> UpdadeEntertainmentModel(UpdateEntertainmentDTO updateData);
    }
}