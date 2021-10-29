using CityWeb.Domain.DTO.Transport.Car;
using CityWeb.Domain.DTO.Transport.CarSharing;
using CityWeb.Domain.Entities;
using CityWeb.Domain.ValueTypes;
using CityWeb.Infrastructure.Extentions;
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
    public class CarSharingService
    {
        private readonly ApplicationContext _context;
        public CarSharingService(ApplicationContext context)
        {
            _context = context;
        }
        
        public async Task Steps()
        {
            var builder = SetupCarSharingBuilderResult();
            var stepOne = await StepOne(builder, "Zipcar");
            var stepTwo = StepTwo(builder, " ");
            var result = StepThree(builder, new PeriodModel() { StartTime = DateTime.Now, EndTime = DateTime.Now.AddDays(1) });
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
            builderResult.Location = carSharing.Location;
            if (carSharing != null)
            {
                return _context.RentCars.Where(x => x.CarSharingId == carSharing.Id).Select(y => y.ToRentCarsModelDTO());
            }
            else
                throw new Exception("CarSharing does not exist!");
        }

        public async Task<RentCarsModelDTO> StepTwo(CarSharingBuilderResult builderResult, string vINCode)
        {
            builderResult.Car = await _context.RentCars.FirstOrDefaultAsync(x => x.CarSharing.Title == builderResult.CarSharingTitle && x.VINCode == vINCode);
            return builderResult.Car.ToRentCarsModelDTO();
        }

        public async Task<CarSharingBuilderResult> StepThree(CarSharingBuilderResult builderResult, PeriodModel period)
        {
            builderResult.RentPeriod = period;
            builderResult.Price = new PriceModel()
            {
                Value = (period.EndTime.Day - period.StartTime.Day) * builderResult.Car.Price.Total
            };
            return builderResult;
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
                _context.SaveChanges();
                return carSharingModel.ToCreateCarSharingModelDTO();
            }
            else
            {
                throw new Exception("CarSharing is already exist!");
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

                _context.Update(carSharing);
                await _context.SaveChangesAsync();
                return carSharing.ToUpdateCarSharingModelDTO();
            }
            else
                throw new Exception("CarSharing does not exist");
        }

        public async Task<AddRentCarDTO> AddRentCar(AddRentCarDTO addRentCarDTO)
        {
            var rentCar = await _context.RentCars.FirstOrDefaultAsync(x => x.CarSharing.Title == addRentCarDTO.CarSharingTitle && x.VINCode == addRentCarDTO.VINCode);
            if (rentCar == null)
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

                    await _context.RentCars.AddAsync(rentCarModel);
                    await _context.SaveChangesAsync();
                    return rentCarModel.ToAddRentCarDTO();
                }
                else
                    throw new Exception("CarSharing does not exist!");
            }
            else
            {
                throw new Exception("Car was not created!");
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
