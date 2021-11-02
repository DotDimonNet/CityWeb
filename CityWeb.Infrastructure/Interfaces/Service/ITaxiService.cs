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
        public Task<TaxiModelDTO> CreateTaxi(CreateTaxiModelDTO createTaxiDTO);
        public Task<bool> DeleteTaxi(DeleteTaxiModelDTO deleteTaxiDTO);
        public Task<TaxiModelDTO> UpdateTaxi(UpdateTaxiModelDTO updateTaxiDTO);
        public Task<TaxiCarModelDTO> AddTaxiCar(AddTaxiCarDTO addTaxiCarDTO);
        public Task<TaxiCarModelDTO> UpdateTaxiCar(UpdateTaxiCarDTO updateCarDTO);
        public Task<bool> DeleteTaxiCar(DeleteTaxiCarDTO deleteCarDTO);
    }
}
