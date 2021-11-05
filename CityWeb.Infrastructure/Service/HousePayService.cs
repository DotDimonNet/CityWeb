using CityWeb.Infrastucture.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Domain.Entities;
using CityWeb.Domain.DTO;
using CityWeb.Domain.Enums;
using CityWeb.Domain.ValueTypes;
using CityWeb.Infrastructure.Extentions;
using Microsoft.EntityFrameworkCore;
using CityWeb.Infrastructure.Interfaces.Service;
using AutoMapper;

namespace CityWeb.Infrastructure.Service
{
    public class HousePayService : IHousePayService
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        public HousePayService(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public HousePayBuilderResult SetupHousePayBuilderResult()
        {
            return new HousePayBuilderResult()
            {

            };
        }

        public async Task<HousePayModel> CreateHousePay(CreateHousePayModelDTO housePayModel)
        {
            try
            {
                var housePay = await _context.HousePays.FirstOrDefaultAsync(x => x.Title == housePayModel.Title);
                if (housePay == null)
                {
                    housePay = _mapper.Map<CreateHousePayModelDTO, HousePayModel>(housePayModel);
                    housePay.Service = new ServiceModel();
                    await _context.HousePays.AddAsync(housePay);
                    await _context.SaveChangesAsync();
                    return housePay;
                }
                else
                    throw new Exception("HousePay does exist");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteHousePay(DeleteHousePayModelDTO dtoModel)
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
                throw new Exception("HousePay does not exist!");
            }
        }
        public async Task<HousePayModelDTO> UpdateHousePay(UpdateHousePayModelDTO dtoModel)
        {
            var housePay = await _context.HousePays.FirstOrDefaultAsync(x => x.Title == dtoModel.Title);
            if (housePay != null)
            {
                _mapper.Map<UpdateHousePayModelDTO, HousePayModel>(dtoModel, housePay);

                _context.HousePays.Update(housePay);
                await _context.SaveChangesAsync();
                return _mapper.Map<HousePayModel, HousePayModelDTO>(housePay);
            }
            else
            {
                throw new Exception("HousePay does not exist!");
            }
        }

        public async Task<IEnumerable<HousePayModelDTO>> GetAllHousePays()
        {
            return await _context.HousePays.Select(x => _mapper.Map<HousePayModel,HousePayModelDTO>(x)).ToListAsync();
        }
        public async Task<CounterModelDTO> CreateCounter(CreateCounterModelDTO createcounterModelDTO)
        {
            try
            {
                if (await _context.Counters.FirstOrDefaultAsync(x => x.Number == createcounterModelDTO.Number) == null)
                {
                    var housePay = await _context.HousePays.FirstOrDefaultAsync(x => x.Title == createcounterModelDTO.HousePayTitle);
                    if (housePay != null)
                    {
                        var counterModel = _mapper.Map<CreateCounterModelDTO, CounterModel>(createcounterModelDTO);
                        counterModel.Type = await _context.HousePaymentType.FirstOrDefaultAsync(x => x.Name == createcounterModelDTO.Type);
                        counterModel.HousePaymentId = housePay.Id;
                        if (counterModel.Type != null)
                        {
                            await _context.Counters.AddAsync(counterModel);
                            await _context.SaveChangesAsync();
                            var result = _mapper.Map<CounterModel, CounterModelDTO>(counterModel);
                            result.Type = counterModel.Type.Name;
                            return result;
                        }
                        throw new Exception("Couner type does not exoist");
                    }
                    throw new Exception("HousePay does not exist");
                }
                throw new Exception("Counter already exist, cant create one more with same VIN code!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteCounter(DeleteCounterModelDTO deleteCounterModel)
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
        public async Task<CounterModelDTO> UpdateCounter(UpdateCounterModelDTO counterModel)
        {   
            var counter = await _context.Counters.FirstOrDefaultAsync(x => x.Number == counterModel.Number);
            if (counter != null)
            {
                counter = _mapper.Map<UpdateCounterModelDTO, CounterModel>(counterModel, counter);
                _context.Update(counter);
                await _context.SaveChangesAsync();
                var updateCounter = _mapper.Map<CounterModel, CounterModelDTO>(counter);
                return updateCounter;
            }
            else
                throw new Exception("Counter does not exist");
            
        }
        public async Task<ICollection<CounterModelDTO>> GetAllCounters()
        {
            return await _context.Counters.Select(x => _mapper.Map<CounterModel,CounterModelDTO>(x)).ToListAsync();
        }
    }
}



