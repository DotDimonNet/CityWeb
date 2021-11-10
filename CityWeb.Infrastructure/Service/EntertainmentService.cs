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
        private readonly ILogger<EntertainmentService> _logger;

        public EntertainmentService(ApplicationContext context, IMapper mapper, ILogger<EntertainmentService> logger)
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
                    _context.Entertaiments.Update(entertainment);
                    await _context.SaveChangesAsync();
                    return _mapper.Map<EntertainmentModel, EntertainmentModelDTO>(entertainment);
                    

                }
                else
                {
                    _logger.LogError(ErrorModel.UpdateEntertainmentModelError);
                    throw new Exception(ErrorModel.UpdateEntertainmentModelError);
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
                var entertainment = await _context.Entertaiments.FirstOrDefaultAsync(x => x.Title == updateEvent.EntertainmentTitle);
                if (entertainment != null)
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
                        _logger.LogError(ErrorModel.UpdateEventModelError);
                        throw new Exception(ErrorModel.UpdateEventModelError);
                    }
                }
                else
                {
                    _logger.LogError(ErrorModel.UpdateEventModelEntertainmentError);
                    throw new Exception(ErrorModel.UpdateEventModelEntertainmentError);
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
                    _logger.LogError(ErrorModel.DeleteEntertainmentModelError);
                    throw new Exception(ErrorModel.DeleteEntertainmentModelError);
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
                var eventModel = await _context.Events.FirstOrDefaultAsync(x => x.Title == deleteData.Title);
                if (eventModel != null)
                {
                    _context.Remove(eventModel);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    _logger.LogError(ErrorModel.DeleteEventModel);
                    throw new Exception(ErrorModel.DeleteEventModel);
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
                    entertainment.Service = new ServiceModel();
                    await _context.Entertaiments.AddAsync(entertainment);
                    await _context.SaveChangesAsync();
                    return _mapper.Map<EntertainmentModel, EntertainmentModelDTO>(entertainment);
                }
                else
                {
                    _logger.LogError(ErrorModel.AddEntertainmentModelError);
                    throw new Exception(ErrorModel.AddEntertainmentModelError);
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
                        return _mapper.Map<EventModel, EventModelDTO>(eventModel);
                    }
                    else
                    {
                        _logger.LogError(ErrorModel.AddEventModelError);
                        throw new Exception(ErrorModel.AddEventModelError);
                    }
                    
                }
                else
                {
                    _logger.LogError(ErrorModel.AddEventModelEntertainmentError);
                    throw new Exception(ErrorModel.AddEventModelEntertainmentError);
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
                    _logger.LogError(ErrorModel.GetEventsFromEntertainmentError);
                    throw new Exception(ErrorModel.GetEventsFromEntertainmentError);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }  
        }

        public async Task<EventModelDTO> GetEventFromEvents(GetEventFromEventsDTO getEventModel)
        {
            try
            {
                var eventModel = await _context.Events.FirstOrDefaultAsync(x => getEventModel.Title == x.Title && getEventModel.isAvailable);
                if (eventModel != null)
                {
                    return _mapper.Map<EventModel, EventModelDTO>(eventModel);
                }
                _logger.LogError(ErrorModel.GetEventFromEventsError);
                throw new Exception(ErrorModel.GetEventFromEventsError);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }   
}
