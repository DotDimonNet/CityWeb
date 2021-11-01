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

        public async Task<EntertainmentModel> UpdadeEntertainmentModel(UpdateEntertainmentDTO updateData)
        {
            var entertainments = await _context.Entertaiments.FirstOrDefaultAsync(x => x.Title == updateData.EntertainmentTitle);
            if (entertainments != null)
            {
                var updateEntertainmentModel = new EntertainmentModel()
                {
                    Title = updateData.EntertainmentTitle

                };
                _context.Update(entertainments);
                await _context.SaveChangesAsync();
                return updateEntertainmentModel;
            }
            else
            {
                throw new Exception("Entertainment Service is not exists");
            }
        }//Dont Touch

        public async Task<EventModel> UpdateEventModel(UpdateEventDTO updateEvent)
        {
            var entertainment = await _context.Entertaiments.FirstOrDefaultAsync(x => x.Title == updateEvent.EntertainmentTitle);
            if (entertainment != null)
            {
                var events = await _context.Events.FirstOrDefaultAsync(x => x.Title == updateEvent.EventTitle);
                if (events != null)
                {
                    var updateEventModel = new EventModel()
                    {
                        Title = updateEvent.EventTitle,
                        EventPrice = new PriceModel()
                        {
                            Value = updateEvent.Value,
                            Tax = updateEvent.Tax,
                            VAT = updateEvent.VAT
                        }
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


        }//Dont touch

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
        }//Dont Touch

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
        }// Dont Touch

        public async Task<EntertainmentModel> AddEntertainmentModel(AddEntertainmentModelDTO addData)
        {
            var entertainments = await _context.Entertaiments.FirstOrDefaultAsync(x => x.Title == addData.EntertainmentTitle);
            if(entertainments == null)
            {
                var addEntertainmentModel = new EntertainmentModel()
                {
                    Title = addData.EntertainmentTitle,
                    Description = addData.Description,
                    EntertainmentType = addData.Type
                };
                await _context.Entertaiments.AddAsync(addEntertainmentModel);
                await _context.SaveChangesAsync();
                return addEntertainmentModel;
            }
            else
            {
                throw new Exception("Entertainment Service was already created");
            }
            
        } //Dont touch

        public async Task<EventModel> AddEventModel(AddEventModelDTO addData)
        {
            var entertainments = await _context.Entertaiments.FirstOrDefaultAsync(x => x.Title == addData.Title);
            if (entertainments != null)
            {
                var events = await _context.Events.FirstOrDefaultAsync(x => x.Title == addData.EventTitle);
                if(events == null)
                {
                    var addEventModel = new EventModel()
                    {
                        Title = addData.EventTitle,
                        EventPrice = new PriceModel()
                        {
                            Value = addData.Value,
                            Tax = addData.Tax,
                            VAT = addData.VAT
                        }
                    };
                    var eventModel = await _context.AddAsync(addEventModel);
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
        }//Dont Touch

        public async Task<IEnumerable<string>> GetEventTitlesFromEntertainment(GetEventsFromEntertainmentsDTO entModel)
        {
            var entertainment = await _context.Entertaiments.FirstOrDefaultAsync(x => entModel.EntertainmentId == x.Id);
            return entertainment.Event.Select(x => x.Title);
        }//Dont Touch

        public async Task<EventModel> GetEventFromEventTitles(GetEventFromEventsDTO eventModel)
        {
            var events = await _context.Events.FirstOrDefaultAsync(x => eventModel.EventId == x.Id && x.isAvailable == true);
            return events;
        }//Dont Touch

        //public async Task<PayEventDTO> PaymentOfEvent(EventModelDTO eventModel)
        //{
        //    var pay = _context.Payments.Where(x => eventModel.EventId == x.ProductId);
        //    return pay.Where(x => x.Id == )
        //}











    }   
}
