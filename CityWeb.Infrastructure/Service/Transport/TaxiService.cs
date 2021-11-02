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

        public IEnumerable<TaxiModel> GetAllTaxis()
        {
            return _context.Taxi;
        }

        public IEnumerable<TaxiCarModel> GetAllTaxiCars()
        {
            return _context.TaxiCar;
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
                taxi.Description = updateTaxiDTO.Description;
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
                    var taxiCarModel = new TaxiCarModel()
                    {
                        Taxi = taxi,
                        TaxiId = taxi.Id,
                        VINCode = addTaxiCarDTO.VINCode,
                        Mark = addTaxiCarDTO.Mark,
                        Seats = addTaxiCarDTO.Seats,
                        Number = addTaxiCarDTO.Number,
                        Color = addTaxiCarDTO.Color
                    };
                    taxiCarModel.Type = await _context.TransportTypes.FirstOrDefaultAsync();
                    await _context.TaxiCar.AddAsync(taxiCarModel);
                    await _context.SaveChangesAsync();
                    return _mapper.Map<TaxiCarModel, TaxiCarModelDTO>(taxiCarModel);
                }
                else
                    throw new Exception("Taxi does not exist!");
            }
            else
            {
                throw new Exception("Car already exist, cant create with same VINCode!");
            }
        }

        public async Task<TaxiCarModelDTO> UpdateTaxiCar(UpdateTaxiCarDTO updateCarDTO)
        {
            var taxiCar = await _context.TaxiCar.FirstOrDefaultAsync(x => x.VINCode == updateCarDTO.VINCode);
            if (taxiCar != null)
            {
                taxiCar.Mark = updateCarDTO.Mark;
                taxiCar.Color = updateCarDTO.Color;
                taxiCar.Type = updateCarDTO.Type;
                taxiCar.Seats = updateCarDTO.Seats;
                taxiCar.Number = updateCarDTO.Number;

                _context.Update(taxiCar);
                await _context.SaveChangesAsync();
                return _mapper.Map<TaxiCarModel, TaxiCarModelDTO>(taxiCar);
            }
            else
                throw new Exception("Car does not exist");
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
    }
}