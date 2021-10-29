using CityWeb.Infrastucture.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Domain.DTO.HousePayDTO;
using CityWeb.Domain.Entities;

namespace CityWeb.Infrastructure.Service
{
    public class HousePayService
    {
        private readonly ApplicationContext _context;
        public HousePayService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<CounterModel> CreateCounterModel(AddCounterModelDTO counterModel)
        {
            var counter = new CounterModel()
            {
                Number = counterModel.Number,
                StartCount = counterModel.StartCount,
            };

            var counterEntity = _context.Counters.Add(counter);
            await _context.SaveChangesAsync();

            return counterEntity.Entity;
        }

        public async Task<bool> DeleteCounterModel(DeleteCounterModelDTO deleteCounterModel)
        {
            var counter = _context.Counters.FirstOrDefault(x => x.Number == deleteCounterModel.Number);
            if (counter != null)
            {
                _context.Remove(counter);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                throw new Exception("Counter was not created!");
            }
        }
    }
}

