using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using CityWeb.Infrastructure.Authorization;
using CityWeb.Domain.Entities;

namespace CityWeb.Infrastucture.Data
{
    public class DbInitializer
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<ApplicationUserModel> _userManager;
        private readonly RoleManager<ApplicationUserRole> _roleManager;

        public DbInitializer(
            ApplicationContext context,
            UserManager<ApplicationUserModel> userManager,
            RoleManager<ApplicationUserRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Initialize()
        {
            _context.Database.EnsureDeleted();
            //_context.Database.Migrate();
            _context.Database.EnsureCreated();

            IdentityResult result;

            InitialData.SetupEnums(_context);
            InitialData.SetupData(_context);

            if (!_context.Roles.Any(r => r.Name == Roles.Admin))
            {
                //Create the Administartor Role
                result = await _roleManager.CreateAsync(new ApplicationUserRole(Roles.Admin));
                if (!result.Succeeded) throw new DbInitializationException(result.Errors.Select(x => x.Description).Aggregate((x, y) => $"{x} {y}"));
            }

            if (!_context.Roles.Any(r => r.Name == Roles.ContentManager))
            {
                //Create the TasteExpert Role
                result = await _roleManager.CreateAsync(new ApplicationUserRole(Roles.ContentManager));
                if (!result.Succeeded) throw new DbInitializationException(result.Errors.Select(x => x.Description).Aggregate((x, y) => $"{x} {y}"));
            }

            if (!_context.Roles.Any(r => r.Name == Roles.User))
            {
                //Create the User Role
                result = await _roleManager.CreateAsync(new ApplicationUserRole(Roles.User));
                if (!result.Succeeded) throw new DbInitializationException(result.Errors.Select(x => x.Description).Aggregate((x, y) => $"{x} {y}"));
            }

            if (!_context.Roles.Any(r => r.Name == Roles.Guest))
            {
                //Create the User Role
                result = await _roleManager.CreateAsync(new ApplicationUserRole(Roles.Guest));
                if (!result.Succeeded) throw new DbInitializationException(result.Errors.Select(x => x.Description).Aggregate((x, y) => $"{x} {y}"));
            }

            if (!_context.Users.Any(r => r.UserName == "admin@admin.admin"))
            {
                var user = new ApplicationUserModel { 
                    UserName = "admin@admin.admin", 
                    Email = "admin@admin.admin", 
                    EmailConfirmed = true, 
                    Profile = new UserProfileModel
                    {
                        Address = new AddressModel()
                        {
                            ApartmentNumber = "6",
                            StreetName = "Soborna st.",
                            HouseNumber = "1",
                        }
                    }
                };
                string password = "P@ssw0rd";

                result = await _userManager.CreateAsync(user, password);
                if (!result.Succeeded) throw new DbInitializationException(result.Errors.Select(x => x.Description).Aggregate((x, y) => $"{x} {y}"));

                result = await _userManager.AddToRoleAsync(await _userManager.FindByNameAsync(user.UserName), Roles.Admin);
                if (!result.Succeeded) throw new DbInitializationException(result.Errors.Select(x => x.Description).Aggregate((x, y) => $"{x} {y}"));

                result = await _userManager.AddToRoleAsync(await _userManager.FindByNameAsync(user.UserName), Roles.ContentManager);
                if (!result.Succeeded) throw new DbInitializationException(result.Errors.Select(x => x.Description).Aggregate((x, y) => $"{x} {y}"));

                result = await _userManager.AddToRoleAsync(await _userManager.FindByNameAsync(user.UserName), Roles.User);
                if (!result.Succeeded) throw new DbInitializationException(result.Errors.Select(x => x.Description).Aggregate((x, y) => $"{x} {y}"));



                _context.SaveChanges();

            }
            var taxi1 = new TaxiModel()
            {
                Title = "888",
                Description = "Common taxi",
                Created = DateTime.Now,
                Modified = DateTime.Now,
                Vehicle = 
                {
                    new TaxiCarModel()
                    {
                        Mark = "Ford",
                        IsFree = true,
                        Color = "brown",
                        Seats = 4,
                        Created = DateTime.Now,
                        Modified = DateTime.Now,
                        Type = Domain.Enums.TransportType.TaxiEconom,
                        StartAddress = new AddressModel()
                        {
                            StreetName = "Keletska",
                            HouseNumber = "55"
                        },
                        DestinationAddresses = 
                        {
                            new AddressModel()
                            {
                                StreetName = "Soborna",
                                HouseNumber = "24"
                            },
                            new AddressModel()
                            {
                                StreetName = "Yangelya",
                                HouseNumber = "15"
                            }
                        },
                        Price = new PriceModel()
                        {
                            Value = 20
                        },
                        Number = "AB 5162 BS",
                    },
                },
                Payments = new PaymentModel()
                {
                    Price = new PriceModel()
                    {
                        Value = 25
                    }                    
                }
            };

            var carSharing = new CarSharingModel()
            {
                Title = "Zipcar",
                Description = "Rent Car Company",
                Id = Guid.NewGuid(),
                Created = DateTime.Now,
                Modified = DateTime.Now,               
                Location = new AddressModel()
                {

                    StreetName = "Soborna",
                    HouseNumber = "25A",
                    Id = Guid.NewGuid()
                },
                Vehicle =
                    {
                        new RentCarModel()
                        {
                            Id = Guid.NewGuid(),
                            Mark = "Zhigalet",
                            Color = "GnilaVishnya",
                            IsFree = true,
                            Price = new PriceModel()
                            {
                                Id = Guid.NewGuid(),
                                Value = 5
                            },
                            Type = Domain.Enums.TransportType.RentCar,
                            Number = "ASS000L",
                            Seats = 5,
                            Created = DateTime.Now,
                            Modified = DateTime.Now,
                            RentPeriod = new PeriodModel()
                            {

                            }
                        },
                        new RentCarModel()
                        {
                            Id = Guid.NewGuid(),
                            Mark = "Honda",
                            Color = "Red",
                            IsFree = false,
                            Price = new PriceModel()
                            {
                                Id = Guid.NewGuid(),
                                Value = 500
                            },
                            Type = Domain.Enums.TransportType.RentCar,
                            Number = "AB 4532 BX",
                            Seats = 5,
                            Created = DateTime.Now,
                            Modified = DateTime.Now,
                            RentPeriod = new PeriodModel()
                            {
                                StartTime = new DateTime(2021,10,20),
                                EndTime = new DateTime(2021,10,24),
                            },
                            
                        }
                 }
            };

            var hotel = new HotelModel()
            {
                Title = "Hillton",
                Description = "5 stars",
                RentAddress = new AddressModel()
                {
                    StreetName = "Soborna",
                    HouseNumber = "1",
                },
                Rooms =
                {
                    new RoomModel()
                    {
                         Type = Domain.Enums.HotelRoomType.Delux,
                         Number = 101,
                         IsFree = true,
                         Price = new PriceModel()
                         {
                             Value = 1500,

                         },
                         
                         Created = DateTime.Now,
                         Modified = DateTime.Now,
                         RentPeriod = new PeriodModel()
                        {
                            
                        }
                    },
                    new RoomModel()
                    {
                         Type = Domain.Enums.HotelRoomType.Delux,
                         Number = 102,
                         IsFree = true,
                         Price = new PriceModel()
                         {
                             Value = 1500,

                         },
                         Created = DateTime.Now,
                         Modified = DateTime.Now,
                         RentPeriod = new PeriodModel()
                        {

                        }
                    },
                    new RoomModel()
                    {
                         Type = Domain.Enums.HotelRoomType.Delux,
                         Number = 104,
                         IsFree = false,
                         Price = new PriceModel()
                         {
                             Value = 1500,

                         },
                         Created = DateTime.Now,
                         Modified = DateTime.Now,
                         RentPeriod = new PeriodModel()
                        {
                             StartTime = new DateTime(2021,10,20),
                             EndTime = new DateTime(2021,10,24),
                        }
                    },
                    new RoomModel()
                    {
                         Type = Domain.Enums.HotelRoomType.Lux,
                         Number = 201,
                         IsFree = true,
                         Price = new PriceModel()
                         {
                             Value = 1000,
                         },
                         Created = DateTime.Now,
                         Modified = DateTime.Now,
                         RentPeriod = new PeriodModel()
                        {

                        }
                    },
                    new RoomModel()
                    {
                         Type = Domain.Enums.HotelRoomType.President,
                         Number = 606,
                         IsFree = true,
                         Price = new PriceModel()
                         {
                             Value = 3500,

                         },
                         Created = DateTime.Now,
                         Modified = DateTime.Now,
                         RentPeriod = new PeriodModel()
                        {
                             StartTime = new DateTime(2021,10,20),
                             EndTime = new DateTime(2021,10,27),
                        }
                    },
                    
                },
                Created = new DateTime(1847,12,24),
                Modified = new DateTime(2019,8,13),
            };
            var deliveryTorpedo = new DeliveryModel()
            {
                Title = "Torpedo",
                Description = "Food Delivery",
                WorkSchedule = new PeriodModel()
                {
                    StartTime =  new DateTime(2015, 7, 20, 09, 00, 00),
                    EndTime = new DateTime(2015, 7, 20, 23, 30, 00),
                },
                Order =
                {
                    new ProductModel()
                    {
                        ProductName = "Pizza Papperoni",
                        ProductPrice = new PriceModel()
                        {
                            Value = 149.99,
                            Created = DateTime.Now,
                            Modified = DateTime.Now,
                        },
                        Created = DateTime.Now,
                        Modified = DateTime.Now,
                    },
                    new ProductModel()
                    {
                        ProductName = "Pizza 4Chees",
                        ProductPrice = new PriceModel()
                        {
                            Value = 119.99,
                            Created = DateTime.Now,
                            Modified = DateTime.Now,
                        },
                        Created = DateTime.Now,
                        Modified = DateTime.Now,
                    },
                    new ProductModel()
                    {
                        ProductName = "UnagiMaki",
                        ProductPrice = new PriceModel()
                        {
                            Value = 79.99,
                            Created = DateTime.Now,
                            Modified = DateTime.Now,
                        },
                        Created = DateTime.Now,
                        Modified = DateTime.Now,
                    },
                    new ProductModel()
                    {
                        ProductName = "Burger",
                        ProductPrice = new PriceModel()
                        {
                            Value = 99.99,
                            Created = DateTime.Now,
                            Modified = DateTime.Now,
                        },
                        Created = DateTime.Now,
                        Modified = DateTime.Now,
                    },
                },
                DeliveryPrice = new PriceModel()
                {
                    Value = 25,
                    
                },

            };
            var deliveryRocket = new DeliveryModel()
            {
                Title = "Rocket",
                Description = "Get you all",
                WorkSchedule = new PeriodModel()
                {
                    StartTime = new DateTime(2015, 7, 20, 07, 00, 00),
                    EndTime = new DateTime(2015, 7, 20, 23, 30, 00),
                },
                Order =
                {
                    new ProductModel()
                    {
                        ProductName = "Salat Cesar",
                        ProductPrice = new PriceModel()
                        {
                            Value = 79.99,
                            Created = DateTime.Now,
                            Modified = DateTime.Now,
                        },
                        Created = DateTime.Now,
                        Modified = DateTime.Now,
                    },
                    new ProductModel()
                    {
                        ProductName = "Steak",
                        ProductPrice = new PriceModel()
                        {
                            Value = 139.99,
                            Created = DateTime.Now,
                            Modified = DateTime.Now,
                        },
                        Created = DateTime.Now,
                        Modified = DateTime.Now,
                    },
                    new ProductModel()
                    {
                        ProductName = "Udon whis chiken",
                        ProductPrice = new PriceModel()
                        {
                            Value = 54.99,
                            Created = DateTime.Now,
                            Modified = DateTime.Now,
                        },
                        Created = DateTime.Now,
                        Modified = DateTime.Now,
                    },
                    new ProductModel()
                    {
                        ProductName = "Shaverma",
                        ProductPrice = new PriceModel()
                        {
                            Value = 64.99,
                            Created = DateTime.Now,
                            Modified = DateTime.Now,
                        },
                        Created = DateTime.Now,
                        Modified = DateTime.Now,
                    },
                },
                DeliveryPrice = new PriceModel()
                {
                    Value = 30,
                },

            };

            var Housepay= new HousePayModel()
            {
                ServiceType = Domain.Enums.HousePaymentType.Internet,

                PayerAddress = new AddressModel()
                {
                    Id = Guid.NewGuid(),
                    StreetName = "Soborna",
                    HouseNumber = "1",
                },
                Price = new PriceModel()
                {
                    Value = 120,
                    Description = "Proplata za veresen",
                },
                Created = DateTime.Now,
                Modified = DateTime.Now,

            };

            _context.Add(deliveryRocket);
            _context.Add(deliveryTorpedo);
            _context.Add(hotel);
            _context.Add(taxi1);
            _context.Add(carSharing);
            _context.Add(Housepay);
            _context.SaveChanges();

            

        }
    }

    [Serializable]
    public class DbInitializationException : Exception
    {
        public DbInitializationException()
        {
        }

        public DbInitializationException(string message) : base(message)
        {
        }

        public DbInitializationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DbInitializationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
