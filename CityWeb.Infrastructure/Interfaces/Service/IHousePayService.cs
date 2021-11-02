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
        public Task<ICollection<CounterModelDTO>> GetCounterModels();
        public Task<bool> DeleteCounterModel(DeleteCounterModelDTO deleteCounterModel);
        public Task<UpdateCounterModelDTO> UpdateCounterModel(UpdateCounterModelDTO updateCounterModelDTO)




    }
}
