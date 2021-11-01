using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Domain.DTO;
using CityWeb.Domain.DTO.EnterteinmentDTO;
using CityWeb.Domain.Entities;
using CityWeb.Domain.ValueTypes;
using CityWeb.Infrastructure.Extentions;
using CityWeb.Infrastructure.Interfaces.Service;
using CityWeb.Infrastucture.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CityWeb.Infrastructure.Service
{
    public class EntertainmentService : IEntertainmentService
    {
        private readonly ApplicationContext _context;

        public EntertainmentService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<EntertainmentModelDTO> UpdadeEntertainmentModel(UpdateEntertainmentDTO updateData)
        {
            var entertainment = await _context.Entertaiments.FirstOrDefaultAsync(x => x.Title == updateData.EntertainmentTitle);
            if (entertainment != null)
            {
                var model = _context.Entertaiments.Update(entertainment.UpdateFromDTO(updateData));
                await _context.SaveChangesAsync();
                return model.Entity.ToEntertainmentModelDTO();
            }
            else
            {
                throw new Exception("Entertainment Service is not exists");
            }
        }

        public async Task<EventModelDTO> UpdateEventModel(UpdateEventDTO updateEvent)
        {
            var eventModel = await _context.Events.FirstOrDefaultAsync(x => x.Title == updateEvent.EventTitle);
            if (eventModel != null)
            {
                var model = _context.Events.Update(eventModel.UpdateFromDTO(updateEvent));
                await _context.SaveChangesAsync();
                return model.Entity.ToEventModelDTO();
            }
            else
            {
                throw new Exception("Event was not created!");
            }
        }

        public async Task<bool> DeleteEntertainmentModel(DeleteEntertainmentDTO deleteData)
        {
            var entertainment = await _context.Entertaiments.FirstOrDefaultAsync(x => x.Title == deleteData.Title);
            if (entertainment != null)
            {
                _context.Remove(entertainment);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                throw new Exception("Enterainment doesn't exists");
            }
        }

        public async Task<bool> DeleteEventModel(DeleteEventDTO deleteData)
        {
            
            var events = await _context.Events.FirstOrDefaultAsync(x => x.Title == deleteData.EventTitle);
            if(events != null)
            {
                _context.Remove(events);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                throw new Exception("Event doesn't exist");
            }
           
        }

        public async Task<EntertainmentModelDTO> AddEntertainmentModel(AddEntertainmentModelDTO addData)
        {
            var entertainment = await _context.Entertaiments.FirstOrDefaultAsync(x => x.Title == addData.EntertainmentTitle);
            if (entertainment == null)
            {
                var addEntModel = addData.ToEntertainmentModel();
                var model = await _context.Entertaiments.AddAsync(addEntModel);
                await _context.SaveChangesAsync();
                return model.Entity.ToEntertainmentModelDTO();
            }
            else
            {
                throw new Exception("Entertainment Service was already created");
            }
            
        }

        public async Task<EventModelDTO> AddEventModel(AddEventModelDTO addData)
        {    
            var events = await _context.Events.FirstOrDefaultAsync(x => x.Title == addData.EventTitle);
            if (events == null)
            {
                var addEventModel = addData.ToEventModel();
                var model = await _context.Events.AddAsync(addEventModel);
                await _context.SaveChangesAsync();
                return model.Entity.ToEventModelDTO();
            }
            else
            {
                throw new Exception("Event already exists");
            }
        }

        public async Task<IEnumerable<EventModelDTO>> GetEventsFromEntertainment(GetEventsFromEntertainmentsDTO entModel)
        {
            var entertainment = await _context.Entertaiments.FirstOrDefaultAsync(x => entModel.EntertainmentTitle == x.Title);
            if(entertainment != null)
            {
                return entertainment.Event.Select(x => x.ToEventModelDTO());
            }
            else
            {
                throw new Exception("Entertainment doesn't exists");
            }
            
        }

        public async Task<EventModelDTO> GetEventFromEventTitles(GetEventFromEventsDTO getEventModel)
        {
            var eventModel = await _context.Events.FirstOrDefaultAsync(x => getEventModel.EventTitle == x.Title && x.isAvailable);
            if(eventModel != null)
            {
                return getEventModel.ToEventModelDTO();
            }
            else
            {
                throw new Exception("Event doesn't exists");
            }
           
        }

    }   
}
