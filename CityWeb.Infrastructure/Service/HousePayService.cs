﻿using CityWeb.Infrastucture.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Domain.Entities;
using CityWeb.Domain.DTO;
using CityWeb.Domain.Enums;
using CityWeb.Infrastructure.Extentions;
using Microsoft.EntityFrameworkCore;

namespace CityWeb.Infrastructure.Service
{
    public class HousePayService
    {
        private readonly ApplicationContext _context;
        public HousePayService(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<CounterModel> CreateCounterModel(CreateCounterModelDTO counterModel)
        {
            var counter = counterModel.FromCreateCounterModelDTO();

            await _context.Counters.AddAsync(counter);
            await _context.SaveChangesAsync();
            return counter;
        }
        public async Task<bool> DeleteCounterModel(DeleteCounterModelDTO deleteCounterModel)
        {
            var counter = await _context.Counters.FirstOrDefaultAsync(x => x.Number == deleteCounterModel.Number);
            if (counter != null)
            {
                _context.Remove(counter);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                throw new Exception("Counter does not exist!");
            }
        }
        public async Task<UpdateCounterModelDTO> UpdateCounterModel(UpdateCounterModelDTO updateCounterModelDTO)
        {
            var counter = await _context.Counters.FirstOrDefaultAsync(x => x.Number == updateCounterModelDTO.Number);
            if (counter != null)
            {
                counter.StartCount = updateCounterModelDTO.StartCount;
                counter.EndCount = updateCounterModelDTO.EndCount;
                counter.PriceByItem = updateCounterModelDTO.PriceByItem;
                _context.Update(counter);
                await _context.SaveChangesAsync();
                return counter.ToUpdateCounterModelDTO();
            }
            else
                throw new Exception("Couter does not exist");
        }
    }
}

