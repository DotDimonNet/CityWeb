using CityWeb.Domain.DTO.Transport.Taxi;
using CityWeb.Infrastructure.Extentions;
using CityWeb.Domain.Entities;
using CityWeb.Infrastucture.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Domain.DTO.Transport.Car;
using CityWeb.Domain.ValueTypes;
using CityWeb.Domain.Enums;
using CityWeb.Infrastructure.Interfaces.Service;

namespace CityWeb.Infrastructure.Service.Transport
{
    public class TaxiService : ITaxiService
    {
        private readonly ApplicationContext _context;
        public TaxiService(ApplicationContext context)
        {
            _context = context;
        }

        public TaxiBuilderResult SetupTaxiBuilderResult()
        {
            return new TaxiBuilderResult()
            {

            };
        }

        public IEnumerable<TaxiModel> GetAllTaxis()
        {
            return _context.Taxi;
        }

        public IEnumerable<TaxiCarModel> GetAllTaxiCars()
        {
            return _context.TaxiCar;
        }

        public async Task<IEnumerable<TaxiModelDTO>> StepOne(TaxiBuilderResult builderResult, ICollection<AddressModel> addresses)
        {
            builderResult.VisitedAddresses = addresses;
            return await _context.Taxi.Select(x => x.ToTaxiModelDTO()).ToListAsync();
        }

        public async Task<IEnumerable<TransportType>> StepTwo(TaxiBuilderResult builderResult, string title)
        {
            builderResult.TaxiTitle = title;
            var taxi = await _context.Taxi.FirstOrDefaultAsync(x => x.Title == title);
            if (taxi != null)
            {
                return await _context.TaxiCar.Where(x => x.TaxiId == taxi.Id).Select(x => x.Type).Distinct().ToListAsync();
            }
            else
                throw new Exception("CarSharing does not exist!");
        }        

        public async Task<bool> StepThree(TaxiBuilderResult builderResult, TransportType taxiType)
        {
            builderResult.TaxiType = taxiType;
            builderResult.Price = new PriceModel()
            {

            };
            return true;
        }

        public async Task<CreateTaxiModelDTO> CreateTaxi(CreateTaxiModelDTO createTaxiDTO)
        { 
            if (await _context.Taxi.FirstOrDefaultAsync(x => x.Title == createTaxiDTO.Title) == null)
            {
                var taxiModel = new TaxiModel()
                {
                    Title = createTaxiDTO.Title,
                    Description = createTaxiDTO.Description
                };
                _context.Taxi.Add(taxiModel);
                _context.SaveChanges();
                return taxiModel.ToCreateTaxiModelDTO();
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

        public async Task<UpdateTaxiModelDTO> UpdateTaxi(UpdateTaxiModelDTO updateTaxiDTO)
        {
            var taxi = await _context.Taxi.FirstOrDefaultAsync(x => x.Title == updateTaxiDTO.Title);
            if (taxi != null)
            {
                taxi.Description = updateTaxiDTO.Description;
                _context.Update(taxi);
                await _context.SaveChangesAsync();
                return taxi.ToUpdateTaxiModelDTO();
            }
            else
                throw new Exception("Taxi does not exist");
        }

        public async Task<TaxiCarModel> AddTaxiCar(AddTaxiCarDTO addTaxiCarDTO)
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
                        Type = addTaxiCarDTO.Type,
                        Mark = addTaxiCarDTO.Mark,
                        Seats = addTaxiCarDTO.Seats,
                        Number = addTaxiCarDTO.Number,
                        Color = addTaxiCarDTO.Color
                    };
                    await _context.TaxiCar.AddAsync(taxiCarModel);
                    await _context.SaveChangesAsync();
                    return await _context.TaxiCar.FirstOrDefaultAsync(x => x.VINCode == addTaxiCarDTO.VINCode);
                }
                else
                    throw new Exception("Taxi does not exist!");
            }
            else
            {
                throw new Exception("Car already exist, cant create with same VINCode!");
            }
        }

        public async Task<UpdateTaxiCarDTO> UpdateTaxiCar(UpdateTaxiCarDTO updateCarDTO)
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
                return taxiCar.ToUpdateTaxiCarDTO();
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