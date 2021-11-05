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
using CityWeb.Domain.DTO;

namespace CityWeb.Infrastructure.Interfaces.Service
{
    public interface ITaxiService
    {
        public Task<IEnumerable<TaxiModelDTO>> GetAllTaxi();
        public Task<IEnumerable<TaxiCarModelDTO>> GetAllTaxiCars();
        public Task<TaxiModelDTO> CreateTaxi(CreateTaxiModelDTO createTaxiDTO);
        public Task<bool> DeleteTaxi(DeleteTaxiModelDTO deleteTaxiDTO);
        public Task<TaxiModelDTO> UpdateTaxi(UpdateTaxiModelDTO updateTaxiDTO);
        public Task<TaxiCarModelDTO> AddTaxiCar(AddTaxiCarDTO addTaxiCarDTO);
        public Task<TaxiCarModelDTO> UpdateTaxiCar(UpdateTaxiCarDTO updateCarDTO);
        public Task<bool> DeleteTaxiCar(DeleteTaxiCarDTO deleteCarDTO);
        public Task<IEnumerable<TaxiModelDTO>> GetTaxi(TaxiBuilderResult builderResult, IEnumerable<AddressModelDTO> addresses);
        public Task<IEnumerable<string>> GetTaxiTypes(TaxiBuilderResult builderResult, Guid Id);
        public Task<bool> CheckOrder(TaxiBuilderResult builderResult, int type);
        public Task OrderTaxi(TaxiBuilderResult builderResult);
        public  Task EndJourney(Guid Id);
    }
}
