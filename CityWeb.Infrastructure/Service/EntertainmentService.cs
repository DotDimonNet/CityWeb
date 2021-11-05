using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CityWeb.Domain.DTO;
using CityWeb.Domain.DTO.EnterteinmentDTO;
using CityWeb.Domain.Entities;
using CityWeb.Domain.Enums;
using CityWeb.Domain.ValueTypes;
using CityWeb.Infrastructure.Extentions;
using CityWeb.Infrastructure.Interfaces.Service;
using CityWeb.Infrastucture.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CityWeb.Infrastructure.Service
{
    public class EntertainmentService : IEntertainmentService
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<AccountService> _logger;

        public EntertainmentService(ApplicationContext context, IMapper mapper, ILogger<AccountService> logger)
        {
            _mapper = mapper;
            _context = context;
            _logger = logger;
        }

        public async Task<EntertainmentModelDTO> UpdadeEntertainmentModel(UpdateEntertainmentDTO updateData)
        {
            try
            {
                var entertainment = await _context.Entertaiments.FirstOrDefaultAsync(x => x.Title == updateData.Title);
                if (entertainment != null)
                {
                    _mapper.Map<UpdateEntertainmentDTO, EntertainmentModel>(updateData, entertainment);
                    Enum.TryParse(updateData.Type, out EntertainmentType type);
                    entertainment.Type = type;
                    _context.Entertaiments.Update(entertainment);
                    await _context.SaveChangesAsync();
                    var result = _mapper.Map<EntertainmentModel, EntertainmentModelDTO>(entertainment);
                    return result;
                }
                else
                {
                    _logger.LogError("You can't update Entertainment. Entertainment doesn't exist!");
                    throw new Exception("You can't update Entertainment. Entertainment doesn't exist!");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventModelDTO> UpdateEventModel(UpdateEventDTO updateEvent)
        {
            try
            {
                var eventModel = await _context.Events.FirstOrDefaultAsync(x => x.Title == updateEvent.Title);
                if (eventModel != null)
                {
                    _mapper.Map<UpdateEventDTO, EventModel>(updateEvent, eventModel);
                    _context.Events.Update(eventModel);
                    await _context.SaveChangesAsync();
                    return _mapper.Map<EventModel, EventModelDTO>(eventModel);
                }
                else
                {
                    _logger.LogError("You can't update Event. Event doesn't exist!");
                    throw new Exception("You can't update Event. Event doesn't exist!");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEntertainmentModel(DeleteEntertainmentDTO deleteData)
        {
            try
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
                    _logger.LogError("You can't delete Entertainment. Entertainment doesn't exist");
                    throw new Exception("You can't delete Entertainment. Entertainment doesn't exist");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEventModel(DeleteEventDTO deleteData)
        {
            try
            {
                var events = await _context.Events.FirstOrDefaultAsync(x => x.Title == deleteData.Title);
                if (events != null)
                {
                    _context.Remove(events);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    _logger.LogError("You can't delete Event. Event doesn't exist");
                    return await DeleteEventModel(deleteData);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            } 
        }

        public async Task<EntertainmentModelDTO> AddEntertainmentModel(AddEntertainmentModelDTO addData)
        {
            try
            {
                var entertainment = await _context.Entertaiments.FirstOrDefaultAsync(x => x.Title == addData.Title);
                if (entertainment == null)
                {
                    entertainment = _mapper.Map<AddEntertainmentModelDTO, EntertainmentModel>(addData);
                    Enum.TryParse(addData.Type, out EntertainmentType type);
                    entertainment.Type = type;
                    entertainment.Service = new ServiceModel();
                    await _context.Entertaiments.AddAsync(entertainment);
                    await _context.SaveChangesAsync();
                    var result = _mapper.Map<EntertainmentModel, EntertainmentModelDTO>(entertainment);
                    return result;
                }
                else
                {
                    _logger.LogError("You can't create Entertainment. Entertainment already exists");
                    throw new Exception("You can't create Entertainment. Entertainment already exists");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
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
                    var eventModel = await _context.Events.FirstOrDefaultAsync(x => x.Title == addData.Title);
                    if (eventModel == null)
                    {
                        eventModel = _mapper.Map<AddEventModelDTO, EventModel>(addData);
                        eventModel.Entertaiment = new EntertainmentModel();
                        eventModel.Entertaiment.Service = new ServiceModel();
                        await _context.Events.AddAsync(eventModel);
                        entertainment.Events.Add(eventModel);
                        await _context.SaveChangesAsync();
                        var result = _mapper.Map<EventModel, EventModelDTO>(eventModel);
                        return result;
                    }
                    else
                    {
                        _logger.LogError("You can't create Event. Event already exists");
                        throw new Exception("You can't create Event. Event already exists");
                    }
                    
                }
                else
                {
                    _logger.LogError("You can't create Event. Entertainment doesn't exist");
                    throw new Exception("You can't create Event. Entertainment already exists");
                }
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<IEnumerable<EventModelDTO>> GetEventsFromEntertainment(GetEventsFromEntertainmentsDTO entModel)
        {
            try
            {
                var entertainment = await _context.Entertaiments.FirstOrDefaultAsync(x => entModel.Title == x.Title);
                if (entertainment != null)
                {
                    return entertainment.Events.Select(x => _mapper.Map<EventModel, EventModelDTO>(x));

                }
                else
                {
                    _logger.LogError("You can't get Events. Entertainment doesn't exist");
                    throw new Exception("You can't get Events. Entertainment doesn't exist");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }  
        }

        public async Task<EventModelDTO> GetEventFromEventTitles(GetEventFromEventsDTO getEventModel)
        {
            try
            {
                var eventModel = await _context.Events.FirstOrDefaultAsync(x => getEventModel.Title == x.Title && getEventModel.isAvailable);
                if (eventModel != null)
                {
                    return _mapper.Map<EventModel, EventModelDTO>(eventModel);
                }
                _logger.LogError("You can't get Event. Event doesn't exist");
                throw new Exception("You can't get Event. Event doesn't exist");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }   
}
