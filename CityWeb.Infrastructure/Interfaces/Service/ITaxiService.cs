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
        public Task<ICollection<TaxiModelDTO>> GetAllTaxi();
        public Task<ICollection<TaxiCarModelDTO>> GetAllTaxiCars();
        public Task<TaxiModelDTO> CreateTaxi(CreateTaxiModelDTO createTaxiDTO);
        public Task<bool> DeleteTaxi(DeleteTaxiModelDTO deleteTaxiDTO);
        public Task<TaxiModelDTO> UpdateTaxi(UpdateTaxiModelDTO updateTaxiDTO);
        public Task<TaxiCarModelDTO> AddTaxiCar(AddTaxiCarDTO addTaxiCarDTO);
        public Task<TaxiCarModelDTO> UpdateTaxiCar(UpdateTaxiCarDTO updateCarDTO);
        public Task<bool> DeleteTaxiCar(DeleteTaxiCarDTO deleteCarDTO);
        public Task<ICollection<TaxiModelDTO>> GetTaxi(TaxiBuilderResult builderResult, ICollection<AddressModelDTO> addresses);
        public Task<ICollection<TransportType>> GetTaxiTypes(TaxiBuilderResult builderResult, string title);
        public Task<bool> CheckOrder(TaxiBuilderResult builderResult, string type);
        public Task OrderTaxi(TaxiBuilderResult builderResult);
        public  Task EndJourney(string vinCode);
    }
}
