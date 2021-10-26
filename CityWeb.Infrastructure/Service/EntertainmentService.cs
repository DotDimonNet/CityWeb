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

        public EntertainmentService(ApplicationContext context, EntertainmentBuilderResult builder)
        {
            _context = context;
        }

        public async Task<EntertainmentModelDTO> UpdadeEntertainmentModel(UpdateEntertainmentDTO updateData)
        {
            var entertainment = await _context.Entertaiments.FirstOrDefaultAsync(x => x.Title == updateData.EntertainmentTitle);
            if(entertainment != null)
            {
                entertainment.Title = updateData.EntertainmentTitle;
                entertainment.Description = updateData.Description;
                entertainment.EntertainmentType = updateData.Type;
                entertainment.Address = updateData.Address;

                _context.Update(entertainment);
                await _context.SaveChangesAsync();
                return entertainment.ToEntertainmentModelDTO();

            }
            
            else
            {
                throw new Exception("Error");
            }
        }

        public async void Delete(DeleteEntertainmentDTO deleteData)
        {
            var entertainment = await _context.Entertaiments.FirstOrDefaultAsync(x => x.Title == deleteData.Title);
            if(entertainment != null)
            {
                _context.Remove(entertainment);
                await _context.SaveChangesAsync();
                
                Console.WriteLine($"You deleted {entertainment.Title}");
            }
            else
            {
                throw new Exception("You cannot delete this Entertainment");
            }

        }



        /*
        public async Task<EntertainmentModelDTO> AddEntertainmentModel(AddEntertainmentModelDTO addData)
        {
            var entertainment = new EntertainmentModelDTO()
            {
                EntertainmentTitle = addData.EntertainmentTitle,
                Description = addData.Description
            };
            var newEnt = await _context.AddAsync(entertainment);
            return newToAddEntertainmentModel();



        }*/

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
