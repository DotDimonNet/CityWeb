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
            if (await _context.CarSharings.FirstOrDefaultAsync(x => x.Title == createCarSharingDTO.Title) == null)
            {
                CarSharingModel carSharing = _mapper.Map<CreateCarSharingModelDTO, CarSharingModel>(createCarSharingDTO);
                carSharing.Service = new ServiceModel();
                await _context.CarSharings.AddAsync(carSharing);
                await _context.SaveChangesAsync();
                CarSharingModelDTO result = _mapper.Map<CarSharingModel, CarSharingModelDTO>(carSharing);
                result.Location = _mapper.Map<AddressModel, AddressModelDTO>(carSharing.Location);
                return result;
            }
            else
            {
                throw new Exception("CarSharing already exist, cant create one more with same title!");
            }
        }

        public async Task<bool> DeleteCarSharing(DeleteCarSharingModelDTO deleteCarSharingDTO)
        {
            CarSharingModel carSharing = await _context.CarSharings.FirstOrDefaultAsync(x => x.Id == deleteCarSharingDTO.Id);
            if (carSharing != null)
            { 
                _context.CarSharings.Remove(carSharing);
                await _context.SaveChangesAsync();
                return true;
            } 
            else
                throw new Exception("CarSharing does not exist");
        }

        public async Task<CarSharingModelDTO> UpdateCarSharing(UpdateCarSharingModelDTO updateCarSharingDTO)
        {
            CarSharingModel carSharing = await _context.CarSharings.FirstOrDefaultAsync(x => x.Title == updateCarSharingDTO.Title);
            if (carSharing != null)
            {
                _mapper.Map<UpdateCarSharingModelDTO, CarSharingModel>(updateCarSharingDTO, carSharing);

                _context.Update(carSharing);
                await _context.SaveChangesAsync();
                CarSharingModelDTO result = _mapper.Map<CarSharingModel, CarSharingModelDTO>(carSharing);
                result.Location = _mapper.Map<AddressModel, AddressModelDTO>(carSharing.Location);
                return result;
            }
            else
                throw new Exception("CarSharing does not exist");
        }

        public async Task<RentCarsModelDTO> AddRentCar(AddRentCarDTO addRentCarDTO)
        {
            try
            {
                if (await _context.RentCars.FirstOrDefaultAsync(x => x.Id == addRentCarDTO.Id) == null)
                {
                    CarSharingModel carSharing = await _context.CarSharings.FirstOrDefaultAsync(x => x.Id == addRentCarDTO.CarSharingId);
                    if (carSharing != null)
                    {
                        RentCarModel rentCarModel = _mapper.Map<AddRentCarDTO, RentCarModel>(addRentCarDTO);
                        rentCarModel.Type = await _context.TransportTypes.FirstOrDefaultAsync(x => x.Name == addRentCarDTO.Type);
                        rentCarModel.CarSharing = carSharing;
                        if (rentCarModel.Type != null)
                        {
                            await _context.RentCars.AddAsync(rentCarModel);
                            await _context.SaveChangesAsync();
                            RentCarsModelDTO result = _mapper.Map<RentCarModel, RentCarsModelDTO>(rentCarModel);
                            result.Type = rentCarModel.Type.Name;
                            return result;
                        }
                        else
                            throw new Exception("Transport type does not exist");
                    }
                    else
                        throw new Exception("CarSharing does not exist!");
                }
                else
                    throw new Exception("Car already exist, cant create one more with same VIN code!");
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<RentCarsModelDTO> UpdateRentCar(UpdateRentCarDTO updateCarDTO)
        {
            RentCarModel rentCar = await _context.RentCars.FirstOrDefaultAsync(x => x.Id == updateCarDTO.Id);
            if (rentCar != null)
            {
                _mapper.Map<UpdateRentCarDTO, RentCarModel> (updateCarDTO, rentCar);
                rentCar.Type = await _context.TransportTypes.FirstOrDefaultAsync(x => x.Name == updateCarDTO.Type);
                if (rentCar.Type != null)
                {
                    _context.Update(rentCar);
                    await _context.SaveChangesAsync();
                    RentCarsModelDTO result = _mapper.Map<RentCarModel, RentCarsModelDTO>(rentCar);
                    result.Type = rentCar.Type.Name;
                    return result;
                }
                else
                    throw new Exception("Transport type does not exist");
            }
            else
                throw new Exception("Car does not exist");
        }

        public async Task<bool> DeleteRentCar(DeleteRentCarDTO deleteCarDTO)
        {
            RentCarModel rentCar = await _context.RentCars.FirstOrDefaultAsync(x => x.Id == deleteCarDTO.Id);
            if (rentCar != null)
            {
                _context.RentCars.Remove(rentCar);
                await _context.SaveChangesAsync();
                return true;
            }
            else
                throw new Exception("Car does not exist");
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
            builderResult.CarSharingId = id;
            CarSharingModel carSharing = await _context.CarSharings.FirstOrDefaultAsync(x => x.Id == id);
            if (carSharing != null)
            {
                builderResult.Location = _mapper.Map<AddressModel, AddressModelDTO>(carSharing.Location);
                return await _context.RentCars.Where(x => x.CarSharingId == carSharing.Id).Select(y => _mapper.Map<RentCarModel, RentCarsModelDTO>(y)).ToListAsync(); ;
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
        public async Task<IEnumerable<PeriodModelDTO>> GetCarResersedPeriods(CarSharingBuilderResult builderResult, Guid id)
        {
            RentCarModel car = await _context.RentCars.FirstOrDefaultAsync(x => x.CarSharing.Id == builderResult.CarSharingId && x.Id == id);
            if (car != null)
            {
                builderResult.Car = _mapper.Map<RentCarModel,RentCarsModelDTO>(car);
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
            RentCarModel car = await FindRentById(builderResult.Car.Id);
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
