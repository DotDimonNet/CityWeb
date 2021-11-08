using AutoMapper;
using CityWeb.Domain.Entities;
using CityWeb.Domain.Enums;
using CityWeb.Infrastucture.Data;
using CityWeb.Mapping;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
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
        public static Mock<UserManager<ApplicationUserModel>> UserManagerMock { get; set; }
        public static Mock<SignInManager<ApplicationUserModel>> SignInManagerMock { get; set; }
        public static Mock<RoleManager<ApplicationUserRole>> RoleManagerMock { get; set; }
        public static IMapper TestMapper { get; set; }
    
        public static ILogger<T> SetupTestLogger<T>() where T : class
        {
            return new NullLogger<T>();
        }

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
            var config = new MapperConfiguration(x =>
            {
                x.AddProfile<MappingProfile>();
                x.AddProfile<CarSharingMappingProfile>();
                x.AddProfile<TaxiMappingProfile>();
                x.AddProfile<HotelMappingProfile>();
                x.AddProfile<HousePayMappingProfile>();
                x.AddProfile<DeliveryMappingProfile>();
                x.AddProfile<AccountMappingProfile>();
                x.AddProfile<MappingEntertainmentProfile>();
            });
            TestMapper = new Mapper(config);
        }


        private static async Task SetupManagementMocks()
        {
            var user = new ApplicationUserModel
            {
                UserName = "admin@admin.admin",
                Email = "admin@admin.admin",
                PasswordHash = "qwerty123",
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

            UserManagerMock.Setup(x => x.ChangePasswordAsync(It.IsAny<ApplicationUserModel>(), It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success).Verifiable();

            SignInManagerMock = new Mock<SignInManager<ApplicationUserModel>>(
                            UserManagerMock.Object,
                            new Mock<IHttpContextAccessor>().Object,
                            new Mock<IUserClaimsPrincipalFactory<ApplicationUserModel>>().Object,
                            new Mock<IOptions<IdentityOptions>>().Object,
                            new Mock<ILogger<SignInManager<ApplicationUserModel>>>().Object,
                            new Mock<IAuthenticationSchemeProvider>().Object,
                            new Mock<IUserConfirmation<ApplicationUserModel>>().Object);

            SignInManagerMock.Setup(x => x.CheckPasswordSignInAsync(It.IsAny<ApplicationUserModel>(), It.IsAny<string>(), It.IsAny<bool>()))
                .ReturnsAsync(SignInResult.Success).Verifiable();

            var storeRoles = new Mock<IRoleStore<ApplicationUserRole>>();
            RoleManagerMock = new Mock<RoleManager<ApplicationUserRole>>(storeRoles.Object, null, null, null, null);

            RoleManagerMock.Setup(x => x.CreateAsync(It.IsAny<ApplicationUserRole>()))
                .ReturnsAsync(IdentityResult.Success).Verifiable();

        }
        #region GenarateHotel
        private static async Task<ICollection<RoomModel>> GenerateRooms(int amount)
        {
            var rooms = new List<RoomModel>();
            for (int i = 1; i <= amount; i++)
            {
                var room = new RoomModel()
                {
                    Type = HotelRoomType.GetRandomRoomType(),
                    Image = $"Room_img{i}.png",
                    Number = i + 100,
                    IsFree = GetRandomBool(),
                    Price = new PriceModel
                    {
                        Value = (i * 100) + 300,
                    },
                };
                rooms.Add(room);
            }
            await ApplicationContext.Rooms.AddRangeAsync(rooms);
            return rooms;
        }
        private static async Task<ICollection<HotelModel>> GenerateHotels(int amount)
        {
            var hotels = new List<HotelModel>();
            for (int i = 1; i < 11; i++)
            {
                var hotel = new HotelModel()
                {
                    Title = $"Hotel {i}",
                    Description = $"Default descriotion {i}",
                    Image = $"Hotel_img{i}.png",
                    RentAddress = new AddressModel
                    {
                        StreetName = $"Street {i}",
                        HouseNumber = $"i",
                    },
                    Rooms = await GenerateRooms(15),

                };
                hotels.Add(hotel);
            }
            return hotels;
        }
        #endregion

        private static bool GetRandomBool()
        {
            var rnd = new Random();
            if (rnd.Next(2) == 0)
                return false;
            return true;
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
                    Service = service,
                    Location = new AddressModel()
                    {
                        StreetName = "Porika",
                        HouseNumber = $"{i + 1}"
                    },
                    Vehicle =
                    {
                        new RentCarModel()
                        {
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
                        Type = TransportType.Business,
                        Color = "yellow",
                        Mark = "BMW",
                        Number = $"AB 88{j}{i} SS",
                        Seats = 5,
                        IsFree = true,
                        Price = new PriceModel()
                        {
                            Value = i * j * 10
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
                            ProductType = Domain.Enums.ProductType.Burgers,
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

            //Create Hotels
            await ApplicationContext.Hotels.AddRangeAsync(await GenerateHotels(10));
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

            //Create HousePay

            var housePays = new List<HousePayModel>();
            for (int i = 0; i < 10; i++)
            {
                var housePay = new HousePayModel()
                {
                    Title = $"HousePay{i + 1}",
                    Description = $"Default description {i}",
                    Service = service,
                    ServiceId = service.Id,
                    HouseHoldAdress = new AddressModel()
                    {
                        StreetName = "Soborna",
                        HouseNumber = $"{i + 1}"
                    },
                    CounterModels =
                    {
                        new CounterModel()
                        {
                            Number = $"NA/000000{i+1}",
                            Type = await ApplicationContext.HousePaymentType.FirstOrDefaultAsync(),
                            CountPrice = new PriceModel()
                            {
                                Value = i*10
                            },
                            PriceByItem = 1.25,
                            StartCount = 10,
                            EndCount = 25
                        }
                    }
                };
                housePays.Add(housePay);
            }
        }
    }
}


    