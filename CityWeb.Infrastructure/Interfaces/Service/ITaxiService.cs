using CityWeb.Domain.DTO.Transport.Car;
using CityWeb.Domain.DTO.Transport.Taxi;
using CityWeb.Domain.Entities;
using CityWeb.Domain.ValueTypes;
using CityWeb.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Infrastructure.Interfaces.Service
{
    public interface ITaxiService
    {
        public IEnumerable<TaxiModel> GetAllTaxis();
        public IEnumerable<TaxiCarModel> GetAllTaxiCars();
        public TaxiBuilderResult SetupTaxiBuilderResult();
        public Task<IEnumerable<TaxiModelDTO>> StepOne(TaxiBuilderResult builderResult, ICollection<AddressModel> addresses);
        public Task<IEnumerable<TransportType>> StepTwo(TaxiBuilderResult builderResult, string title);
        public Task<bool> StepThree(TaxiBuilderResult builderResult, TransportType taxiType);
        public Task<CreateTaxiModelDTO> CreateTaxi(CreateTaxiModelDTO createTaxiDTO);
        public Task<bool> DeleteTaxi(DeleteTaxiModelDTO deleteTaxiDTO);
        public Task<UpdateTaxiModelDTO> UpdateTaxi(UpdateTaxiModelDTO updateTaxiDTO);
        public Task<TaxiCarModel> CreateTaxiCar(AddTaxiCarDTO addTaxiCarDTO);
        public Task<UpdateTaxiCarDTO> UpdateTaxiCar(UpdateTaxiCarDTO updateCarDTO);
        public Task<bool> DeleteTaxiCar(DeleteTaxiCarDTO deleteCarDTO);
    }
}
