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
        public Task<IEnumerable<string>> GetEventTitlesFromEntertainment(GetEventsFromEntertainmentsDTO entModel);
        public Task<EventModel> GetEventFromEventTitles(GetEventFromEventsDTO eventModel);  
        public Task<EntertainmentModel> AddEntertainmentModel(AddEntertainmentModelDTO addData);//Dont touch
        public Task<EventModel> AddEventModel(AddEventModelDTO addData);//Dont touch
        public Task<bool> DeleteEventModel(DeleteEventDTO deleteData);
        public Task<bool> DeleteEntertainmentModel(DeleteEntertainmentDTO deleteData);
        public Task<EventModel> UpdateEventModel(UpdateEventDTO updateEvent);
        public Task<EntertainmentModel> UpdadeEntertainmentModel(UpdateEntertainmentDTO updateData);//Dont touch
    }
}