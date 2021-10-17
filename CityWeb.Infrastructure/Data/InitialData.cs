﻿using CityWeb.Domain.Enums;
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
                    PaymentStatus.Removed);

                _context.SaveChanges();
            }

            if (!_context.TransportTypes.Any())
            {
                _context.AddRange(
                    TransportType.CityBus,
                    TransportType.CityTrolleybus,
                    TransportType.CityTrum,
                    TransportType.RentBycicle,
                    TransportType.RentCar,
                    TransportType.RentKickScooter,
                    TransportType.TaxiBusiness,
                    TransportType.TaxiEconom,
                    TransportType.TaxiStandart);

                _context.SaveChanges();
            }
        }

        public static void SetupData(ApplicationContext _context)
        {
            
        }
    }
}
