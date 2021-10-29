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
using CityWeb.Infrastucture.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CityWeb.Infrastructure.Service
{
    public class EntertainmentService
    {
        private readonly ApplicationContext _context;

        public EntertainmentService(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<UpdateEntertainmentDTO> UpdadeEntertainmentModel(EntertainmentModelDTO updateData)
        {
            var entertainment = await _context.Entertaiments.FirstOrDefaultAsync(x => x.Title == updateData.EntertainmentTitle);
            if(entertainment != null)
            {
                entertainment.Title = updateData.EntertainmentTitle;       
                

                _context.Update(entertainment);
                await _context.SaveChangesAsync();
                return entertainment.ToUpdateEntertainmentModelDTO();

            }
            
            else
            {
                throw new Exception("Entertainment doesnt exists");
            }
            _context.Update(entertainment);
            await _context.SaveChangesAsync();
            return entertainment.ToUpdateEntertainmentModelDTO();
        }
        public async Task<UpdateEventDTO> UpdateEventModel(EventModelDTO updateEvent)
        {
            var entertainment = await _context.Entertaiments.FirstOrDefaultAsync(x => x.Title == updateEvent.Title);
            if (entertainment != null)
            {
                var events = await _context.Events.FirstOrDefaultAsync(x => x.Title == updateEvent.EventTitle && x.EntertaimentId== entertainment.Id);
                if (events != null)
                {
                    events.Title = updateEvent.EventTitle;
                    events.EventPrice.Tax = updateEvent.Tax;
                    events.EventPrice.Value = updateEvent.Value;
                    events.EventPrice.VAT = updateEvent.VAT;
                    

                    _context.Update(events);
                    await _context.SaveChangesAsync();
                    return events.ToUpdateEventModelDTO();
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
        public async Task<string> DeleteEntertainmentModel(DeleteEntertainmentDTO deleteData)
        {
            var entertainment = await _context.Entertaiments.FirstOrDefaultAsync(x => x.Title == deleteData.Title);
            if(entertainment != null)
            {
                _context.Remove(entertainment);
                await _context.SaveChangesAsync();
                return "Entertainment was deleted";
            }
            else
            {
                throw new Exception("Enterainment doesnt exists");
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
                    throw new Exception("Event doesnt exist");
                }
            }
            else
            {
                throw new Exception("Entertainment doesnt exist");
            }
        }
        public async Task<AddEntertainmentModelDTO> AddEntertainmentModel(EntertainmentModelDTO addData)
        {
            var entertainment = new EntertainmentModel()
            {
                Title = addData.EntertainmentTitle,
                Description = addData.Description
            };
            var entModel = await _context.Entertaiments.AddAsync(entertainment);
            await _context.SaveChangesAsync();
            return entModel.Entity.ToAddEntertainmentModelDTO();



        }
        public async Task<AddEventModelDTO> AddEventtModel(EventModelDTO addData)
        {
            var entertainment = await _context.Entertaiments.FirstOrDefaultAsync(x => x.Title == addData.Title);
            if (entertainment != null)
            {
                var events = await _context.Events.FirstOrDefaultAsync(x => x.Title == addData.EventTitle);
                if(events == null)
                {
                    var dto = new EventModel()
                    {
                        Title = addData.EventTitle,
                        EventPrice = new PriceModel()
                        {
                            Value = addData.Value,
                            Tax = addData.Tax,
                            VAT = addData.VAT
                        }
                    };
                    var eventModel = await _context.AddAsync(dto);
                    await _context.SaveChangesAsync();
                    return eventModel.Entity.ToAddEventModelDTO();
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
        public async Task<IEnumerable<string>> SelectEntertainment(SelectEntertainmentDTO entModel)
        {
            var entertainment = await _context.Entertaiments.FirstOrDefaultAsync(x => entModel.EntertainmentId == x.Id);
            return entertainment.Event.Select(x => x.Title);
        }
        public async Task<EventModelDTO> SelectEvent(SelectEventDTO eventModel)
        {
            var events = await _context.Events.FirstOrDefaultAsync(x => eventModel.EventId == x.Id && x.isAvailable == true);
            return events.ToEventModelDTO();
        }
        //public async Task<PayEventDTO> PaymentOfEvent(EventModelDTO eventModel)
        //{
        //    var pay = _context.Payments.Where(x => eventModel.EventId == x.ProductId);
        //    return pay.Where(x => x.Id == )
        //}











    }   
}
