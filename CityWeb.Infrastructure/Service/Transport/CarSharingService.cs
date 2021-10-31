using CityWeb.Domain.DTO.Transport.Car;
using CityWeb.Domain.DTO.Transport.CarSharing;
using CityWeb.Domain.Entities;
using CityWeb.Domain.ValueTypes;
using CityWeb.Infrastructure.Extentions;
using CityWeb.Infrastructure.Interfaces.Service;
using CityWeb.Infrastucture.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Infrastructure.Service.Transport
{
    public class CarSharingService: ICarSharingService
    {
        private readonly ApplicationContext _context;
        public CarSharingService(ApplicationContext context)
        {
            _context = context;
        }
        
        public IEnumerable<CarSharingModel> GetAllCarSharings()
        {
            return _context.CarSharings;
        }

        public IEnumerable<RentCarModel> GetAllRentCars()
        {
            return _context.RentCars;
        }

        public CarSharingBuilderResult SetupCarSharingBuilderResult()
        {
            return new CarSharingBuilderResult()
            {

            };
        }

        public async Task<IEnumerable<RentCarsModelDTO>> StepOne(CarSharingBuilderResult builderResult, string title)
        {
            builderResult.CarSharingTitle = title;
            var carSharing = await _context.CarSharings.FirstOrDefaultAsync(x => x.Title == title);
            if (carSharing != null)
            {
                builderResult.Location = carSharing.Location;
                return _context.RentCars.Where(x => x.CarSharingId == carSharing.Id).Select(y => y.ToRentCarsModelDTO());
            }
            else
                throw new Exception("CarSharing does not exist!");
        }

        public async Task<RentCarsModelDTO> StepTwo(CarSharingBuilderResult builderResult, string vINCode)
        {
            var car = await _context.RentCars.FirstOrDefaultAsync(x => x.CarSharing.Title == builderResult.CarSharingTitle && x.VINCode == vINCode);
            if (car != null)
            {
                builderResult.Car = car;
                return builderResult.Car.ToRentCarsModelDTO();
            }
            else
                throw new Exception("Car does not exist!");
            
        }

        public async Task<bool> StepThree(CarSharingBuilderResult builderResult, PeriodModel period)
        {
            if (builderResult.Car.IsFree(period))
            {
                builderResult.RentPeriod = period;
                builderResult.Price = (period.EndTime.Day - period.StartTime.Day) * builderResult.Car.Price.Total;
                return true;
            }
            else
                throw new Exception("Car is not free in this period");
        }

        public async Task<CreateCarSharingModelDTO> CreateCarSharing(CreateCarSharingModelDTO createCarSharingDTO)
        {
            if (await _context.CarSharings.FirstOrDefaultAsync(x => x.Title == createCarSharingDTO.Title) == null)
            {
                var carSharingModel = new CarSharingModel()
                {
                    Title = createCarSharingDTO.Title,
                    Description = createCarSharingDTO.Description
                };
                _context.CarSharings.Add(carSharingModel);
                await _context.SaveChangesAsync();
                return carSharingModel.ToCreateCarSharingModelDTO();
            }
            else
            {
                throw new Exception("CarSharing already exist, cant create one more with same title!");
            }
        }

        public async Task<bool> DeleteCarSharing(DeleteCarSharingModelDTO deleteCarSharingDTO)
        {
            var carSharing = await _context.CarSharings.FirstOrDefaultAsync(x => x.Title == deleteCarSharingDTO.Title);
            if (carSharing != null)
            { 
                _context.CarSharings.Remove(carSharing);
                await _context.SaveChangesAsync();
                return true;
            }
            else
                throw new Exception("CarSharing does not exist");
        }

        public async Task<UpdateCarSharingModelDTO> UpdateCarSharing(UpdateCarSharingModelDTO updateCarSharingDTO)
        {
            var carSharing = await _context.CarSharings.FirstOrDefaultAsync(x => x.Title == updateCarSharingDTO.Title);
            if (carSharing != null)
            {
                carSharing.Description = updateCarSharingDTO.Description;
                carSharing.Location = updateCarSharingDTO.Location;
                _context.Update(carSharing);
                await _context.SaveChangesAsync();
                return carSharing.ToUpdateCarSharingModelDTO();
            }
            else
                throw new Exception("CarSharing does not exist");
        }

        public async Task<AddRentCarDTO> AddRentCar(AddRentCarDTO addRentCarDTO)
        {
            if (await _context.RentCars.FirstOrDefaultAsync(x => x.VINCode == addRentCarDTO.VINCode) == null)
            {
                var carSharing = await _context.CarSharings.FirstOrDefaultAsync(x => x.Title == addRentCarDTO.CarSharingTitle);
                if (carSharing != null)
                {
                    var rentCarModel = new RentCarModel()
                    {
                        CarSharing = carSharing,
                        CarSharingId = carSharing.Id,
                        VINCode = addRentCarDTO.VINCode,
                        Type = addRentCarDTO.Type,
                        Mark = addRentCarDTO.Mark,
                        Seats = addRentCarDTO.Seats,
                        Number = addRentCarDTO.Number,
                        Color = addRentCarDTO.Color
                    };
                    _context.RentCars.Add(rentCarModel);
                    await _context.SaveChangesAsync();
                    return rentCarModel.ToAddRentCarDTO();
                }
                else
                    throw new Exception("CarSharing does not exist!");
            }
            else
            {
                throw new Exception("Car already exist, cant create one more with same VIN code!");
            }
        }

        public async Task<UpdateRentCarDTO> UpdateRentCar(UpdateRentCarDTO updateCarDTO)
        {
            var rentiCar = await _context.RentCars.FirstOrDefaultAsync(x => x.VINCode == updateCarDTO.VINCode);
            if (rentiCar != null)
            {
                rentiCar.Mark = updateCarDTO.Mark;
                rentiCar.Color = updateCarDTO.Color;
                rentiCar.Type = updateCarDTO.Type;
                rentiCar.Seats = updateCarDTO.Seats;
                rentiCar.Number = updateCarDTO.Number;

                _context.Update(rentiCar);
                await _context.SaveChangesAsync();
                return rentiCar.ToUpdateRentCarDTO();
            }
            else
                throw new Exception("Car does not exist");
        }

        public async Task<bool> DeleteRentCar(DeleteRentCarDTO deleteCarDTO)
        {
            var rentCar = await _context.RentCars.FirstOrDefaultAsync(x => x.VINCode == deleteCarDTO.VINCode);
            if (rentCar != null)
            {
                _context.RentCars.Remove(rentCar);
                await _context.SaveChangesAsync();
                return true;
            }            
            else
                throw new Exception("Car does not exist");
        }
    }
}
