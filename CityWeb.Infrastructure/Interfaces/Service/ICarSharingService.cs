using CityWeb.Domain.DTO;
using CityWeb.Domain.DTO.Transport.Car;
using CityWeb.Domain.DTO.Transport.CarSharing;
using CityWeb.Domain.Entities;
using CityWeb.Domain.ValueTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Infrastructure.Interfaces.Service
{
    public interface ICarSharingService
    {
        public Task<CarSharingModelDTO> CreateCarSharing(CreateCarSharingModelDTO createCarSharingDTO);
        public Task<CarSharingModelDTO> UpdateCarSharing(UpdateCarSharingModelDTO updateCarSharingDTO);
        public Task<bool> DeleteCarSharing(DeleteCarSharingModelDTO deleteCarSharingDTO);
        public Task<RentCarsModelDTO> AddRentCar(AddRentCarDTO addRentCarDTO);
        public Task<RentCarsModelDTO> UpdateRentCar(UpdateRentCarDTO updateCarDTO);
        public Task<bool> DeleteRentCar(DeleteRentCarDTO deleteCarDTO);
        public Task<IEnumerable<CarSharingModelDTO>> GetAllCarSharings();
        public Task<IEnumerable<RentCarsModelDTO>> GetAllRentCars();
        public CarSharingBuilderResult SetupCarSharingBuilderResult();
        public Task<IEnumerable<RentCarsModelDTO>> GetAllCarsOfCarSharing(CarSharingBuilderResult builderResult, string title);
        public Task<IEnumerable<PeriodModelDTO>> GetCarResersedPeriods(CarSharingBuilderResult builderResult, string vinCode);
        /// <summary>
        /// Check is exist free car and calculate price
        /// </summary>
        /// <param name="builderResult"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        public Task<bool> CheckRent(CarSharingBuilderResult builderResult, PeriodModelDTO period);
        public Task RentACar(CarSharingBuilderResult builderResult);
    }
}
