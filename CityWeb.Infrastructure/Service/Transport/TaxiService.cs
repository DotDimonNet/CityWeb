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
            if (await _context.Taxi.FirstOrDefaultAsync(x => x.Title == createTaxiDTO.Title) == null)
            {
                var taxiModel = _mapper.Map<CreateTaxiModelDTO, TaxiModel>(createTaxiDTO);
                taxiModel.Service = new ServiceModel();
                _context.Taxi.Add(taxiModel);
                _context.SaveChanges();
                return _mapper.Map<TaxiModel, TaxiModelDTO>(taxiModel);
            }
            else
            {
                throw new Exception("Taxi already exist, cant create one more with same title!");
            }
        }

        public async Task<bool> DeleteTaxi(DeleteTaxiModelDTO deleteTaxiDTO)
        {
            var taxi = await _context.Taxi.FirstOrDefaultAsync(x => x.Title == deleteTaxiDTO.Title);
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
            var taxi = await _context.Taxi.FirstOrDefaultAsync(x => x.Title == updateTaxiDTO.Title);
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
            var car = await _context.TaxiCar.FirstOrDefaultAsync(x => x.VINCode == addTaxiCarDTO.VINCode);
            if (car == null)
            {
                var taxi = await _context.Taxi.FirstOrDefaultAsync(x => x.Title == addTaxiCarDTO.TaxiTitle);
                if (taxi != null)
                {
                    car = _mapper.Map<AddTaxiCarDTO, TaxiCarModel>(addTaxiCarDTO);
                    car.Type = await _context.TransportTypes.FirstOrDefaultAsync(x => x.Name == addTaxiCarDTO.Type);
                    car.Taxi = taxi;
                    car.IsFree = true;
                    var result = _mapper.Map<TaxiCarModel, TaxiCarModelDTO>(car);
                    if (car.Type != null)
                    {
                        await _context.TaxiCar.AddAsync(car);
                        await _context.SaveChangesAsync();
                        result.Type = car.Type.Name;
                        return result;
                    }
                    else
                        throw new Exception("Transport type does not exist");                    
                }
                else
                    throw new Exception("Taxi does not exist!");
            }
            else
                throw new Exception("Car already exist, cant create with same VINCode!");
        }

        public async Task<TaxiCarModelDTO> UpdateTaxiCar(UpdateTaxiCarDTO updateCarDTO)
        {
            var taxiCar = await _context.TaxiCar.FirstOrDefaultAsync(x => x.VINCode == updateCarDTO.VINCode);
            if (taxiCar != null)
            {
                _mapper.Map<UpdateTaxiCarDTO, TaxiCarModel>(updateCarDTO, taxiCar);
                taxiCar.Type = await _context.TransportTypes.FirstOrDefaultAsync(x => x.Name == updateCarDTO.Type);
                taxiCar.Taxi = await _context.Taxi.FirstOrDefaultAsync(x => x.Title == updateCarDTO.TaxiTitle);
                if (taxiCar.Taxi != null)
                {
                    _context.Update(taxiCar);
                    await _context.SaveChangesAsync();
                    return _mapper.Map<TaxiCarModel, TaxiCarModelDTO>(taxiCar);
                }
                else
                    throw new Exception("Taxi does not exist!");
            }
            else
                throw new Exception("Car does not exist!");
        }

        public async Task<bool> DeleteTaxiCar(DeleteTaxiCarDTO deleteCarDTO)
        {
            var taxiCar = await _context.TaxiCar.FirstOrDefaultAsync(x => x.VINCode == deleteCarDTO.VINCode);
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
        public async Task<IEnumerable<string>> GetTaxiTypes(TaxiBuilderResult builderResult, string title)
        {
            builderResult.TaxiTitle = title;
            return await _context.TaxiCar.Where(x => x.IsFree && x.Taxi.Title == title).Select(x => x.Type.Name).Distinct().ToListAsync(); 
        }

        public async Task<bool> CheckOrder(TaxiBuilderResult builderResult, string type)
        {
            builderResult.TaxiType = type;
            var typeFromContext = await _context.TransportTypes.FirstOrDefaultAsync(x => x.Name == type);
            var car = await _context.TaxiCar.FirstOrDefaultAsync(x => x.IsFree && x.Type == typeFromContext);
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
            var type = await _context.TransportTypes.FirstOrDefaultAsync(x => x.Name == builderResult.TaxiType);
            var car = await _context.TaxiCar.FirstOrDefaultAsync(x => x.IsFree && x.Type == type);
            car.IsFree = false;
        }

        public async Task EndJourney(string vinCode)
        {
            var car = await _context.TaxiCar.FirstOrDefaultAsync(x => x.VINCode == vinCode);
            car.IsFree = true;
        }
    }
}