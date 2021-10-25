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

namespace CityWeb.Infrastructure.Service.Transport
{
    class TaxiService
    {
        private readonly ApplicationContext _context;
        public TaxiService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<CreateTaxiModelDTO> CreateTaxi(CreateTaxiModelDTO createTaxiDTO)
        { 
            //var result = _context.Taxi.FirstOrDefaultAsync(x => x.Title == taxiModelDTO.Title);
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
                throw new Exception("Taxi was not created!");
            }
        }

        public async Task DeleteTaxi(DeleteTaxiModelDTO deleteTaxiDTO)
        {
            var taxi = await _context.Taxi.FirstOrDefaultAsync(x => x.Title == deleteTaxiDTO.Title);
            if (taxi != null)
                _context.Taxi.Remove(taxi);
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

        public async Task<TaxiCarModel> CreateTaxiCar(AddTaxiCarDTO addTaxiCarDTO)
        {
            //var result = _context.Taxi.FirstOrDefaultAsync(x => x.Title == taxiModelDTO.Title);
            if (_context.TaxiCar.FirstOrDefaultAsync(x => x.Taxi.Title == addTaxiCarDTO.TaxiTitle && x.VINCode == addTaxiCarDTO.VINCode) == null)
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
                    _context.TaxiCar.Add(taxiCarModel);
                    _context.SaveChanges();
                    return await _context.TaxiCar.FirstOrDefaultAsync(x => x.VINCode == addTaxiCarDTO.VINCode);
                }
                else
                    throw new Exception("Taxi does not exist!");
            }
            else
            {
                throw new Exception("Car was not created!");
            }
        }

        public async Task<UpdateCarDTO> UpdateTaxiCar(UpdateCarDTO updateCarDTO)
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

        public async Task DeleteTaxiCar(DeleteCarDTO deleteCarDTO)
        {
            var taxiCar = await _context.TaxiCar.FirstOrDefaultAsync(x => x.VINCode == deleteCarDTO.VINCode);
            if (taxiCar != null)
                _context.TaxiCar.Remove(taxiCar);
            else
                throw new Exception("Car does not exist");
        }

    }
}