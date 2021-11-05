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

namespace CityWeb.Infrastructure.Service.Transport
{
    public class TaxiService : ITaxiService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;
        public TaxiService(ApplicationContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
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
            TaxiModel taxiModel = _mapper.Map<CreateTaxiModelDTO, TaxiModel>(createTaxiDTO);
            taxiModel.Service = new ServiceModel();
            await _context.Taxi.AddAsync(taxiModel);
            await _context.SaveChangesAsync();
            return _mapper.Map<TaxiModel, TaxiModelDTO>(taxiModel);
        }

        public async Task<bool> DeleteTaxi(DeleteTaxiModelDTO deleteTaxiDTO)
        {
            TaxiModel taxi = await _context.Taxi.FirstOrDefaultAsync(x => x.Id == deleteTaxiDTO.Id);
            if (taxi != null)
            {
                _context.Taxi.Remove(taxi);
                await _context.SaveChangesAsync();
                return true;
            }
            else
                throw new Exception("Taxi does not exist");
        }

        public async Task<TaxiModelDTO> UpdateTaxi(UpdateTaxiModelDTO updateTaxiDTO)
        {
            TaxiModel taxi = await _context.Taxi.FirstOrDefaultAsync(x => x.Id == updateTaxiDTO.Id);
            if (taxi != null)
            {
                taxi = _mapper.Map<UpdateTaxiModelDTO, TaxiModel>(updateTaxiDTO, taxi);
                _context.Update(taxi);
                await _context.SaveChangesAsync();
                return _mapper.Map<TaxiModel, TaxiModelDTO>(taxi);
            }
            else
                throw new Exception("Taxi does not exist");
        }

        public async Task<TaxiCarModelDTO> AddTaxiCar(AddTaxiCarDTO addTaxiCarDTO)
        {
            TaxiModel taxi = await _context.Taxi.FirstOrDefaultAsync(x => x.Id == addTaxiCarDTO.TaxiId);
            if (taxi != null)
            {
                TaxiCarModel car = _mapper.Map<AddTaxiCarDTO, TaxiCarModel>(addTaxiCarDTO);
                car.Type = await _context.TransportTypes.FirstOrDefaultAsync(x => x.Id == addTaxiCarDTO.Type);
                car.Taxi = taxi;
                car.IsFree = true;
                TaxiCarModelDTO result = _mapper.Map<TaxiCarModel, TaxiCarModelDTO>(car);
                if (car.Type != null)
                {
                    await _context.TaxiCar.AddAsync(car);
                    await _context.SaveChangesAsync();
                    result.Type = car.Type.Id;
                    return result;
                }
                else
                    throw new Exception("Transport type does not exist");
            }
            else
                throw new Exception("Taxi does not exist!");
        }

        public async Task<TaxiCarModelDTO> UpdateTaxiCar(UpdateTaxiCarDTO updateCarDTO)
        {
            try
            {
                TaxiCarModel taxiCar = await _context.TaxiCar.FirstOrDefaultAsync(x => x.Id == updateCarDTO.Id);
                if (taxiCar != null)
                {
                    _mapper.Map<UpdateTaxiCarDTO, TaxiCarModel>(updateCarDTO, taxiCar);
                    taxiCar.Type = await _context.TransportTypes.FirstOrDefaultAsync(x => x.Id == updateCarDTO.Type);
                    taxiCar.Taxi = await _context.Taxi.FirstOrDefaultAsync(x => x.Id == updateCarDTO.TaxiId);
                    if (taxiCar.Taxi != null)
                    {
                        _context.TaxiCar.Update(taxiCar);
                        await _context.SaveChangesAsync();
                        return _mapper.Map<TaxiCarModel, TaxiCarModelDTO>(taxiCar);
                    }
                    throw new Exception("Taxi does not exist!");
                }
                throw new Exception("Car does not exist!");
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteTaxiCar(DeleteTaxiCarDTO deleteCarDTO)
        {
            TaxiCarModel taxiCar = await _context.TaxiCar.FirstOrDefaultAsync(x => x.Id == deleteCarDTO.Id);
            if (taxiCar != null)
            {
                _context.TaxiCar.Remove(taxiCar);
                await _context.SaveChangesAsync();
                return true;
            }
            else
                throw new Exception("Car does not exist");
        }

        /// <summary>
        /// Return all taxi and write addresses to builder
        /// </summary>
        /// <param name="builderResult"></param>
        /// <param name="addresses"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TaxiModelDTO>> GetTaxi(TaxiBuilderResult builderResult, IEnumerable<AddressModelDTO> addresses)
        {
            builderResult.VisitedAddresses = addresses;
            return await GetAllTaxi();
        }

        /// <summary>
        /// return available taxi types and write taxi title to builder
        /// </summary>
        /// <param name="builderResult"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public async Task<IEnumerable<string>> GetTaxiTypes(TaxiBuilderResult builderResult, Guid id)
        {
            builderResult.Id = id;
            return await _context.TaxiCar.Where(x => x.IsFree && x.Taxi.Id == id).Select(x => x.Type.Name).Distinct().ToListAsync(); 
        }

        public async Task<bool> CheckOrder(TaxiBuilderResult builderResult, int type)
        {
            builderResult.TaxiType = type;
            TransportType typeFromContext = await _context.TransportTypes.FirstOrDefaultAsync(x => x.Id == type);
            TaxiCarModel car = await _context.TaxiCar.FirstOrDefaultAsync(x => x.IsFree && x.Type == typeFromContext);
            if (car != null)
            {
                builderResult.Price = car.Price.Total;
                return true;
            }
            else
                throw new Exception("There are no free cars at this time");
        }

        public async Task OrderTaxi(TaxiBuilderResult builderResult)
        {
            TransportType type = await _context.TransportTypes.FirstOrDefaultAsync(x => x.Id == builderResult.TaxiType);
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