﻿using CityWeb.Common.Repository;
using CityWeb.Entertainment.Interfaces;
using CityWeb.Entities;
using CityWeb.Infrastructure.Enums;
using CityWeb.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Entertainment
{
    public class EventService : IEventService
    {
        private readonly IServiceContext _context;
        private readonly IDbContext _dbContext;
        private readonly ILogger<IEventService> _logger;
        public IEnumerable<IPrice> Pricelist {get; set;}
        public bool IsActive {get; set;}
        public string Version {get; set;}
        public Guid Id {get; set;}
        public DateTime Created {get; set;}
        public DateTime Modified {get; set;}
        public string Title {get; set;}
        public string Description {get; set;}


        public EventService(IServiceContext context, ILogger<IEventService> logger)
        {
            _context = context;
            _logger = logger;
            Pricelist = GetInitialPricesForServiceUsage();
        }

        private static IEnumerable<IPrice> GetInitialPricesForServiceUsage()
        {
            var prices = new List<IPrice>();
            foreach (var type in Enum.GetValues(typeof(EventType)).Cast<EventType>())
            {
                prices.Add(new FullPrice()
                {
                    Tax = 3,
                    VAT = 0.1,
                    Price = (int)type * 10,
                    Title = $"{type}",
                    Description = $"Paid for usage event service with {type} type."
                });
            }
            return prices;
        }

        public bool RateService(IUser user, IRating rating)
        {
            try
            {
                var existingRating = user.Ratings.FirstOrDefault(x => x.ServiceId == Id);
                if (existingRating != null)
                {
                    _logger.LogWarning($"User {user.Email} already rated event service.");
                    return false;
                }
                else
                {
                    user.Ratings = user.Ratings.Append(rating);
                    (_context.GetService("UserManagement") as IUserManagementService).UpdateUserData(user);
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error on TransportService.RateService method.");
                return false;
            }
        }

        public IEventPaymentHistory Run(Guid userId, EventType eventType, DateTime time)
        {
            try
            {
                var paymentService = _context.GetService("Payment") as IPaymentService;
                var price = Pricelist.FirstOrDefault(x => x.Title == eventType.ToString());
                var balance = paymentService.GetAcceptableBalance(userId, price);
                if (balance != null)
                {
                    var (status, paymentId) = paymentService.CreateNewPayment(balance.Id, price);

                    if (status == PaymentStatus.Created && paymentId != Guid.Empty)
                    {
                        return new EventPaymentHistory(userId, eventType, paymentId);
                    }
                    else
                    {
                        _logger.LogWarning($"User {userId} has acceptable balance, but something happens with payment creation.");
                        return null;
                    }
                }
                else
                {
                    _logger.LogWarning($"User {userId} has not acceptable balance to use {nameof(EventService)} with {eventType}.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error on EventService.Run method.");
                throw;
            }
        }

    }
}
