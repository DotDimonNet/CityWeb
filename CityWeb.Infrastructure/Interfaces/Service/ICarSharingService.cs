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
        public IEnumerable<CarSharingModel> GetAllCarSharings();
        public IEnumerable<RentCarModel> GetAllRentCars();
        public CarSharingBuilderResult SetupCarSharingBuilderResult();
        public Task<IEnumerable<RentCarsModelDTO>> StepOne(CarSharingBuilderResult builderResult, string title);
        public Task<RentCarsModelDTO> StepTwo(CarSharingBuilderResult builderResult, string vINCode);
        public Task<bool> StepThree(CarSharingBuilderResult builderResult, PeriodModel period);
        public Task<CreateCarSharingModelDTO> CreateCarSharing(CreateCarSharingModelDTO createCarSharingDTO);
        public Task<bool> DeleteCarSharing(DeleteCarSharingModelDTO deleteCarSharingDTO);
        public Task<UpdateCarSharingModelDTO> UpdateCarSharing(UpdateCarSharingModelDTO updateCarSharingDTO);
        public Task<AddRentCarDTO> AddRentCar(AddRentCarDTO addRentCarDTO);
        public Task<UpdateRentCarDTO> UpdateRentCar(UpdateRentCarDTO updateCarDTO);
        public Task<bool> DeleteRentCar(DeleteRentCarDTO deleteCarDTO);
    }
}
