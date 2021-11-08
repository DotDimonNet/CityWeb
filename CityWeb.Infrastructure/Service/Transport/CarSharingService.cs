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
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<CarSharingService> _logger;
        public CarSharingService(ApplicationContext context, IMapper mapper, ILogger<CarSharingService> logger)
        {
            _mapper = mapper;
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<CarSharingModelDTO>> GetAllCarSharings()
        {
            return await _context.CarSharings.Select(x => _mapper.Map<CarSharingModel, CarSharingModelDTO>(x)).ToListAsync();
        }

        public async Task<IEnumerable<RentCarsModelDTO>> GetAllRentCars()
        {
            return await _context.RentCars.Select(x => _mapper.Map<RentCarModel, RentCarsModelDTO>(x)).ToListAsync();
        }

        public async Task<CarSharingModelDTO> CreateCarSharing(CreateCarSharingModelDTO createCarSharingDTO)
        {
            try
            {
                CarSharingModel carSharing = _mapper.Map<CreateCarSharingModelDTO, CarSharingModel>(createCarSharingDTO);
                carSharing.Service = new ServiceModel();
                await _context.CarSharings.AddAsync(carSharing);
                await _context.SaveChangesAsync();
                CarSharingModelDTO result = _mapper.Map<CarSharingModel, CarSharingModelDTO>(carSharing);
                result.Location = _mapper.Map<AddressModel, AddressModelDTO>(carSharing.Location);
                _logger.LogInformation($"CarSharing {carSharing.Title}({carSharing.Id}) was created.");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
            
        }

        public async Task<CarSharingModelDTO> UpdateCarSharing(UpdateCarSharingModelDTO updateCarSharingDTO)
        {
            try
            {
                CarSharingModel carSharing = await _context.CarSharings.FirstOrDefaultAsync(x => x.Id == updateCarSharingDTO.Id);
                if (carSharing != null)
                {
                    _mapper.Map<UpdateCarSharingModelDTO, CarSharingModel>(updateCarSharingDTO, carSharing);
                    _context.Update(carSharing);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation($"CarSharing {carSharing.Id} was updated.");
                    return _mapper.Map<CarSharingModel, CarSharingModelDTO>(carSharing);
                }
                throw new Exception($"CarSharing {updateCarSharingDTO.Id} does not exist!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<bool> DeleteCarSharing(DeleteCarSharingModelDTO deleteCarSharingDTO)
        {
            try
            {
                CarSharingModel carSharing = await _context.CarSharings.FirstOrDefaultAsync(x => x.Id == deleteCarSharingDTO.Id);
                if (carSharing != null)
                {
                    _context.CarSharings.Remove(carSharing);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation($"CarSharing {deleteCarSharingDTO.Id} was deleted.");
                    return true;
                }
                throw new Exception($"CarSharing {deleteCarSharingDTO.Id} does not exist!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
            
        }

        public async Task<RentCarsModelDTO> AddRentCar(AddRentCarDTO addRentCarDTO)
        {
            try
            {
                CarSharingModel carSharing = await _context.CarSharings.FirstOrDefaultAsync(x => x.Id == addRentCarDTO.CarSharingId);
                if (carSharing != null)
                {
                    RentCarModel rentCarModel = _mapper.Map<AddRentCarDTO, RentCarModel>(addRentCarDTO);
                    rentCarModel.Type = addRentCarDTO.Type;
                    rentCarModel.CarSharing = carSharing;
                    await _context.RentCars.AddAsync(rentCarModel);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation($"RentCar {rentCarModel.Id} was added to {carSharing.Title}({carSharing.Id}).");
                    return _mapper.Map<RentCarModel, RentCarsModelDTO>(rentCarModel);
                }
                throw new Exception($"CarSharing {addRentCarDTO.CarSharingId} does not exist!");
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<RentCarsModelDTO> UpdateRentCar(UpdateRentCarDTO updateCarDTO)
        {
            try
            {
                RentCarModel rentCar = await _context.RentCars.FirstOrDefaultAsync(x => x.Id == updateCarDTO.Id);
                if (rentCar != null)
                {
                    _mapper.Map<UpdateRentCarDTO, RentCarModel>(updateCarDTO, rentCar);
                    rentCar.Type = updateCarDTO.Type;
                    _context.Update(rentCar);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation($"RentCar {rentCar.Id} was updated.");
                    return _mapper.Map<RentCarModel, RentCarsModelDTO>(rentCar);
                }
                throw new Exception($"Rent car {updateCarDTO.Id} doe not exist!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
           
        }

        public async Task<bool> DeleteRentCar(DeleteRentCarDTO deleteCarDTO)
        {
            try
            {
                RentCarModel rentCar = await _context.RentCars.FirstOrDefaultAsync(x => x.Id == deleteCarDTO.Id);
                if (rentCar != null)
                {
                    _context.RentCars.Remove(rentCar);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation($"Rent car {deleteCarDTO.Id} was deleted.");
                    return true;
                }
                throw new Exception($"Rent car {deleteCarDTO.Id} does not exist!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
            
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
        public async Task<IEnumerable<RentCarsModelDTO>> GetAllCarsOfCarSharing(CarSharingBuilderResult builderResult, Guid id)
        {
            try
            {
                builderResult.CarSharingId = id;
                CarSharingModel carSharing = await _context.CarSharings.FirstOrDefaultAsync(x => x.Id == id);
                if (carSharing != null)
                {
                    builderResult.Location = _mapper.Map<AddressModel, AddressModelDTO>(carSharing.Location);
                    return await _context.RentCars.Where(x => x.CarSharingId == carSharing.Id).Select(y => _mapper.Map<RentCarModel, RentCarsModelDTO>(y)).ToListAsync(); ;
                }
                throw new Exception($"CarSharing {id} does not exist!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
            
        }

        /// <summary>
        /// Get periods when car is reserved
        /// </summary>
        /// <param name="builderResult"></param>
        /// <param name="vinCode"></param>
        /// <returns></returns>
        public async Task<IEnumerable<PeriodModelDTO>> GetCarResersedPeriods(CarSharingBuilderResult builderResult, Guid id)
        {
            try
            {
                RentCarModel car = await _context.RentCars.FirstOrDefaultAsync(x => x.CarSharing.Id == builderResult.CarSharingId && x.Id == id);
                if (car != null)
                {
                    builderResult.Car = _mapper.Map<RentCarModel, RentCarsModelDTO>(car);
                    return car.RentPeriod.Select(x => _mapper.Map<PeriodModel, PeriodModelDTO>(x)).ToList();
                }
                else
                    throw new Exception($"Car {id} does not exist!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
            
        }

        /// <summary>
        /// Check is car free in period and calculate price
        /// </summary>
        /// <param name="builderResult"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        public async Task<bool> CheckRent(CarSharingBuilderResult builderResult, PeriodModelDTO period)
        {
            try
            {
                RentCarModel car = await FindRentById(builderResult.Car.Id);
                if (car != null)
                {
                    if (car.IsFree(period))
                    {
                        builderResult.RentPeriod.StartTime = period.StartTime;
                        builderResult.RentPeriod.EndTime = period.EndTime;
                        builderResult.Price = (period.EndTime.Day - period.StartTime.Day) * car.Price.Total;
                        return true;
                    }
                    throw new Exception($"Car {car.Id} is not free in this period");
                }
                throw new Exception($"Car {builderResult.Car.Id} does not exist");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task RentACar(CarSharingBuilderResult builderResult)
        {
            RentCarModel car = await FindRentById(builderResult.Car.Id);
            car.RentPeriod.Add(_mapper.Map<PeriodModelDTO, PeriodModel>(builderResult.RentPeriod));
        }

        public async Task<RentCarModel> FindRentById(Guid id)
        {
            return await _context.RentCars.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
