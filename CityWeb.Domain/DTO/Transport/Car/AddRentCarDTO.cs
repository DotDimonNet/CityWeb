using CityWeb.Domain.Entities;
using CityWeb.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.DTO.Transport.Car
{
    public class AddRentCarDTO
    {
        public Guid Id { get; set; }
        public Guid CarSharingId { get; set; }
        public string Type { get; set; }
        public string Mark { get; set; }
        public string Color { get; set; }
        public int Seats { get; set; }
        public string Number { get; set; }
        public PriceModelDTO Price { get; set; }
    }
}
