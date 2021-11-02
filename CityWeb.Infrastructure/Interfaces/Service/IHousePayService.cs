using CityWeb.Domain.DTO;
using CityWeb.Domain.DTO.HousePayDTO;
using CityWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Infrastructure.Interfaces.Service
{
    public interface IHousePayService
    {
        public Task<HousePayModel> CreateHousePayModel(CreateHousePayModelDTO housepayModel);
        public Task<CounterModel> CreateCounterModel(CreateCounterModelDTO counterModel);
        public Task<bool> DeleteCounterModel(DeleteCounterModelDTO deleteCounterModel);
        public Task<ICollection<HousePayModelDTO>> GetAllHousePay();
        public IEnumerable<HousePayModelDTO> GetHousePays(int skip = 0, int take = 20);
        public Task<UpdateCounterModelDTO> UpdateCounterModel(UpdateCounterModelDTO updateCounterModelDTO);
        public Task<bool> DeleteHousePay(HousePayModelDTO dtoModel);
        public Task<ICollection<CounterModelDTO>> GetAllCounters();
        public IEnumerable<CounterModelDTO> GetCounters(int skip = 0, int take = 20);



    }
}
