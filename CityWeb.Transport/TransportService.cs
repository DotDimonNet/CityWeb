using CityWeb.Entities;
using CityWeb.Infrastructure.Enums;
using CityWeb.Infrastructure.Interfaces;
using CityWeb.Transport.Enums;
using CityWeb.Transport.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Transport
{
    public class TransportService : ITransportService
    {
        private readonly IServiceContext _context;
        private readonly ILogger<ITransportService> _logger;
        public bool IsActive { get; set; }
        public string Version { get; set; }
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<IPrice> Pricelist { get; set; }

        public TransportService(IServiceContext context, ILogger<ITransportService> logger)
        {
            _context = context;
            _logger = logger;
            Pricelist = GetInitialPricesForServiceUsage();
        }

        private static IEnumerable<IPrice> GetInitialPricesForServiceUsage()
        {
            var prices = new List<IPrice>();
            foreach (var type in Enum.GetValues(typeof(TransportType)).Cast<TransportType>())
            {
                prices.Add(new FullPrice()
                {
                    Tax = 3,
                    VAT = 0.1,
                    Price = (int)type * 10,
                    Title = $"{type}",
                    Description = $"Paid for usage transport service with {type} type."
                });
            }
            return prices;
        }

        public IEnumerable<IUser> GetUsersActivityForDateRange(DateTime start, DateTime end)
        {
            var usersIds = (_context.GetService("Payment") as IPaymentService)
                .GetAllPaymentsByDateRange(start, end).Select(x => x.OwnerId);

            return (_context.GetService("UserManagement") as IUserManagementService)
                .GetUsers(usersIds);
        }

        public bool RateService(IUser user, IRating rating)
        {
            try
            {
                var existingRating = user.Ratings.FirstOrDefault(x => x.ServiceId == Id);
                if (existingRating != null)
                {
                    _logger.LogWarning($"User {user.Email} already rated transport service.");
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

        public ITransportJourney Run(Guid userId, TransportType transportType, DateTime time, params IAddress[] addresses)
        {
            try
            {
                var paymentService = _context.GetService("Payment") as IPaymentService;
                var price = Pricelist.FirstOrDefault(x => x.Title == transportType.ToString());
                var balance = paymentService.GetAcceptableBalance(userId, price);
                if (balance != null)
                {
                    var (status, paymentId) = paymentService.CreateNewPayment(balance.Id, price);

                    if (status == PaymentStatus.Created && paymentId != Guid.Empty)
                    {
                        return new TransportJourney(userId, transportType, addresses, paymentId);
                    }
                    else
                    {
                        _logger.LogWarning($"User {userId} has acceptable balance, but something happens with payment creation.");
                        return null;
                    }
                }
                else
                {
                    _logger.LogWarning($"User {userId} has not acceptable balance to use {nameof(TransportService)} with {transportType}.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error on TransportService.Run method.");
                throw;
            }
        }
    }
}
