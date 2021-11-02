using CityWeb.Infrastucture.Data;
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
using CityWeb.Infrastructure.Interfaces.Service;

namespace CityWeb.Infrastructure.Service
{
    public class HousePayService : IHousePayService
    {
        private readonly ApplicationContext _context;
        public HousePayService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<HousePayModel> CreateHousePayModel(CreateHousePayModelDTO housePayModel)
        {
            try
            {
                var housePay = await _context.HousePays.FirstOrDefaultAsync(x => x.Title == housePayModel.Title);
                if (housePay == null)
                {
                    housePay.CreateFromDTO(housePayModel);
                    await _context.HousePays.AddAsync(housePay);
                    await _context.SaveChangesAsync();
                    return housePay;
                }
                else
                    throw new Exception("HousePay does not exist");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteHousePay(HousePayModelDTO dtoModel)
        {
            var housePay = await _context.HousePays.FirstOrDefaultAsync(x => x.Title == dtoModel.Title);
            if (housePay != null)
            {
                _context.Remove(housePay);
                _context.SaveChanges();
                return true;
            }
            else
            {
                throw new Exception("Company does not exist!");
            }
        }
        public async Task<ICollection<HousePayModelDTO>> GetAllHousePay()
        {
            return await _context.HousePays.Select(x => x.ToHousePayModelDTO()).ToListAsync();
        }
        public IEnumerable<HousePayModelDTO> GetHousePays(int skip = 0, int take = 20)
        {
            return _context.HousePays.Skip(skip).Take(take).Select(x => x.ToHousePayModelDTO());
        }
        public async Task<CounterModel> CreateCounterModel(CreateCounterModelDTO counterModel)
        {
            var counter = counterModel.CreateCounterFromlDTO();

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
                throw new Exception("Counter does not exist");
        }
        public async Task<ICollection<CounterModelDTO>> GetAllCounters()
        {
            return await _context.Counters.Select(x => x.ToCounterModelDTO()).ToListAsync();
        }
        public IEnumerable<CounterModelDTO> GetCounters(int skip = 0, int take = 20)
        {
            return _context.Counters.Skip(skip).Take(take).Select(x => x.ToCounterModelDTO());
        }
    }
}

