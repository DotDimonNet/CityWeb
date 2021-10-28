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
        public async Task<EntertainmentModelDTO> UpdadeEntertainmentModel(UpdateEntertainmentDTO updateData)
        {
            var entertainment = await _context.Entertaiments.FirstOrDefaultAsync(x => x.Title == updateData.EntertainmentTitle);
            if(entertainment != null)
            {
                entertainment.Title = updateData.EntertainmentTitle;       
                

                _context.Update(entertainment);
                await _context.SaveChangesAsync();
                return entertainment.ToEntertainmentModelDTO();

            }
            
            else
            {
                throw new Exception("Error");
            }
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
                return false;
            }

        }
        public async Task<EntertainmentModelDTO> AddEntertainmentModel(AddEntertainmentModelDTO addData)
        {
            var entertainment = new EntertainmentModel()
            {
                Title = addData.EntertainmentTitle,
                Description = addData.Description
            };
            var entModel = await _context.Entertaiments.AddAsync(entertainment);
            await _context.SaveChangesAsync();
            return entModel.Entity.ToEntertainmentModelDTO();



        }
        public async Task<IEnumerable<string>> StepOne(ServiceModelDTO dtoService)
        {
            var service = await _context.Services.FirstOrDefaultAsync(x => dtoService.Entertaiments == x.Entertaiments);
            return service.Entertaiments.Select(x => x.Title);
        }
        public async Task<IEnumerable<string>> StepTwo(EntertainmentModelDTO entModel)
        {
            var entertainment = await _context.Entertaiments.FirstOrDefaultAsync(x => entModel.EntertainmentId == x.Id && x.WorkSchedule.EndTime != (DateTime.Now));
            return entertainment.Event.Select(x => x.Title);
        }

        
        






    }   
}
