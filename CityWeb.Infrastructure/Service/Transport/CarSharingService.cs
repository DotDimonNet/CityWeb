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
                //some logic while creating builder
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
            builderResult.Price = builderResult.Car.Price;//some logic to calculate price
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
                throw new Exception("CarSharing was not created!");
            }
        }

        public async Task<bool> DeleteCarSharing(DeleteCarSharingModelDTO deleteCarSharingDTO)
        {
            var carSharing = await _context.CarSharings.FirstOrDefaultAsync(x => x.Title == deleteCarSharingDTO.Title);
            if (carSharing != null)
            { 
                _context.CarSharings.Remove(carSharing);
                _context.SaveChangesAsync();
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
                //carSharing.Location = updateCarSharingDTO.Location;
                _context.Update(carSharing);
                await _context.SaveChangesAsync();
                return carSharing.ToUpdateCarSharingModelDTO();
            }
            else
                throw new Exception("CarSharing does not exist");
        }

        public async Task<AddRentCarDTO> AddRentCar(AddRentCarDTO addRentCarDTO)
        {
            //var result = _context.Taxi.FirstOrDefaultAsync(x => x.Title == taxiModelDTO.Title);
            if (await _context.RentCars.FirstOrDefaultAsync(x => x.CarSharing.Title == addRentCarDTO.CarSharingTitle && x.VINCode == addRentCarDTO.VINCode) == null)
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
                    _context.SaveChanges();
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
