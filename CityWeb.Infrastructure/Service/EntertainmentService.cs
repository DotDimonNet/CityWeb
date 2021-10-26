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

        public EntertainmentModelDTO UpdadeEntertainmentModel(UpdateEntertainmentDTO updateData)
        {
            var entertainment =  _context.Entertaiments.FirstOrDefault(x => x.Title == updateData.EntertainmentTitle);
            if(entertainment != null)
            {
                entertainment.Title = updateData.EntertainmentTitle;
                entertainment.Description = updateData.Description;
                entertainment.EntertainmentType = updateData.Type;
                entertainment.Address = updateData.Address;

                _context.Update(entertainment);
                _context.SaveChanges();
                return entertainment.ToEntertainmentModelDTO();

            }
            
            else
            {
                throw new Exception("Error");
            }
        }

        public void Delete(DeleteEntertainmentDTO deleteData)
        {
            var entertainment = _context.Entertaiments.FirstOrDefault(x => x.Title == deleteData.Title);
            if(entertainment != null)
            {
                _context.Remove(entertainment);
                _context.SaveChanges();
                
                Console.WriteLine($"You deleted {entertainment.Title}");
            }
            else
            {
                throw new Exception("You cannot delete this Entertainment");
            }

        }



        /*
        public EntertainmentModelDTO AddEntertainmentModel(AddEntertainmentModelDTO addData)
        {
            var entertainment = _context.Entertaiments.FirstOrDefault(x => x.Title == addData.EntertainmentTitle);
            if (entertainment == null)
            {
                _context.Add(entertainment);
                _context.SaveChanges();
                return entertainment.ToAddEntertainmentModel();

            }
            
            else
            {
                throw new Exception("You cannot delete this Entertainment");
            }
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
