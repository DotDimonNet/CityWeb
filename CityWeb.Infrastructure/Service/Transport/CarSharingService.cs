using CityWeb.Domain.DTO;
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
        
        public async Task<ICollection<CarSharingModelDTO>> GetAllCarSharings()
        {
            return await _context.CarSharings.Select(x => x.ToCarSharingModelDTO()).ToListAsync();
        }

        public async Task<ICollection<RentCarsModelDTO>> GetAllRentCars()
        {
            return await _context.RentCars.Select(x => x.ToRentCarsModelDTO()).ToListAsync();
        }

        public CarSharingBuilderResult SetupCarSharingBuilderResult()
        {
            return new CarSharingBuilderResult()
            {

            };
        }

        public async Task<IEnumerable<RentCarsModelDTO>> GetAllCarsOfCarSharing(CarSharingBuilderResult builderResult, string title)
        {
            builderResult.CarSharingTitle = title;
            var carSharing = await _context.CarSharings.FirstOrDefaultAsync(x => x.Title == title);
            if (carSharing != null)
            {
                builderResult.Location = carSharing.Location.ToAddressModelDTO();
                return _context.RentCars.Where(x => x.CarSharingId == carSharing.Id).Select(y => y.ToRentCarsModelDTO());
            }
            else
                throw new Exception("CarSharing does not exist!");
        }


        public async Task<RentCarsModelDTO> ChooseCar(CarSharingBuilderResult builderResult, string vinCode)
        {
            var car = await _context.RentCars.FirstOrDefaultAsync(x => x.CarSharing.Title == builderResult.CarSharingTitle && x.VINCode == vinCode);
            if (car != null)
            {
                builderResult.Car = car.ToRentCarsModelDTO();
                return builderResult.Car;
            }
            else
                throw new Exception("Car does not exist!");
        }

        public async Task<bool> CheckRent(CarSharingBuilderResult builderResult, PeriodModelDTO period)
        {
            var car = await _context.RentCars.FirstOrDefaultAsync(x => x.VINCode == builderResult.Car.VINCode);
            if (car.IsFree(period))
            {
                builderResult.RentPeriod.StartTime = period.StartTime;
                builderResult.RentPeriod.EndTime = period.EndTime;
                builderResult.Price = (period.EndTime.Day - period.StartTime.Day) * car.Price.Total;
                return true;
            }
            else
                throw new Exception("Car is not free in this period");
        }

        public async Task<CarSharingModel> CreateCarSharing(CreateCarSharingModelDTO createCarSharingDTO)
        {
            if (await _context.CarSharings.FirstOrDefaultAsync(x => x.Title == createCarSharingDTO.Title) == null)
            {
                var carSharing = createCarSharingDTO.FromCreateCarSharingModelDTO();
                _context.CarSharings.Add(carSharing);
                await _context.SaveChangesAsync();
                return carSharing;
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
                carSharing.FromUpdateCarSharingModelDTO(updateCarSharingDTO);               
                _context.Update(carSharing);
                await _context.SaveChangesAsync();
                return carSharing.ToUpdateCarSharingModelDTO();
            }
            else
                throw new Exception("CarSharing does not exist");
        }

        public async Task<RentCarModel> AddRentCar(AddRentCarDTO addRentCarDTO)
        {
            if (await _context.RentCars.FirstOrDefaultAsync(x => x.VINCode == addRentCarDTO.VINCode) == null)
            {
                var carSharing = await _context.CarSharings.FirstOrDefaultAsync(x => x.Title == addRentCarDTO.CarSharingTitle);
                if (carSharing != null)
                {
                    var rentCarModel = carSharing.FromAddRentCarModelDTO(addRentCarDTO);
                    _context.RentCars.Add(rentCarModel);
                    await _context.SaveChangesAsync();
                    return rentCarModel;
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
            var rentCar = await _context.RentCars.FirstOrDefaultAsync(x => x.VINCode == updateCarDTO.VINCode);
            if (rentCar != null)
            {
                rentCar.Mark = updateCarDTO.Mark;
                rentCar.Color = updateCarDTO.Color;
                rentCar.Type = updateCarDTO.Type;
                rentCar.Seats = updateCarDTO.Seats;
                rentCar.Number = updateCarDTO.Number;

                _context.Update(rentCar);
                await _context.SaveChangesAsync();
                return rentCar.ToUpdateRentCarDTO();
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
