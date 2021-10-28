using CityWeb.Domain.Entities;
using CityWeb.Infrastucture.Data;
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
                            Title = $"Event1 in Entertainment{i + 1}",
                            EventPrice = new PriceModel()
                            {
                                Value = 300+i,
                                VAT = 10+i,
                                Tax = 10+i,
                            }
                        },
                        new EventModel()
                        {
                            Title = $"Event2 in Entertainment{i + 1}",
                            EventPrice = new PriceModel()
                            {
                                Value = 300+i,
                                VAT = 10+i,
                                Tax = 10+i,
                            }
                        }
                    }
                    
                    


                };

                entertainments.Add(entertainment);
            }
            await ApplicationContext.Entertaiments.AddRangeAsync(entertainments);
            await ApplicationContext.SaveChangesAsync();

            var carSharings = new List<CarSharingModel>();
            for (int i = 0; i < 10; i++)
            {
                var carSharing = new CarSharingModel()
                {
                    Title = $"CarSharing{i + 1}",
                    Description = $"Default description {i}",
                    Payment = new PaymentModel(),
                    Service = service,
                    ServiceId = service.Id,
                    Vehicle = 
                    { 
                        new RentCarModel()
                        {                         
                            Type = Domain.Enums.TransportType.RentCar,
                            VINCode = $"VAG489645{i+1}",
                            RentPeriod = 
                            {
                                new PeriodModel(){ },
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
            await ApplicationContext.CarSharings.AddRangeAsync(carSharings);
            await ApplicationContext.SaveChangesAsync();
        }

        private static async Task GenerateData()
        {
            var service = new ServiceModel();
            var carSharings = new List<CarSharingModel>();
            for (int i = 0; i < 10; i++)
            {
                var carSharing = new CarSharingModel()
                {
                    Title = $"CarSharing{i + 1}",
                    Description = $"Default descriotion {i}",
                    Payment = new PaymentModel(),

                };

                carSharings.Add(carSharing);
            }
            await ApplicationContext.CarSharings.AddRangeAsync(carSharings);
        

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
        }
    }
}


    