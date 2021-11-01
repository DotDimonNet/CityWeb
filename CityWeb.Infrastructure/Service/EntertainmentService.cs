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
            var entertainments = await _context.Entertaiments.FirstOrDefaultAsync(x => x.Title == updateData.EntertainmentTitle);
            if (entertainments != null)
            {
                var updateEntertainmentModel = new EntertainmentModelDTO()
                {
                    EntertainmentTitle = updateData.EntertainmentTitle

                };
                _context.Update(entertainments);
                await _context.SaveChangesAsync();
                return updateEntertainmentModel;
            }
            else
            {
                throw new Exception("Entertainment Service is not exists");
            }
        }

        public async Task<EventModelDTO> UpdateEventModel(UpdateEventDTO updateEvent)
        {
            var entertainment = await _context.Entertaiments.FirstOrDefaultAsync(x => x.Title == updateEvent.EntertainmentTitle);
            if (entertainment != null)
            {
                var events = await _context.Events.FirstOrDefaultAsync(x => x.Title == updateEvent.EventTitle);
                if (events != null)
                {
                    var updateEventModel = new EventModelDTO()
                    {
                        Title = updateEvent.EventTitle,
                        Value = updateEvent.Value,
                        Tax = updateEvent.Tax,
                        VAT = updateEvent.VAT
                    };


                    _context.Update(events);
                    await _context.SaveChangesAsync();
                    return updateEventModel;
                }
                else
                {
                    throw new Exception("Event was not created!");
                }
                
            }
            else
            {
                throw new Exception("Entertainment was not created!");
            }


        }

        public async Task<bool> DeleteEntertainmentModel(DeleteEntertainmentDTO deleteData)
        {
            var entertainment = await _context.Entertaiments.FirstOrDefaultAsync(x => x.Title == deleteData.Title);
            if(entertainment != null)
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
            var entertainment = await _context.Entertaiments.FirstOrDefaultAsync(x => x.Title == deleteData.Title);
            if (entertainment != null)
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
            else
            {
                throw new Exception("Entertainment doesn't exist");
            }
        }

        public async Task<EntertainmentModelDTO> AddEntertainmentModel(AddEntertainmentModelDTO addData)
        {
            var entertainments = await _context.Entertaiments.FirstOrDefaultAsync(x => x.Title == addData.EntertainmentTitle);
            if(entertainments == null)
            {
                var addEntertainmentModel = new EntertainmentModelDTO()
                {
                    EntertainmentTitle = addData.EntertainmentTitle,
                    Description = addData.Description,
                    Type = addData.Type
                };
                await _context.Entertaiments.AddAsync(entertainments);
                await _context.SaveChangesAsync();
                return addEntertainmentModel;
            }
            else
            {
                throw new Exception("Entertainment Service was already created");
            }
            
        }

        public async Task<EventModelDTO> AddEventModel(AddEventModelDTO addData)
        {
            var entertainments = await _context.Entertaiments.FirstOrDefaultAsync(x => x.Title == addData.Title);
            if (entertainments != null)
            {
                var events = await _context.Events.FirstOrDefaultAsync(x => x.Title == addData.EventTitle);
                if(events == null)
                {
                    var addEventModel = new EventModelDTO()
                    {
                        Title = addData.EventTitle,
                        Value = addData.Value,
                        VAT = addData.VAT,
                        Tax = addData.Tax
                    };
                    var eventModel = await _context.Events.AddAsync(events);
                    await _context.SaveChangesAsync();
                    return addEventModel;
                }
                else
                {
                    throw new Exception("Event already exists");
                }
            }
            else
            {
                throw new Exception("Entertainment doesnt exist");
            }
        }

        public async Task<IEnumerable<string>> GetEventTitlesFromEntertainment(GetEventsFromEntertainmentsDTO entModel)
        {
            var entertainment = await _context.Entertaiments.FirstOrDefaultAsync(x => entModel.EntertainmentTitle == x.Title);
            return entertainment.Event.Select(x => x.Title);
        }

        public async Task<EventModelDTO> GetEventFromEventTitles(GetEventFromEventsDTO eventModel)
        {
            var events = await _context.Events.FirstOrDefaultAsync(x => eventModel.EventTitle == x.Title && x.isAvailable == true);
            await _context.SaveChangesAsync();
            return events.ToEventModelDTO();
        }//Dont Touch

        //public async Task<PayEventDTO> PaymentOfEvent(EventModelDTO eventModel)
        //{
        //    var pay = _context.Payments.Where(x => eventModel.EventId == x.ProductId);
        //    return pay.Where(x => x.Id == )
        //}











    }   
}
