using CityWeb.Domain.Entities;
using CityWeb.Infrastucture.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityWeb.Tests
{
    public static class TestHelper
    {
        public static ApplicationContext ApplicationContext { get; set; }

        public static Mock<UserManager<ApplicationUserModel>> UserManagerMock;
        public static Mock<SignInManager<ApplicationUserModel>> SignInManagerMock;
        public static Mock<RoleManager<ApplicationUserRole>> RoleManagerMock;

        public static async Task SetupDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString())
                  .Options;

            ApplicationContext = new ApplicationContext(options);

            await SetupManagementMocks();

            var dbInitializer = new DbInitializer(ApplicationContext, UserManagerMock.Object, RoleManagerMock.Object);
            await dbInitializer.Initialize();
            await GenerateData();
        }

        private static async Task SetupManagementMocks()
        {
            var user = new ApplicationUserModel
            {
                UserName = "admin@admin.admin",
                Email = "admin@admin.admin",
                EmailConfirmed = true,
                Profile = new UserProfileModel
                {
                    Gender = "male"
                }
            };

            var store = new Mock<IUserStore<ApplicationUserModel>>();
            UserManagerMock = new Mock<UserManager<ApplicationUserModel>>(store.Object, null, null, null, null, null, null, null, null);

            UserManagerMock.Setup(x => x.CreateAsync(It.IsAny<ApplicationUserModel>(), It.IsAny<string>()))
                .Callback((ApplicationUserModel userModel, string password) =>
                {
                    ApplicationContext.Users.Add(userModel);
                    ApplicationContext.SaveChanges();
                }).ReturnsAsync(IdentityResult.Success).Verifiable();

            UserManagerMock.Setup(x => x.FindByNameAsync(It.IsAny<string>()))
                .ReturnsAsync(await ApplicationContext.Users.FirstOrDefaultAsync()).Verifiable();

            UserManagerMock.Setup(x => x.AddToRoleAsync(It.IsAny<ApplicationUserModel>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success).Verifiable();

            var _contextAccessor = new Mock<IHttpContextAccessor>();
            var _userPrincipalFactory = new Mock<IUserClaimsPrincipalFactory<ApplicationUserModel>>();
            SignInManagerMock = new Mock<SignInManager<ApplicationUserModel>>(UserManagerMock.Object,
                           _contextAccessor.Object, _userPrincipalFactory.Object, null, null, null);

            var storeRoles = new Mock<IRoleStore<ApplicationUserRole>>();
            RoleManagerMock = new Mock<RoleManager<ApplicationUserRole>>(storeRoles.Object, null, null, null, null);

            RoleManagerMock.Setup(x => x.CreateAsync(It.IsAny<ApplicationUserRole>()))
                .ReturnsAsync(IdentityResult.Success).Verifiable();

        }

        private static async Task GenerateData()
        {
            var service = new ServiceModel();
            var entertainments = new List<EntertainmentModel>();
            for (int i = 0; i < 10; i++)
            {
                var entertainment = new EntertainmentModel()
                {
                    Title = $"Entertainment{i + 1}",
                    Description = $"Default description {i}",
                    Address = new AddressModel()
                    {
                        StreetName = "Soborna",
                        HouseNumber = "25A"

                    },
                    Event =
                    {

                        new EventModel()
                        {
                            Title = $"Event1",
                            EventPrice = new PriceModel()
                            {
                                Value = 300,
                                VAT = 10,
                                Tax = 10,
                            }
                        },
                        new EventModel()
                        {
                            Title = $"Event2",
                            EventPrice = new PriceModel()
                            {
                                Value = 300,
                                VAT = 10,
                                Tax = 10,
                            }
                        }
                    }
                };

                entertainments.Add(entertainment);
            }
            await ApplicationContext.Entertaiments.AddRangeAsync(entertainments);


            #region Transport
            var carSharings = new List<CarSharingModel>();
            for (int i = 0; i < 10; i++)
            {
                var carSharing = new CarSharingModel()
                {
                    Title = $"CarSharing{i + 1}",
                    Description = $"Default description {i}",
                    Payment = new PaymentModel(),
                    //Service = service,
                    //ServiceId = service.Id,
                    Location = new AddressModel()
                    {
                        StreetName = "Porika",
                        HouseNumber = $"{i+1}"
                    },
                    Vehicle =
                    {
                        new RentCarModel()
                        {
                            Type = Domain.Enums.TransportType.RentCar,
                            VINCode = $"VAG489645{i+1}",
                            RentPeriod =
                            {
                                new PeriodModel()
                            },
                            Color = "red",
                            Mark = "Honda",
                            Number = $"AB 55{i} CC",
                            Seats = 2,
                            Price = new PriceModel()
                            {
                                Value = i*100
                            }
                        }
                    }
                };

                carSharings.Add(carSharing);
            }

            var rentCars = new List<RentCarModel>();
            for (int i = 0; i < carSharings.Count; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    var rentCar = new RentCarModel()
                    {
                        CarSharingId = carSharings[i].Id,
                        Type = Domain.Enums.TransportType.RentCar,
                        VINCode = $"BAG489645{i}{j}",
                        RentPeriod =
                        {
                            new PeriodModel() 
                            {       
                                StartTime = DateTime.Now,
                                EndTime = DateTime.Now.AddDays(j + 1)
                            },
                        },
                        Color = "red",
                        Mark = "Honda",
                        Number = $"AB 55{j}{i} CC",
                        Seats = 2,
                        Price = new PriceModel()
                        {
                            Value = i * j * 10
                        }
                    };
                    rentCars.Add(rentCar);
                }
            }

            var taxi = new List<TaxiModel>();
            for (int i = 0; i < 10; i++)
            {
                var oneTaxi = new TaxiModel()
                {
                    Title = $"Taxi{i + 1}",
                    Description = $"Default description {i}",
                    Service = service,
                    ServiceId = service.Id
                };
                taxi.Add(oneTaxi);
            };

            var taxiCars = new List<TaxiCarModel>();
            for (int i = 0; i < taxi.Count; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    var taxiCar = new TaxiCarModel()
                    {
                        TaxiId = taxi[i].Id,
                        Type = Domain.Enums.TransportType.RentCar,
                        VINCode = $"TAG489645{i}{j}",
                        Color = "yellow",
                        Mark = "BMW",
                        Number = $"AB 88{j}{i} SS",
                        Seats = 5,
                        Price = new PriceModel()
                        {
                            Value = i * j * 10
                        },
                        StartAddress = new AddressModel()
                        {
                            StreetName = "Soborna",
                            HouseNumber = $"{j+1}"
                        },
                        DestinationAddresses = { },
                        JourneyPeriod = new PeriodModel()
                        {
                            StartTime = DateTime.Now,
                            EndTime = DateTime.Now.AddMinutes(j + 5)
                        }
                    };
                    taxiCars.Add(taxiCar);
                }
            }

            await ApplicationContext.CarSharings.AddRangeAsync(carSharings);
            await ApplicationContext.RentCars.AddRangeAsync(rentCars);
            await ApplicationContext.Taxi.AddRangeAsync(taxi);
            await ApplicationContext.TaxiCar.AddRangeAsync(taxiCars);
            #endregion


            //Create Deliverys company

            var deliverys = new List<DeliveryModel>();
            for (int i = 0; i < 10; i++)
            {
                var delivery = new DeliveryModel()
                {
                    Title = $"DeliveryCompany{i + 1}",
                    Description = $"Default descriotion {i + 1}",
                    Products =
                    {
                        new ProductModel()
                        {
                            ProductName = $"Product{i + 1}",
                            ProductPrice = new PriceModel()
                            {
                                Value = i *10,
                                Tax = i*2,
                                VAT = i +1,
                            },
                            ProductType = Domain.Enums.ProductType.AlcoholicDrinks,
                            ProductImage = $"img{i+1}"
                        }
                    
                    },
                    DeliveryPrice = new PriceModel(),
                    WorkSchedule = new PeriodModel()
                    { 
                        StartTime = DateTime.Now.AddHours(-2),
                        EndTime = DateTime.Now.AddHours(+2),
                    },    
                };

                deliverys.Add(delivery);
            }
            await ApplicationContext.Deliveries.AddRangeAsync(deliverys);
            await ApplicationContext.SaveChangesAsync();


            //Create Ratings

            var ratings = new List<RatingModel>();
            for (int i = 1; i < 5; i++)
            {
                var rating = new RatingModel()
                {
                    ServiceId = Guid.NewGuid(),
                    Value = i
                };
                ratings.Add(rating);
            }
            await ApplicationContext.Ratings.AddRangeAsync(ratings);
            await ApplicationContext.SaveChangesAsync();

        }
    }
}


    