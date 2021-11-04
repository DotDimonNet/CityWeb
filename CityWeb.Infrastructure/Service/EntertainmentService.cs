using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public EntertainmentService(ApplicationContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            
        }

        public async Task<EntertainmentModelDTO> UpdadeEntertainmentModel(UpdateEntertainmentDTO updateData)
        {

            var entertainment = await _context.Entertaiments.FirstOrDefaultAsync(x => x.Title == updateData.EntertainmentTitle);
            if (entertainment != null)
            {
                _mapper.Map<UpdateEntertainmentDTO, EntertainmentModel>(updateData, entertainment);
                _mapper.Map<AddressModelDTO, AddressModel>(updateData.Location, entertainment.Address);
                entertainment.EntertainmentType = await _context.EventTypes.FirstOrDefaultAsync(x => x.Name == updateData.Type);
                _context.Entertaiments.Update(entertainment);
                await _context.SaveChangesAsync();
                var result = _mapper.Map<EntertainmentModel, EntertainmentModelDTO>(entertainment);
                result.Location = _mapper.Map<AddressModel, AddressModelDTO>(entertainment.Address);
                result.Type = entertainment.EntertainmentType.Name.ToString();
                return result;
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
                _mapper.Map<UpdateEventDTO, EventModel>(updateEvent, eventModel);
                _mapper.Map<PriceModelDTO, PriceModel>(updateEvent.EventPrice, eventModel.EventPrice);

                _context.Events.Update(eventModel);
                await _context.SaveChangesAsync();
                var result = _mapper.Map<EventModel, EventModelDTO>(eventModel);
                result.EventPrice = _mapper.Map<PriceModel, PriceModelDTO>(eventModel.EventPrice);
                return result;
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
            try
            {
                var entertainment = await _context.Entertaiments.FirstOrDefaultAsync(x => x.Title == addData.EntertainmentTitle);
                if (entertainment == null)
                {
                    entertainment = _mapper.Map<AddEntertainmentModelDTO, EntertainmentModel>(addData);
                    entertainment.EntertainmentType = await _context.EventTypes.FirstOrDefaultAsync(x => x.Name == addData.Type);
                    entertainment.Address = _mapper.Map<AddressModelDTO, AddressModel>(addData.Location);
                    entertainment.Service = new ServiceModel();
                    await _context.Entertaiments.AddAsync(entertainment);
                    await _context.SaveChangesAsync();
                    var result = _mapper.Map<EntertainmentModel, EntertainmentModelDTO>(entertainment);
                    result.Type = entertainment.EntertainmentType.Name;
                    result.Location = _mapper.Map<AddressModel, AddressModelDTO>(entertainment.Address); 
                    return result;
                }
                else
                {
                    throw new Exception("Entertainment Service was already created");
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<EventModelDTO> AddEventModel(AddEventModelDTO addData)
        {
            try
            {
                var entertainment = await _context.Entertaiments.FirstOrDefaultAsync(x => x.Title == addData.EntertainmentTitle);
                if (entertainment != null)
                {
                    var eventModel = await _context.Events.FirstOrDefaultAsync(x => x.Title == addData.EventTitle);
                    if (eventModel == null)
                    {
                        eventModel = _mapper.Map<AddEventModelDTO, EventModel>(addData);
                        eventModel.EventPrice = _mapper.Map<PriceModelDTO, PriceModel>(addData.EventPrice);
                        eventModel.Entertaiment = new EntertainmentModel();
                        eventModel.Entertaiment.Service = new ServiceModel();
                        await _context.Events.AddAsync(eventModel);
                        entertainment.Events.Add(eventModel);
                        await _context.SaveChangesAsync();
                        var result = _mapper.Map<EventModel, EventModelDTO>(eventModel);
                        result.EventPrice = _mapper.Map<PriceModel, PriceModelDTO>(eventModel.EventPrice);
                        return result;
                    }
                    else
                    {
                        throw new Exception("Event already exists");
                    }
                    
                }
                else
                {
                    throw new Exception("Entertainment was not found");
                }
                
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            
        }

        public async Task<IEnumerable<EventModelDTO>> GetEventsFromEntertainment(GetEventsFromEntertainmentsDTO entModel)
        {
            var entertainment = await _context.Entertaiments.FirstOrDefaultAsync(x => entModel.EntertainmentTitle == x.Title);
            if(entertainment != null)
            {
                return  entertainment.Events.Select(x => _mapper.Map<EventModel, EventModelDTO>(x));
                
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
                return _mapper.Map<EventModel, EventModelDTO>(eventModel);
            }
            else
            {
                throw new Exception("Event doesn't exists");
            }
           
        }

    }   
}
