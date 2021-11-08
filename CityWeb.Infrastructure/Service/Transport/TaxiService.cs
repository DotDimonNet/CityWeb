using CityWeb.Domain.DTO.Transport.Taxi;
using CityWeb.Infrastructure.Extentions;
using CityWeb.Domain.Entities;
using CityWeb.Infrastucture.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CityWeb.Domain.DTO.Transport.Car;
using CityWeb.Domain.ValueTypes;
using CityWeb.Infrastructure.Interfaces.Service;
using AutoMapper;
using CityWeb.Domain.DTO;
using System.Linq;
using CityWeb.Domain.Enums;
using Microsoft.Extensions.Logging;

namespace CityWeb.Infrastructure.Service.Transport
{
    public class TaxiService : ITaxiService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;
        private readonly ILogger<TaxiService> _logger;
        public TaxiService(ApplicationContext context, IMapper mapper, ILogger<TaxiService> logger)
        {
            _mapper = mapper;
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<TaxiModelDTO>> GetAllTaxi()
        {
            return await _context.Taxi.Select(x => _mapper.Map<TaxiModel, TaxiModelDTO>(x)).ToListAsync();
        }

        public async Task<IEnumerable<TaxiCarModelDTO>> GetAllTaxiCars()
        {
            return await _context.TaxiCar.Select(x => _mapper.Map<TaxiCarModel, TaxiCarModelDTO>(x)).ToListAsync();
        }

        public async Task<TaxiModelDTO> CreateTaxi(CreateTaxiModelDTO createTaxiDTO)
        {
            try
            {
                TaxiModel taxiModel = _mapper.Map<CreateTaxiModelDTO, TaxiModel>(createTaxiDTO);
                taxiModel.Service = new ServiceModel();
                await _context.Taxi.AddAsync(taxiModel);
                await _context.SaveChangesAsync();
                return _mapper.Map<TaxiModel, TaxiModelDTO>(taxiModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }     
        }
        public async Task<TaxiModelDTO> UpdateTaxi(UpdateTaxiModelDTO updateTaxiDTO)
        {
            try
            {
                TaxiModel taxi = await _context.Taxi.FirstOrDefaultAsync(x => x.Id == updateTaxiDTO.Id);
                if (taxi != null)
                {
                    taxi = _mapper.Map<UpdateTaxiModelDTO, TaxiModel>(updateTaxiDTO, taxi);
                    _context.Update(taxi);
                    await _context.SaveChangesAsync();
                    return _mapper.Map<TaxiModel, TaxiModelDTO>(taxi);
                }
                throw new Exception($"Taxi {updateTaxiDTO.Id} does not exist");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<bool> DeleteTaxi(DeleteTaxiModelDTO deleteTaxiDTO)
        {
            try
            {
                TaxiModel taxi = await _context.Taxi.FirstOrDefaultAsync(x => x.Id == deleteTaxiDTO.Id);
                if (taxi != null)
                {
                    _context.Taxi.Remove(taxi);
                    await _context.SaveChangesAsync();
                    return true;
                }
                throw new Exception("Taxi does not exist");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<TaxiCarModelDTO> AddTaxiCar(AddTaxiCarDTO addTaxiCarDTO)
        {
            try
            {
                TaxiModel taxi = await _context.Taxi.FirstOrDefaultAsync(x => x.Id == addTaxiCarDTO.TaxiId);
                if (taxi != null)
                {
                    TaxiCarModel car = _mapper.Map<AddTaxiCarDTO, TaxiCarModel>(addTaxiCarDTO);
                    car.Taxi = taxi;
                    car.IsFree = true;
                    await _context.TaxiCar.AddAsync(car);
                    await _context.SaveChangesAsync();
                    return _mapper.Map<TaxiCarModel, TaxiCarModelDTO>(car);
                }
                throw new Exception($"Taxi {addTaxiCarDTO.TaxiId} does not exist!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<TaxiCarModelDTO> UpdateTaxiCar(UpdateTaxiCarDTO updateCarDTO)
        {
            try
            {
                TaxiCarModel taxiCar = await _context.TaxiCar.FirstOrDefaultAsync(x => x.Id == updateCarDTO.Id);
                if (taxiCar != null)
                {
                    _mapper.Map<UpdateTaxiCarDTO, TaxiCarModel>(updateCarDTO, taxiCar);
                    _context.TaxiCar.Update(taxiCar);
                    await _context.SaveChangesAsync();
                    return _mapper.Map<TaxiCarModel, TaxiCarModelDTO>(taxiCar);
                }
                throw new Exception($"Car {updateCarDTO.Id} does not exist!");
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<bool> DeleteTaxiCar(DeleteTaxiCarDTO deleteCarDTO)
        {
            try
            {
                TaxiCarModel taxiCar = await _context.TaxiCar.FirstOrDefaultAsync(x => x.Id == deleteCarDTO.Id);
                if (taxiCar != null)
                {
                    _context.TaxiCar.Remove(taxiCar);
                    await _context.SaveChangesAsync();
                    return true;
                }
                throw new Exception("Car does not exist");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Return all taxi and write addresses to builder
        /// </summary>
        /// <param name="builderResult"></param>
        /// <param name="addresses"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TaxiModelDTO>> GetTaxi(TaxiBuilderResult builderResult, IEnumerable<AddressModelDTO> addresses)
        {
            try
            {
                builderResult.VisitedAddresses = addresses;
                return await GetAllTaxi();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// return available taxi types and write taxi title to builder
        /// </summary>
        /// <param name="builderResult"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public async Task<IEnumerable<string>> GetTaxiTypes(TaxiBuilderResult builderResult, Guid id)
        {
            try
            {
                builderResult.Id = id;
                return await _context.TaxiCar.Where(x => x.IsFree && x.Taxi.Id == id)
                    .Select(x => x.Type.ToString()).Distinct().ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<bool> CheckOrder(TaxiBuilderResult builderResult, string type)
        {
            try
            {
                builderResult.TaxiType = type;
                TransportType typeFromContext = Enum.Parse<TransportType>(type);
                TaxiCarModel car = await _context.TaxiCar.FirstOrDefaultAsync(x => x.IsFree && x.Type == typeFromContext);
                if (car != null)
                {
                    builderResult.Price = car.Price.Total;
                    return true;
                }
                throw new Exception("There are no free cars at this time");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task OrderTaxi(TaxiBuilderResult builderResult)
        {
            TransportType type = Enum.Parse<TransportType>(builderResult.TaxiType);
            TaxiCarModel car = await _context.TaxiCar.FirstOrDefaultAsync(x => x.IsFree && x.Type == type);
            car.IsFree = false;
        }

        public async Task EndJourney(Guid id)
        {
            TaxiCarModel car = await _context.TaxiCar.FirstOrDefaultAsync(x => x.Id == id);
            car.IsFree = true;
        }
    }
}