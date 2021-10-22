using CityWeb.Domain.DTO.Transport.Taxi;
using CityWeb.Domain.Entities;
using CityWeb.Infrastucture.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Infrastructure.Service
{
    class TaxiService
    {
        private readonly ApplicationContext _context;
        public TaxiService(ApplicationContext context)
        {
            _context = context;            
        }

        public async Task<TaxiModel> CreateTaxi(CreateTaxiModelDTO taxiModelDTO)
        {
            var taxiModel = new TaxiModel()
            {
                Title = taxiModelDTO.Title,
                Description = taxiModelDTO.Description
            };

            var result = _context.Taxi.FirstOrDefaultAsync(x => x.Title == taxiModelDTO.Title);
            if (result == null)
            {
                return await result;
            }
            else
            {
                throw new Exception("Taxi was not created!");
            }
        }
    }
}
