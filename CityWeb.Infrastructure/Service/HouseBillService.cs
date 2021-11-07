using CityWeb.Infrastucture.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityWeb.Domain.Entities;
using CityWeb.Domain.DTO;
using CityWeb.Domain.Enums;
using CityWeb.Domain.ValueTypes;
using CityWeb.Infrastructure.Extentions;
using Microsoft.EntityFrameworkCore;
using CityWeb.Infrastructure.Interfaces.Service;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace CityWeb.Infrastructure.Service
{
    public class HouseBillService : IHouseBillService
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<HouseBillService> _logger;

        public HouseBillService(ApplicationContext context, IMapper mapper, ILogger<HouseBillService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<HouseBillModel> CreateHouseBill(CreateHouseBillModelDTO houseBillModel)
        {
            var houseBill = await _context.HouseBills.FirstOrDefaultAsync(x => x.Title == houseBillModel.Title);
            if (houseBill == null)
            {
                try
                {
                    houseBill = _mapper.Map<CreateHouseBillModelDTO, HouseBillModel>(houseBillModel);
                    houseBill.Service = new ServiceModel();
                    await _context.HouseBills.AddAsync(houseBill);
                    await _context.SaveChangesAsync();

                    _logger.LogInformation($"HouseBill {houseBill.Title} was created");

                    return houseBill;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    throw new Exception(ex.Message);
                }
            }
            _logger.LogInformation($"HouseBill {houseBill.Title} already created");
            throw new Exception("HouseBill does exist");
        }
        public async Task<bool> DeleteHouseBill(DeleteHouseBillModelDTO dtoModel)
        {
            var houseBill = await _context.HouseBills.FirstOrDefaultAsync(x => x.Title == dtoModel.Title);
            if (houseBill != null)
            {
                _context.Remove(houseBill);
                _context.SaveChanges();

                _logger.LogInformation($"HouseBill {houseBill.Title} was deleted");

                return true;
            }
            else
            {
                _logger.LogInformation($"HouseBill {houseBill.Title} doesnt exist");
                throw new Exception("HouseBill does not exist!");
            }
        }
        public async Task<HouseBillModelDTO> UpdateHouseBill(UpdateHouseBillModelDTO dtoModel)
        {
            var houseBill = await _context.HouseBills.FirstOrDefaultAsync(x => x.Title == dtoModel.Title);
            if (houseBill != null)
            {
                try
                {
                    _mapper.Map<UpdateHouseBillModelDTO, HouseBillModel>(dtoModel, houseBill);

                    _context.HouseBills.Update(houseBill);
                    await _context.SaveChangesAsync();

                    _logger.LogInformation($"HouseBill {houseBill.Title} was updated");

                    return _mapper.Map<HouseBillModel, HouseBillModelDTO>(houseBill);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    throw new Exception(ex.Message);
                }
            }
            {
                _logger.LogInformation($"HouseBill {houseBill.Title} doesnt exist");
                throw new Exception("HouseBill does not exist!");
            }
        }

        public async Task<IEnumerable<HouseBillModelDTO>> GetAllHouseBills()
        {
            try
            {
                return await _context.HouseBills.Select(x => _mapper.Map<HouseBillModel, HouseBillModelDTO>(x)).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public async Task<CounterModelDTO> CreateCounter(CreateCounterModelDTO createcounterModelDTO)
        {
            try
            {
                if (await _context.Counters.FirstOrDefaultAsync(x => x.Number == createcounterModelDTO.Number) == null)
                {
                    var houseBill = await _context.HouseBills.FirstOrDefaultAsync(x => x.Title == createcounterModelDTO.HouseBillTitle);
                    if (houseBill != null)
                    {
                        var counterModel = _mapper.Map<CreateCounterModelDTO, CounterModel>(createcounterModelDTO);
                        counterModel.Type = await _context.HouseBillType.FirstOrDefaultAsync(x => x.Name == createcounterModelDTO.Type);
                        counterModel.HouseBillId = houseBill.Id;
                        if (counterModel.Type != null)
                        {
                            await _context.Counters.AddAsync(counterModel);
                            await _context.SaveChangesAsync();
                            var result = _mapper.Map<CounterModel, CounterModelDTO>(counterModel);
                            result.Type = counterModel.Type.Name;

                            _logger.LogInformation($"Counter {result.Number} succsesfully created in {houseBill.Title} HouseBill");

                            return result;
                        }
                        _logger.LogWarning($"Counter{counterModel.Number} does not exist.");
                        throw new Exception("Couner does not exist");
                    }
                    _logger.LogWarning($"HouseBill {houseBill.Title} does not exist.");
                    throw new Exception("HouseBill does not exist");
                }
                _logger.LogWarning($"Counter {createcounterModelDTO.Number} already exist");
                throw new Exception("Counter already exist, cant create one more with same number!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
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
                _logger.LogInformation($"Counter {deleteCounterModel.Number} was deleted");
                return true;
            }
            _logger.LogWarning($"Counter {deleteCounterModel.Number} does not exist");
            throw new Exception("Counter does not exist!");
        }
        public async Task<CounterModelDTO> UpdateCounter(UpdateCounterModelDTO counterModel)
        {
            var houseBill = await _context.HouseBills.FirstOrDefaultAsync(x => x.Title == counterModel.HouseBillTitle);
            if (houseBill != null)
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
                _logger.LogWarning($"Counter {counterModel.Number} in HouseBill {counterModel.HouseBillTitle}  doesnt exist");
                throw new Exception("Counter does not exist");
            }
            _logger.LogWarning($"HouseBill {counterModel.HouseBillTitle}  doesnt exist");
            throw new Exception("HouseBill with title doesnt exist");
            
        }
        public async Task<ICollection<CounterModelDTO>> GetAllCounters()
        {
            return await _context.Counters.Select(x => _mapper.Map<CounterModel,CounterModelDTO>(x)).ToListAsync();
        }

        public HouseBillBuilderResult SetupHouseBillBuilderResult()
        {
            return new HouseBillBuilderResult()
            {

            };
        }

    }
}



