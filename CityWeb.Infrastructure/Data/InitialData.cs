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

            if (!_context.DeliveryFromType.Any())
            {
                _context.AddRange(
                    DeliveryFromType.Restaurant,
                    DeliveryFromType.FastFood,
                    DeliveryFromType.FoodMarket
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
