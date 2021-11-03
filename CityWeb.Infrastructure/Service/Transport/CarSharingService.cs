using AutoMapper;
using CityWeb.Domain.DTO;
using CityWeb.Domain.DTO.Transport.Car;
using CityWeb.Domain.DTO.Transport.CarSharing;
using CityWeb.Domain.Entities;
using CityWeb.Domain.Enums;
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
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;
        public CarSharingService(ApplicationContext context, IMapper mapper)
        {
            _mapper = mapper;
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

        /// <summary>
        /// Get all cars which contains CarSharing
        /// </summary>
        /// <param name="builderResult"></param>
        /// <param name="title"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get periods when car is reserved
        /// </summary>
        /// <param name="builderResult"></param>
        /// <param name="vinCode"></param>
        /// <returns></returns>
        public async Task<ICollection<PeriodModelDTO>> GetCarResersedPeriods(CarSharingBuilderResult builderResult, string vinCode)
        {
            var car = await _context.RentCars.FirstOrDefaultAsync(x => x.CarSharing.Title == builderResult.CarSharingTitle && x.VINCode == vinCode);
            if (car != null)
            {
                builderResult.Car = car.ToRentCarsModelDTO();
                return car.RentPeriod.Select(x => _mapper.Map<PeriodModel, PeriodModelDTO>(x)).ToList();
            }
            else
                throw new Exception("Car does not exist!");
        }

        /// <summary>
        /// Check is car free in period and calculate price
        /// </summary>
        /// <param name="builderResult"></param>
        /// <param name="period"></param>
        /// <returns></returns>
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

        public async Task<CarSharingModelDTO> CreateCarSharing(CreateCarSharingModelDTO createCarSharingDTO)
        {
            if (await _context.CarSharings.FirstOrDefaultAsync(x => x.Title == createCarSharingDTO.Title) == null)
            {
                var carSharing = _mapper.Map<CreateCarSharingModelDTO, CarSharingModel>(createCarSharingDTO);
                carSharing.Location = _mapper.Map<AddressModel>(createCarSharingDTO.Location);
                carSharing.Service = new ServiceModel();
                await _context.CarSharings.AddAsync(carSharing);
                await _context.SaveChangesAsync();
                return _mapper.Map<CarSharingModel, CarSharingModelDTO>(carSharing);
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

        public async Task<RentCarsModelDTO> AddRentCar(AddRentCarDTO addRentCarDTO)
        {
            if (await _context.RentCars.FirstOrDefaultAsync(x => x.VINCode == addRentCarDTO.VINCode) == null)
            {
                var carSharing = await _context.CarSharings.FirstOrDefaultAsync(x => x.Title == addRentCarDTO.CarSharingTitle);
                if (carSharing != null)
                {
                    try
                    {
                        var rentCarModel = _mapper.Map<AddRentCarDTO, RentCarModel>(addRentCarDTO);
                        rentCarModel.Type = await _context.TransportTypes.FirstOrDefaultAsync(x => x.Name == addRentCarDTO.Type);
                        rentCarModel.CarSharingId = carSharing.Id;

                        await _context.RentCars.AddAsync(rentCarModel);
                        _context.Update(carSharing);
                        await _context.SaveChangesAsync();
                        return _mapper.Map<RentCarModel, RentCarsModelDTO>(rentCarModel);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                else
                    throw new Exception("CarSharing does not exist!");
            }
            else
            {
                throw new Exception("Car already exist, cant create one more with same VIN code!");
            }
        }

        public async Task<RentCarsModelDTO> UpdateRentCar(UpdateRentCarDTO updateCarDTO)
        {
            var rentCar = await _context.RentCars.FirstOrDefaultAsync(x => x.VINCode == updateCarDTO.VINCode);
            if (rentCar != null)
            {
                rentCar.Mark = updateCarDTO.Mark;
                rentCar.Color = updateCarDTO.Color;
                rentCar.Type = await _context.TransportTypes.FirstOrDefaultAsync(x => x.Name == updateCarDTO.Type);
                rentCar.Seats = updateCarDTO.Seats;
                rentCar.Number = updateCarDTO.Number;

                _context.Update(rentCar);
                await _context.SaveChangesAsync();
                return _mapper.Map<RentCarModel, RentCarsModelDTO>(rentCar);
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
