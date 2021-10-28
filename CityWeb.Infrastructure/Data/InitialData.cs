using CityWeb.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CityWeb.Infrastucture.Data
{
    public static class InitialData
    {
        public static void SetupEnums(ApplicationContext _context)
        {
            if (!_context.PaymentStatuses.Any())
            {
                _context.AddRange(
                    PaymentStatus.Accepted,
                    PaymentStatus.Approved,
                    PaymentStatus.Created,
                    PaymentStatus.Discarded,
                    PaymentStatus.Executed,
                    PaymentStatus.Refunded,
                    PaymentStatus.Removed
                    );

                _context.SaveChanges();
            }

            if (!_context.TransportTypes.Any())
            {
                _context.AddRange(

                    TransportType.RentCar,
                    TransportType.TaxiBusiness,
                    TransportType.TaxiEconom,
                    TransportType.TaxiStandart);

                _context.SaveChanges();
            }

            if (!_context.EventTypes.Any())
            {
                _context.AddRange(
                    EntertainmentType.Cinema,
                    EntertainmentType.Circus,
                    EntertainmentType.Club,
                    EntertainmentType.Exhibition,
                    EntertainmentType.Fest,
                    EntertainmentType.Museum,
                    EntertainmentType.Theatre
                    );

                _context.SaveChanges();
            }

            if (!_context.ProductTypes.Any())
            {
                _context.AddRange(
                    ProductType.AlcoholicDrinks,
                    ProductType.FastFood,
                    ProductType.Burgers,
                    ProductType.Pizza,
                    ProductType.Salads,
                    ProductType.Sushi,
                    ProductType.Sweets
                    );

                _context.SaveChanges();
            }

            if (!_context.HousePaymentType.Any())
            {
                _context.AddRange(
                    HousePaymentType.Electricity,
                    HousePaymentType.WaterGet,
                    HousePaymentType.WaterOut,
                    HousePaymentType.Gas,
                    HousePaymentType.GasTransport,
                    HousePaymentType.Intercom,
                    HousePaymentType.Internet,
                    HousePaymentType.TV,
                    HousePaymentType.Trash,
                    HousePaymentType.Rent);

                _context.SaveChanges();
            }

            if (!_context.HotelRoomType.Any())
            {
                _context.AddRange(
                    HotelRoomType.Delux,
                    HotelRoomType.Econom,
                    HotelRoomType.Lux,
                    HotelRoomType.Premium,
                    HotelRoomType.President,
                    HotelRoomType.Standart
                    );

                _context.SaveChanges();
            }
        }

        public static void SetupData(ApplicationContext _context)
        {
            
        }
    }
}
