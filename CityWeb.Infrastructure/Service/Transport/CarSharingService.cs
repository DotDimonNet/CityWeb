﻿using CityWeb.Domain.DTO.Transport.Car;
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
    class CarSharingService
    {
        private readonly ApplicationContext _context;
        public CarSharingService(ApplicationContext context)
        {
            _context = context;
        }
        
        public async Task<CarSharingBuilderResult> NextStep(int step = 0)
        {
            var builderResult = await SetupCarSharingBuilderResult();

            switch (step)
            {
                case 1:
                    return await StepOne(builderResult, "");
                case 2:
                    return await StepThree(builderResult);
                case 3:
                    return await StepThree(builderResult);
                default:
                    return builderResult;
            }
        }

        public async Task<CarSharingBuilderResult> SetupCarSharingBuilderResult()
        {
            return new CarSharingBuilderResult()
            {

            };
        }

        public async Task<CarSharingBuilderResult> StepOne(CarSharingBuilderResult builderResult, string Title)
        {
            builderResult.Title = Title;
            return builderResult;
        }

        public async Task<CarSharingBuilderResult> StepTwo(CarSharingBuilderResult builderResult, TransportType transportType)
        {
            builderResult.Car = await _context.RentCars.FirstOrDefaultAsync(x => x.CarSharing.Title == builderResult.Title);
            return builderResult;
        }

        public async Task<CarSharingBuilderResult> StepThree(CarSharingBuilderResult carSharingBuilderResult)
        {
            carSharingBuilderResult.Payment = await _context.Payments.FirstOrDefaultAsync();
            return carSharingBuilderResult;
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

        public async Task DeleteCarSharing(DeleteCarSharingModelDTO deleteCarSharingDTO)
        {
            var carSharing = await _context.CarSharings.FirstOrDefaultAsync(x => x.Title == deleteCarSharingDTO.Title);
            if (carSharing != null)
                _context.CarSharings.Remove(carSharing);
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

        public async Task<RentCarModel> CreateRentCar(AddRentCarDTO addRentCarDTO)
        {
            //var result = _context.Taxi.FirstOrDefaultAsync(x => x.Title == taxiModelDTO.Title);
            if (_context.RentCars.FirstOrDefaultAsync(x => x.CarSharing.Title == addRentCarDTO.CarSharingTitle && x.VINCode == addRentCarDTO.VINCode) == null)
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
                    return await _context.RentCars.FirstOrDefaultAsync(x => x.VINCode == addRentCarDTO.VINCode);
                }
                else
                    throw new Exception("CarSharing does not exist!");
            }
            else
            {
                throw new Exception("Car was not created!");
            }
        }

        public async Task<UpdateCarDTO> UpdateRentCar(UpdateCarDTO updateCarDTO)
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
                return rentiCar.ToUpdateCarDTO();
            }
            else
                throw new Exception("Car does not exist");
        }

        public async Task DeleteRentCar(DeleteCarDTO deleteCarDTO)
        {
            var rentCar = await _context.RentCars.FirstOrDefaultAsync(x => x.VINCode == deleteCarDTO.VINCode);
            if (rentCar != null)
                _context.RentCars.Remove(rentCar);
            else
                throw new Exception("Car does not exist");
        }

        public async Task RentACar(RentACarDTO rentCar)
        {
            var car = await _context.RentCars.FirstOrDefaultAsync(x => x.VINCode == rentCar.VINCode);
            /*if (car.RentPeriod.Where(x => x.StartTime >= rentCar.DateStart && x.StartTime <= rentCar.DateEnd 
                                        || x.EndTime >= rentCar.DateStart && x.EndTime <= rentCar.DateEnd ))
                                        != null)*/
            //return car.ToRentACarDTO();
        }
    }
}
