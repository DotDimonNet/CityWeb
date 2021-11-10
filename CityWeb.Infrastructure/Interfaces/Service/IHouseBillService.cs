using CityWeb.Domain.DTO;
using CityWeb.Domain.DTO.HouseBillDTO;
using CityWeb.Domain.Entities;
using CityWeb.Domain.ValueTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Infrastructure.Interfaces.Service
{
    public interface IHouseBillService
    {
      //  public HouseBillBuilderResult SetupHouseBillBuilderResult();
        public Task<HouseBillModelDTO> CreateHouseBill(CreateHouseBillModelDTO houseBillModel);
        public Task<CounterModelDTO> CreateCounter(CreateCounterModelDTO createCounterDTO);
        public Task<bool> DeleteCounter(DeleteCounterModelDTO deleteCounterModel);
        public Task<ICollection<HouseBillModelDTO>> GetAllHouseBills();
        public Task<CounterModelDTO> UpdateCounter(UpdateCounterModelDTO updCounter);
        public Task<bool> DeleteHouseBill(DeleteHouseBillModelDTO dtoModel);
        public Task<ICollection<CounterModelDTO>> GetAllCountersbyHouseBillId(HouseBillIdDTO housebillIdDTO);
        public Task<HouseBillModelDTO> UpdateHouseBill(UpdateHouseBillModelDTO dtoHouseBill);
        public Task<IEnumerable<HouseBillModel>> FindHouseBillbyAddress(HouseBillModelDTO houseAddress);
        public Task<ICollection<CounterModelDTO>> GetCounterByHouseBillId(HouseBillIdDTO houseBillById);

    }
}
