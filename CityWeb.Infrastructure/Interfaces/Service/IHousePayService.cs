using CityWeb.Domain.DTO;
using CityWeb.Domain.DTO.HousePayDTO;
using CityWeb.Domain.Entities;
using CityWeb.Domain.ValueTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Infrastructure.Interfaces.Service
{
    public interface IHousePayService
    {
        public HousePayBuilderResult SetupHousePayBuilderResult();
        public Task<HousePayModel> CreateHousePay(CreateHousePayModelDTO housepayModel);
        public Task<CounterModelDTO> CreateCounter(CreateCounterModelDTO createcounterModelDTO);
        public Task<bool> DeleteCounter(DeleteCounterModelDTO deleteCounterModel);
        public Task<IEnumerable<HousePayModelDTO>> GetAllHousePays();
        public Task<CounterModelDTO> UpdateCounter(UpdateCounterModelDTO counterModel);
        public Task<bool> DeleteHousePay(DeleteHousePayModelDTO dtoModel);
        public Task<ICollection<CounterModelDTO>> GetAllCounters();
        public Task<HousePayModelDTO> UpdateHousePay(UpdateHousePayModelDTO dtoModel);


    }
}
