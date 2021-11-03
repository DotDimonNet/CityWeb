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
        public Task<ICollection<CarSharingModelDTO>> GetAllCarSharings();
        public Task<ICollection<RentCarsModelDTO>> GetAllRentCars();
        public CarSharingBuilderResult SetupCarSharingBuilderResult();
        public Task<IEnumerable<RentCarsModelDTO>> GetAllCarsOfCarSharing(CarSharingBuilderResult builderResult, string title);
        public Task<ICollection<PeriodModelDTO>> GetCarResersedPeriods(CarSharingBuilderResult builderResult, string vinCode);
        public Task<bool> CheckRent(CarSharingBuilderResult builderResult, PeriodModelDTO period);
        public Task<CarSharingModelDTO> CreateCarSharing(CreateCarSharingModelDTO createCarSharingDTO);
        public Task<bool> DeleteCarSharing(DeleteCarSharingModelDTO deleteCarSharingDTO);
        public Task<UpdateCarSharingModelDTO> UpdateCarSharing(UpdateCarSharingModelDTO updateCarSharingDTO);
        public Task<RentCarsModelDTO> AddRentCar(AddRentCarDTO addRentCarDTO);
        public Task<RentCarsModelDTO> UpdateRentCar(UpdateRentCarDTO updateCarDTO);
        public Task<bool> DeleteRentCar(DeleteRentCarDTO deleteCarDTO);

    }
}
