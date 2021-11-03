using AutoMapper;
using CityWeb.Domain.Entities;
using CityWeb.Infrastucture.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Infrastructure.Service
{
    public class PaymentService
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        public PaymentService(ApplicationContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

            /*public async Task<PaymentModel> AddPayment()
            {

            }*/
    }
}
